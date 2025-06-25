using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace sub_db
{
	public partial class frm_UpdateDatabase : Form
	{
		public frm_UpdateDatabase()
		{
			InitializeComponent();
		}

		// 是否正在更新数据库
		internal bool	m_is_updating_database	= false;
		internal bool	m_is_stopping			= false;

		#region Winform 事件
		/*==============================================================
		 * 窗口加载时
		 *==============================================================*/
		private void frm_UpdateDatabase_Load(object sender, EventArgs e)
		{
			this.Icon	= IMAGE.img2icon(Resource1.Logo);
			this.Text	= LANGUAGES.txt(10);	// 更新数据库
		}

		/*==============================================================
		 * 窗口关闭时
		 *==============================================================*/
		private void frm_UpdateDatabase_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = (this.Owner != null);

			if(e.CloseReason == CloseReason.UserClosing)
				this.Hide();
		}

		/*==============================================================
		 * ListView 调整大小
		 *==============================================================*/
		private void ListView_Log_Resize(object sender, EventArgs e)
		{
			columnHeader_Time.Width = 122;
			columnHeader_Log.Width = listView_Log.Width - columnHeader_Time.Width - 21;
		}

		Stopwatch m_sw = new Stopwatch();

		/*==============================================================
		 * 开始
		 *==============================================================*/
		internal void PictureBox_Start_Click(object sender, EventArgs e)
		{
			m_is_updating_database	= true;
			m_is_stopping			= false;

			lock_controls(false);

			progressBar_Update.Value	= 0;
			label_Log.Text				= "";

			if(radioButton_UseLocalData.Checked)
			{
				append_log(LANGUAGES.txt(54));	// 执行数据库更新...

				Thread th = new Thread(update_db_thread);
				th.Start();
			}
			else
			{
				append_log(LANGUAGES.txt(55));	// 正在从远程服务器下载数据库文件...

				WebClient wc = new WebClient();

				wc.DownloadProgressChanged	+= Wc_DownloadProgressChanged;
				wc.DownloadDataCompleted	+= Wc_DownloadDataCompleted;

				m_sw.Restart();

				wc.DownloadDataAsync(new Uri("https://github.com/foxofice/sub_share/raw/master/Subtitles DataBase/Files/db.xml"));
			}
		}

		/*==============================================================
		 * 异步下载完成时
		 *==============================================================*/
		private void Wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			m_sw.Stop();

			if(e.Error != null)
			{
				append_log(LANGUAGES.txt(63));	// 下载数据库文件失败
				append_log(e.Error.Message);
			}
			else if(!e.Cancelled)
			{
				File.WriteAllBytes(PATH.m_k_DB_FILENAME, e.Result);

				append_log(LANGUAGES.txt(62));	// 下载数据库文件完成

				CONFIG.m_s_last_updata_db_time = DateTime.Now;
				CONFIG.write_config();

				// 加载数据
				DATA.read_data_from_file();
			}

			lock_controls(true);

			if(m_is_stopping)
			{
				append_log(	string.Format(	LANGUAGES.txt(57) + LANGUAGES.txt(60),	// 用户停止更新数据库（合计 {0:d} 条数据，耗时 {1:s}）
											DATA.m_s_all_subs.Count,
											m_sw.Elapsed.ToString() ),
							Color.Blue );
			}
			else
			{
				if(e.Error == null)
				{
					append_log(	string.Format(	LANGUAGES.txt(58) + LANGUAGES.txt(60),	// 更新数据库完成（合计 {0:d} 条数据，耗时 {1:s}）
												DATA.m_s_all_subs.Count,
												m_sw.Elapsed.ToString() ),
								Color.Green );
				}
				else
				{
					append_log(LANGUAGES.txt(59), Color.Red);	// 更新数据库失败
				}
			}

			m_is_stopping			= false;
			m_is_updating_database	= false;
		}

		/*==============================================================
		 * 异步下载进度
		 *==============================================================*/
		private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			if(m_is_stopping)
			{
				WebClient wc = (WebClient)e.UserState;
				wc.CancelAsync();
				return;
			}

			label_Log.Text = $"{e.BytesReceived}/{e.TotalBytesToReceive}({e.ProgressPercentage}%)";
			COMMON.SetProgressValue(e.ProgressPercentage * 100);
		}

		/*==============================================================
		 * 停止
		 *==============================================================*/
		private void PictureBox_Stop_Click(object sender, EventArgs e)
		{
			m_is_stopping = true;
		}
		#endregion

		/*==============================================================
		 * 锁定控件
		 *==============================================================*/
		void lock_controls(bool enabled)
		{
			pictureBox_Start.Enabled			= enabled;
			pictureBox_Start.Image				= enabled ? Resource1.Start : Resource1.Start2;
			pictureBox_Stop.Enabled				= !enabled;
			pictureBox_Stop.Image				= enabled ? Resource1.Stop2 : Resource1.Stop;

			radioButton_UseLocalData.Enabled	= enabled;
			radioButton_UseRemoteData.Enabled	= enabled;

			label_Log.Visible					= !enabled;
			progressBar_Update.Visible			= !enabled;
		}

		/*==============================================================
		 * 追加日志
		 *==============================================================*/
		internal void append_log(string txt, Color color = default)
		{
			if(color == default)
				color = Color.Black;

			ListViewItem LVI = new ListViewItem();
			while(LVI.SubItems.Count < listView_Log.Columns.Count)
				LVI.SubItems.Add("");

			DateTime time = DateTime.Now;

			LVI.SubItems[0].Text = string.Format(	"{0:d4}-{1:d2}-{2:d2} {3:d2}:{4:d2}:{5:d2}",
													time.Year, time.Month, time.Day,
													time.Hour, time.Minute, time.Second );
			LVI.SubItems[1].Text = txt;

			LVI.ForeColor = color;

			listView_Log.Items.Add(LVI);

			LVI.EnsureVisible();
		}

		/*==============================================================
		 * 执行更新数据库的线程
		 *==============================================================*/
		void update_db_thread()
		{
			if(!Directory.Exists(CONFIG.m_s_subs_path))
			{
				FORMS.invoke(() =>
				{
					append_log(	$"{LANGUAGES.txt(56)} {CONFIG.m_s_subs_path}",	// 找不到本地字幕路径
								Color.Red );
					lock_controls(true);
				});

				m_is_updating_database = false;
				return;
			}

			m_sw.Restart();

			long can_refresh_UI_tick = 0;

			DATA.m_s_lock.EnterWriteLock();

			DATA.m_s_all_subs.Clear();

			SortedSet<string> source_list = new SortedSet<string>();

			FORMS.invoke(() =>
			{
				frm_Mainform.m_s_mainform.m_Search.comboBox_Type.Items.Clear();
				frm_Mainform.m_s_mainform.m_Search.comboBox_Type.Items.Add("");

				frm_Mainform.m_s_mainform.m_Search.comboBox_Source.Items.Clear();

				COMMON.SetProgressValue(0);
			});

			string[] dirs_type = Directory.GetDirectories(CONFIG.m_s_subs_path, "*.*", SearchOption.TopDirectoryOnly);
			foreach(string dir_type in dirs_type)
			{
				FORMS.invoke(() =>
				{
					frm_Mainform.m_s_mainform.m_Search.comboBox_Type.Items.Add(Path.GetFileName(dir_type));
				});

				string[] dirs_year = Directory.GetDirectories(dir_type, "*.*", SearchOption.TopDirectoryOnly);
				for(int i_year=0; i_year<dirs_year.Length; ++i_year)
				{
					string dir_year = dirs_year[i_year];

					string[] dirs_video = Directory.GetDirectories(dir_year, "*.*", SearchOption.TopDirectoryOnly);
					for(int i_video=0; i_video<dirs_video.Length; ++i_video)
					{
						string dir_video = dirs_video[i_video];

						// 路径
						string path = dir_video.Substring(CONFIG.m_s_subs_path.Length + 1).Replace("\\", "/");

						FORMS.invoke(() =>
						{
							label_Log.Text = dir_video;
						});

						// 日期
						string name_tmp = Path.GetFileName(dir_video);
						int idx = name_tmp.IndexOf(")");
						string[] date_vals = name_tmp.Substring(1, idx - 1).Split('.');

						int year	= int.Parse(date_vals[0]);
						int month	= (date_vals.Length >= 2) ? int.Parse(date_vals[1]) : 1;
						int day		= (date_vals.Length >= 3) ? int.Parse(date_vals[2]) : 1;

						DateTime date = new DateTime(year, month, day);

						// 番名
						//string name_chs	= name_tmp.Substring(idx + 1);
						string name_chs		= "";
						string name_cht		= "";
						string name_jp		= "";
						string name_en		= "";
						string name_rome	= "";

						// 读取 info.txt
						string info_filename = Path.Combine(dir_video, "info.txt");

						if(File.Exists(info_filename))
						{
							string[] lines = File.ReadAllLines(info_filename, Encoding.UTF8);
							foreach(string line in lines)
							{
								if(line.Length < 2)
									continue;

								if(line[0] == '/' && line[1] == '/')
									continue;

								idx = line.IndexOf(":");
								if(idx < 0)
									continue;

								string w1 = line.Substring(0, idx).Trim().ToLower();
								string w2 = line.Substring(idx + 1).Trim();

								if(w1 == "chs")
								{
									name_chs = w2.Trim();
									continue;
								}

								if(w1 == "cht")
								{
									name_cht = w2.Trim();
									continue;
								}

								if(w1 == "jp")
								{
									name_jp = w2.Trim();
									continue;
								}

								if(w1 == "en")
								{
									name_en = w2.Trim();
									continue;
								}

								if(w1 == "rome")
								{
									name_rome = w2.Trim();
									continue;
								}
							}	// for
						}

						string[] dirs_source = Directory.GetDirectories(dir_video, "*.*", SearchOption.TopDirectoryOnly);
						foreach(string dir_source in dirs_source)
						{
							source_list.Add(Path.GetFileName(dir_source));

							string[] dirs_sub_name = Directory.GetDirectories(dir_source, "*.*", SearchOption.TopDirectoryOnly);
							foreach(string dir_sub_name in dirs_sub_name)
							{
								if(m_is_stopping)
									return;

								string	providers	= "";	// 字幕组/提供者
								string	desc		= "";	// 字幕说明

								// 后缀名
								SortedSet<string> extension_list = new SortedSet<string>();

								string[] files = Directory.GetFiles(dir_sub_name, "*.*", SearchOption.TopDirectoryOnly);
								foreach(string file in files)
								{
									string extension = Path.GetExtension(file).ToLower();
									extension_list.Add(extension);
								}	// for files

								// xxx.txt
								string desc_filename = dir_sub_name + ".txt";
								if(File.Exists(desc_filename))
								{
									string file_txt = File.ReadAllText(desc_filename, Encoding.UTF8);
									idx = file_txt.IndexOf("desc:", StringComparison.CurrentCultureIgnoreCase);
									if(idx > 0)
										desc = file_txt.Substring(idx + 5).Trim();

									string[] lines = File.ReadAllLines(desc_filename, Encoding.UTF8);
									foreach(string line in lines)
									{
										if(line.Length < 2)
											continue;

										if(line[0] == '/' && line[1] == '/')
											continue;

										idx = line.IndexOf(":");
										if(idx < 0)
											continue;

										string w1 = line.Substring(0, idx).Trim().ToLower();
										string w2 = line.Substring(idx + 1).Trim();

										if(w1 == "providers")
										{
											providers = w2.Trim();
											break;
										}
									}	// for
								}

								DATA.c_SubInfo sub_info = new DATA.c_SubInfo();
								DATA.m_s_all_subs.Add(sub_info);

								sub_info.m_name_chs		= name_chs;
								sub_info.m_name_cht		= name_cht;
								sub_info.m_name_jp		= name_jp;
								sub_info.m_name_en		= name_en;
								sub_info.m_name_rome	= name_rome;

								sub_info.m_time			= date;
								sub_info.m_type			= Path.GetFileName(dir_type);
								sub_info.m_source		= Path.GetFileName(dir_source);
								sub_info.m_sub_name		= Path.GetFileName(dir_sub_name);

								foreach(string extension in extension_list)
								{
									if(sub_info.m_extension.Length > 0)
										sub_info.m_extension += ";";

									sub_info.m_extension += extension;
								}

								sub_info.m_providers	= providers;
								sub_info.m_desc			= desc;

								sub_info.m_path			= path;
							}	// for dirs_sub_name
						}	// for dirs_source

						// 进度条
						int progress_value =	COMMON.m_k_MAX_PROGRESS_VALUE * i_year / dirs_year.Length	+
												COMMON.m_k_MAX_PROGRESS_VALUE * (i_video + 1) / (dirs_year.Length * dirs_video.Length);

						FORMS.invoke(() =>
						{
							COMMON.SetProgressValue(progress_value);
						});
					}	// for dirs_video

					if(can_refresh_UI_tick <= m_sw.ElapsedMilliseconds)
					{
						can_refresh_UI_tick = m_sw.ElapsedMilliseconds + 50;	// 50ms 刷新一次界面
						Application.DoEvents();
					}
				}	// for dirs_year
			}	// for dirs_type

			FORMS.invoke(() =>
			{
				foreach(string source in source_list)
					frm_Mainform.m_s_mainform.m_Search.comboBox_Source.Items.Add(source);

				COMMON.SetProgressValue(0);
			});

			DATA.m_s_lock.ExitWriteLock();

			FORMS.invoke(() =>
			{
				m_sw.Stop();

				CONFIG.m_s_last_updata_db_time = DateTime.Now;
				CONFIG.write_config();

				lock_controls(true);

				DATA.data2dt();

				append_log(string.Format(	LANGUAGES.txt(61),	// 正在把数据写入到文件 {0:s} ...
											PATH.m_k_DB_FILENAME ));
				DATA.m_s_dt.WriteXml(PATH.m_k_DB_FILENAME);

				if(m_is_stopping)
				{
					append_log(	string.Format(	LANGUAGES.txt(57) + LANGUAGES.txt(60),	// 用户停止更新数据库（合计 {0:d} 条数据，耗时 {1:s}）
												DATA.m_s_all_subs.Count,
												m_sw.Elapsed.ToString() ),
								Color.Blue );
				}
				else
				{
					append_log(	string.Format(	LANGUAGES.txt(58) + LANGUAGES.txt(60),	// 更新数据库完成（合计 {0:d} 条数据，耗时 {1:s}）
												DATA.m_s_all_subs.Count,
												m_sw.Elapsed.ToString() ),
								Color.Green );
				}

				frm_Mainform.m_s_mainform.m_DataGridView_event_enable	= false;
				frm_Mainform.m_s_mainform.dataGridView_Main.DataSource	= DATA.m_s_dt;
				frm_Mainform.m_s_mainform.update_columns_style();
				frm_Mainform.m_s_mainform.m_DataGridView_event_enable	= true;

				frm_Mainform.m_s_mainform.update_status();

				m_is_stopping = false;
			});

			m_is_updating_database = false;
		}
	};
}	// namespace sub_db
