using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace sub_db
{
	internal class DownloadProgressEventArgs : EventArgs
	{
		internal long	BytesReceived		{ get; set; }
		internal long	TotalBytesToReceive	{ get; set; }
		internal double	ProgressPercentage	{ get; set; }
	};

	internal class DownloadCompletedEventArgs : EventArgs
	{
		internal bool		Success		{ get; set; }
		internal Exception?	Exception	{ get; set; }
	};

	internal class c_HttpClient
	{
		internal event EventHandler<DownloadProgressEventArgs>?		ProgressChanged;
		internal event EventHandler<DownloadCompletedEventArgs>?	DownloadCompleted;

		readonly HttpClient	m_client;
		readonly int		m_threads_count	= 4; // 线程数（分片数）
		const int			m_BUFFER_SIZE	= 8192;

		class c_Download_Task
		{
			internal string						m_url				= "";
			internal string						m_destinationPath	= "";	// 保存文件的路径
			internal CancellationToken			m_cancellationToken;

			internal bool						m_supportsRange		= true;	// 支持断点续传
			internal byte[]?					m_buffer			= null;

			internal long						m_chunkSize			= 0;	// 计算每个分片的大小
			internal (long Start, long End)[]?	m_ranges			= null;	// [chunkIndex]
			internal long[]?					m_progressTracker	= null;	// chunkIndex -> bytesReadTotal
		};

		/*==============================================================
		 * 构造函数
		 *==============================================================*/
		internal c_HttpClient(int threads_count = 4, bool ignoreSslErrors = false)
		{
			// 配置 HttpClientHandler 以忽略 SSL 证书验证
			HttpClientHandler handler = new();

			if(ignoreSslErrors)
			{
				handler.ServerCertificateCustomValidationCallback = (HttpRequestMessage msg, X509Certificate2? cert, X509Chain? chain, SslPolicyErrors sslPolicyErrors) => true;
			}

			m_client		= new HttpClient(handler);
			m_threads_count	= Math.Max(1, threads_count);
		}

		/*==============================================================
		 * 异步下载文件
		 *==============================================================*/
		internal async Task DownloadFileAsync(	string				url,
												string				destinationPath,
												CancellationToken	cancellationToken = default )
		{
			c_Download_Task task = new()
			{
				m_url				= url,
				m_destinationPath	= destinationPath,
				m_cancellationToken	= cancellationToken,
			};

			try
			{
				// 检查服务器是否支持范围请求并获取文件大小
				await CheckRangeSupportAsync(task);

				if(task.m_buffer == null)
				{
					// 0: 服务器不支持范围请求或 Content-Length 不可用
					throw new InvalidOperationException(LANGUAGES.txt(0));
				}

				// 计算每个分片的大小
				task.m_chunkSize		= task.m_buffer.Length / m_threads_count;
				task.m_ranges			= new(long, long)[m_threads_count];
				task.m_progressTracker	= new long[m_threads_count];

				for(int i = 0; i < m_threads_count; ++i)
				{
					long start			= i * task.m_chunkSize;
					long end			= (i == m_threads_count - 1) ? (task.m_buffer.Length - 1) : (start + task.m_chunkSize - 1);
					task.m_ranges[i]	= (start, end);
				}	// for

				// 并发下载所有分片
				Task[] tasks = new Task[m_threads_count];
				for(int i = 0; i < m_threads_count; ++i)
				{
					try
					{
						tasks[i] = DownloadChunkAsync(task, i);
					}
					catch(Exception)
					{
						throw;
					}
				}	// for

				await Task.WhenAll(tasks);

				// 合并分片
				await MergeChunksAsync(task);

				DownloadCompleted?.Invoke(this, new DownloadCompletedEventArgs { Success = true });
			}
			catch(OperationCanceledException)
			{
				task.m_buffer = null;
				DownloadCompleted?.Invoke(this, new DownloadCompletedEventArgs
												{
													Success		= false,
													Exception	= new OperationCanceledException(LANGUAGES.txt(1))	// 1: 下载已被取消
												});
				throw;
			}
			catch(Exception ex)
			{
				task.m_buffer = null;
				DownloadCompleted?.Invoke(this, new DownloadCompletedEventArgs { Success = false, Exception = ex });
				throw;
			}
		}

		/*==============================================================
		 * 确认服务器支持分片下载并获取文件大小，为分片做准备
		 *==============================================================*/
		async Task CheckRangeSupportAsync(c_Download_Task task)
		{
			HttpRequestMessage	request		= new(HttpMethod.Head, task.m_url);
			var					response	= await m_client.SendAsync(request, task.m_cancellationToken);

			response.EnsureSuccessStatusCode();

			task.m_supportsRange	= response.Headers.AcceptRanges.Contains("bytes");
			long?	totalBytes		= response.Content.Headers.ContentLength;

			if(task.m_supportsRange && totalBytes.HasValue)
				task.m_buffer = new byte[totalBytes.Value];
		}

		/*==============================================================
		 * 并行下载文件的一个片段，负责实际数据获取和进度跟踪
		 *==============================================================*/
		async Task DownloadChunkAsync(c_Download_Task task, int chunkIndex)
		{
			HttpRequestMessage	request	= new(HttpMethod.Get, task.m_url);

			var					ranges	= task.m_ranges![chunkIndex];

			request.Headers.Range = new System.Net.Http.Headers.RangeHeaderValue(ranges.Start, ranges.End);

			using var response = await m_client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, task.m_cancellationToken);

			response.EnsureSuccessStatusCode();

			using var contentStream = await response.Content.ReadAsStreamAsync(task.m_cancellationToken);

			int bytesReadTotal = 0;
			int bytesRead;

			while((bytesRead = await contentStream.ReadAsync(	task.m_buffer!,
																(int)(ranges.Start + bytesReadTotal),
																(int)Math.Min(m_BUFFER_SIZE, task.m_buffer!.Length - (ranges.Start + bytesReadTotal)),
																task.m_cancellationToken )) > 0)
			{
				bytesReadTotal += bytesRead;

				// 更新进度
				task.m_progressTracker![chunkIndex] = bytesReadTotal;
				long totalBytesRead = task.m_progressTracker.Sum();

				double progressPercentage = (double)totalBytesRead / task.m_buffer!.Length * 100;

				ProgressChanged?.Invoke(this, new DownloadProgressEventArgs
				{
					BytesReceived		= totalBytesRead,
					TotalBytesToReceive	= task.m_buffer!.Length,
					ProgressPercentage	= progressPercentage
				});
			}	// while
		}

		/*==============================================================
		 * 将所有分片合成为完整文件，完成下载
		 *==============================================================*/
		async Task MergeChunksAsync(c_Download_Task task)
		{
			await File.WriteAllBytesAsync(task.m_destinationPath!, task.m_buffer!);
		}
	};
}	// namespace sub_db
