using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sub_db
{
	public partial class frm_UpdateDatabase : Form
	{
		List<TabPage>				m_TabPages				= new();

		internal bool				m_is_updating_database	= false;	// 是否正在更新数据库

		internal bool				m_is_stopping			= false;	// 是否正在停止扫描
		CancellationTokenSource?	m_cts;								// 取消下载的 cts

		Stopwatch					m_sw					= new();

		class WORK_PARAMS
		{
			// 扫描
			internal static bool			m_s_scan_all				= false;
			internal static bool			m_s_scan_Partial_types		= false;
			internal static HashSet<string>	m_s_Scan_Types				= new();
			internal static bool			m_s_scan_Partial_years		= false;
			internal static HashSet<int>	m_s_Scan_Years				= new();

			// 下载线程数
			internal static int				m_s_download_threads_count	= 4;
		};

		public frm_UpdateDatabase()
		{
			InitializeComponent();

			foreach(TabPage tp in tabControl_Main.TabPages)
				m_TabPages.Add(tp);
		}

		#region Winform 事件
		/*==============================================================
		 * 窗口加载/窗口关闭
		 *==============================================================*/
		private void frm_UpdateDatabase_Load(object sender, EventArgs e)
		{
			this.Icon = IMAGE.get_exe_icon();

			radioButton_UseLocalData.Checked	= true;
			radioButton_Local_ScanAll.Checked	= true;

			update_Type_List();
		}
		//--------------------------------------------------
		private void frm_UpdateDatabase_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		/*==============================================================
		 * 本地/远程 切换
		 *==============================================================*/
		private void radioButton_UseLocalData_CheckedChanged(object sender, EventArgs e)
		{
			tabControl_Main.TabPages.Clear();
			tabControl_Main.TabPages.Add(m_TabPages[radioButton_UseLocalData.Checked ? 0 : 1]);

			// 350: 开始扫描
			// 352: 开始下载
			button_Start.Text	= radioButton_UseLocalData.Checked ? LANGUAGES.txt(350) : LANGUAGES.txt(352);

			// 351: 停止扫描
			// 353: 停止下载
			button_Stop.Text	= radioButton_UseLocalData.Checked ? LANGUAGES.txt(351) : LANGUAGES.txt(353);
		}

		/*==============================================================
		 * 全部扫描/部分扫描
		 *==============================================================*/
		private void radioButton_Local_Scan_Partial_CheckedChanged(object sender, EventArgs e)
		{
			checkBox_Local_Scan_Partial_Type.Enabled		= radioButton_Local_Scan_Partial.Checked;
			checkedListBox_Local_Scan_Partial_Type.Enabled	= radioButton_Local_Scan_Partial.Checked && checkBox_Local_Scan_Partial_Type.Checked;

			checkBox_Local_Scan_Partial_Years.Enabled		= radioButton_Local_Scan_Partial.Checked;
			pictureBox_Local_Scan_Partial_Type.Enabled		= radioButton_Local_Scan_Partial.Checked;
			textBox_Local_Scan_Partial_Years.ReadOnly		= !radioButton_Local_Scan_Partial.Checked || !checkBox_Local_Scan_Partial_Years.Checked;
		}

		/*==============================================================
		 * 类型
		 *==============================================================*/
		private void checkBox_Local_Scan_Partial_Type_CheckedChanged(object sender, EventArgs e)
		{
			checkedListBox_Local_Scan_Partial_Type.Enabled	= radioButton_Local_Scan_Partial.Checked && checkBox_Local_Scan_Partial_Type.Checked;
		}

		/*==============================================================
		 * 年份
		 *==============================================================*/
		private void checkBox_Local_Scan_Partial_Years_CheckedChanged(object sender, EventArgs e)
		{
			textBox_Local_Scan_Partial_Years.ReadOnly = !checkBox_Local_Scan_Partial_Years.Checked;
		}

		/*==============================================================
		 * 开始扫描/开始下载
		 *==============================================================*/
		private void button_Start_Click(object sender, EventArgs e)
		{
			m_is_updating_database				= true;
			m_is_stopping						= false;

			toolStripProgressBar_Update.Value	= 0;
			toolStripStatusLabel_Log.Text		= "";

			lock_controls(false);

			//========== 更新 WORK_PARAMS ==========(Start)
			WORK_PARAMS.m_s_scan_all			= radioButton_Local_ScanAll.Checked;

			WORK_PARAMS.m_s_scan_Partial_types	= checkBox_Local_Scan_Partial_Type.Checked;

			if(WORK_PARAMS.m_s_scan_Partial_types)
			{
				WORK_PARAMS.m_s_Scan_Types.Clear();

				for(int i=0; i<checkedListBox_Local_Scan_Partial_Type.Items.Count; ++i)
				{
					if(checkedListBox_Local_Scan_Partial_Type.GetItemChecked(i))
						WORK_PARAMS.m_s_Scan_Types.Add(checkedListBox_Local_Scan_Partial_Type.Items[i].ToString()!);
				}	// for
			}

			WORK_PARAMS.m_s_scan_Partial_years	= checkBox_Local_Scan_Partial_Years.Checked;

			if(WORK_PARAMS.m_s_scan_Partial_years)
			{
				WORK_PARAMS.m_s_Scan_Years.Clear();

				string[] vals_years = textBox_Local_Scan_Partial_Years.Text.Split(',');
				foreach(string val in vals_years)
				{
					if(val.Contains("-"))
					{
						string[] vals = val.Split("-");

						if(int.TryParse(vals[0], out int min_year) && int.TryParse(vals[1], out int max_year))
						{
							for(int year = min_year; year <= max_year; ++year)
								WORK_PARAMS.m_s_Scan_Years.Add(year);
						}
					}
					else
					{
						if(int.TryParse(val, out int year))
							WORK_PARAMS.m_s_Scan_Years.Add(year);
					}
				}	// for
			}

			WORK_PARAMS.m_s_download_threads_count = (int)numericUpDown_Remote_Download_Threads.Value;
			//========== 更新 WORK_PARAMS ==========(End)

			if(radioButton_UseLocalData.Checked)
				start_scan();
			else
				start_download();
		}

		/*==============================================================
		 * 停止扫描/停止下载
		 *==============================================================*/
		private void button_Stop_Click(object sender, EventArgs e)
		{
			if(radioButton_UseLocalData.Checked)
				stop_scan();
			else
				stop_download();
		}
		#endregion

		/*==============================================================
		 * 刷新 Type 列表
		 *==============================================================*/
		private void pictureBox_Local_Scan_Partial_Type_Click(object sender, EventArgs e)
		{
			update_Type_List();
		}

		/*==============================================================
		 * 锁定控件
		 *==============================================================*/
		void lock_controls(bool enabled)
		{
			radioButton_UseLocalData.Enabled				= enabled;
			radioButton_UseRemoteData.Enabled				= enabled;

			radioButton_Local_ScanAll.Enabled				= enabled;
			radioButton_Local_Scan_Partial.Enabled			= enabled;
			checkedListBox_Local_Scan_Partial_Type.Enabled	= enabled && radioButton_Local_Scan_Partial.Checked && checkBox_Local_Scan_Partial_Type.Checked;
			pictureBox_Local_Scan_Partial_Type.Enabled		= checkedListBox_Local_Scan_Partial_Type.Enabled;
			textBox_Local_Scan_Partial_Years.ReadOnly		= !enabled || radioButton_Local_ScanAll.Checked || !checkBox_Local_Scan_Partial_Years.Checked;

			numericUpDown_Remote_Download_Threads.Enabled	= enabled;

			button_Start.Enabled							= enabled;
			button_Stop.Enabled								= !enabled;

			toolStripProgressBar_Update.Visible				= !enabled;
			toolStripStatusLabel_Log.Visible				= !enabled;
		}



		#region 扫描
		/*==============================================================
		 * 开始扫描
		 *==============================================================*/
		void start_scan()
		{
			COMMON.add_log(LANGUAGES.txt(360));	// 360: 执行数据库更新……

			Thread th = new(scan_thread);
			th.Start();
		}

		/*==============================================================
		 * 停止扫描
		 *==============================================================*/
		void stop_scan()
		{
			m_is_stopping = true;
		}

		/*==============================================================
		 * 扫描本地数据的线程
		 *==============================================================*/
		void scan_thread()
		{
			if(!Directory.Exists(CONFIG.SUBS.m_s_path))
			{
				// 361: 找不到本地字幕路径 {0:s}
				COMMON.add_log(string.Format(LANGUAGES.txt(361), CONFIG.SUBS.m_s_path), Color.Red);

				FORMS.invoke(() =>
				{
					lock_controls(true);
				});

				m_is_updating_database = false;
				return;
			}

			m_sw.Restart();

			List<(string m_movie_path, string m_type, int m_year)> sub_dir_list = new();

			List<DATA.c_SubInfo>	all_subs	= new();
			SortedSet<string>		source_list	= new();

			string[] dirs_type = Directory.GetDirectories(CONFIG.SUBS.m_s_path, "*.*", SearchOption.TopDirectoryOnly);

			foreach(string dir_type in dirs_type)
			{
				string type = Path.GetFileName(dir_type);

				if(!WORK_PARAMS.m_s_scan_all && WORK_PARAMS.m_s_scan_Partial_types && !WORK_PARAMS.m_s_Scan_Types.Contains(type))
					continue;

				string[] dirs_year = Directory.GetDirectories(dir_type, "*.*", SearchOption.TopDirectoryOnly);
				foreach(string dir_year in dirs_year)
				{
					int year = int.Parse(Path.GetFileName(dir_year));

					if(!WORK_PARAMS.m_s_scan_all && WORK_PARAMS.m_s_scan_Partial_years && !WORK_PARAMS.m_s_Scan_Years.Contains(year))
						continue;

					string[] dirs_movie = Directory.GetDirectories(dir_year, "*.*", SearchOption.TopDirectoryOnly);
					foreach(string dir_movie in dirs_movie)
						sub_dir_list.Add((dir_movie, type, year));
				}	// for
			}	// for

			FORMS.invoke(() =>
			{
				toolStripProgressBar_Update.Value	= 0;
				toolStripProgressBar_Update.Maximum	= sub_dir_list.Count;
			});

			// 开始扫描
			for(int i=0; i<sub_dir_list.Count; ++i)
			{
				var sub_dir = sub_dir_list[i];

				FORMS.invoke(() =>
				{
					toolStripStatusLabel_Log.Text		= sub_dir.m_movie_path.Substring(CONFIG.SUBS.m_s_path.Length);
					toolStripProgressBar_Update.Value	= i + 1;
					TASK_BAR.SetProgressValue((ulong)(i + 1), (ulong)sub_dir_list.Count);
				});

				// 日期
				string	dir_name	= Path.GetFileName(sub_dir.m_movie_path);
				int		idx			= dir_name.IndexOf(")");
				string[] date_vals	= dir_name.Substring(1, idx - 1).Split('.');

				int	year	= int.Parse(date_vals[0]);
				int	month	= (date_vals.Length >= 2) ? int.Parse(date_vals[1]) : 1;
				int	day		= (date_vals.Length >= 3) ? int.Parse(date_vals[2]) : 1;

				DateTime date = new(year, month, day);

				// 番名
				string name_chs		= "";
				string name_cht		= "";
				string name_jp		= "";
				string name_en		= "";
				string name_rome	= "";

				// 读取 info.txt
				string info_filename = Path.Combine(sub_dir.m_movie_path, "info.txt");

				if(!File.Exists(info_filename))
				{
					// 362: 缺少 {0:s}
					COMMON.add_log($"[Warning] {string.Format(LANGUAGES.txt(362), info_filename)}", Color.DarkOrange);
				}
				else
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

						string w1 = line.Substring(0, idx).Trim();
						string w2 = line.Substring(idx + 1).Trim();

						if(string.Compare(w1, "chs", true) == 0)
						{
							name_chs = w2;
							continue;
						}

						if(string.Compare(w1, "cht", true) == 0)
						{
							name_cht = w2;
							continue;
						}

						if(string.Compare(w1, "jp", true) == 0)
						{
							name_jp = w2;
							continue;
						}

						if(string.Compare(w1, "en", true) == 0)
						{
							name_en = w2;
							continue;
						}

						if(string.Compare(w1, "rome", true) == 0)
						{
							name_rome = w2.Trim();
							continue;
						}
					}   // for
				}

				string[] dirs_source = Directory.GetDirectories(sub_dir.m_movie_path, "*.*", SearchOption.TopDirectoryOnly);
				foreach(string dir_source in dirs_source)
				{
					string source = Path.GetFileName(dir_source);
					source_list.Add(source);

					string[] dirs_sub_name = Directory.GetDirectories(dir_source, "*.*", SearchOption.TopDirectoryOnly);
					foreach(string dir_sub_name in dirs_sub_name)
					{
						if(m_is_stopping)
						{
							m_sw.Stop();

							// 363: 用户停止更新数据库（耗时 {0:s}）
							COMMON.add_log(string.Format(LANGUAGES.txt(363), m_sw.Elapsed.ToString()), Color.Blue);

							FORMS.invoke(() =>
							{
								lock_controls(true);
							});

							m_is_stopping = false;
							return;
						}

						string providers	= "";	// 字幕组/提供者
						string desc			= "";	// 字幕说明

						// 后缀名
						SortedSet<string> extension_list = new();

						string[] files = Directory.GetFiles(dir_sub_name, "*.*", SearchOption.AllDirectories);
						foreach(string file in files)
						{
							string extension = Path.GetExtension(file);
							extension_list.Add(extension.ToLower());
						}   // for files

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

								string w1 = line.Substring(0, idx).Trim();
								string w2 = line.Substring(idx + 1).Trim();

								if(string.Compare(w1, "providers", true) == 0)
								{
									providers = w2;
									break;
								}
							}   // for
						}

						DATA.c_SubInfo sub_info = new();
						all_subs.Add(sub_info);

						sub_info.m_name_chs		= name_chs;
						sub_info.m_name_cht		= name_cht;
						sub_info.m_name_jp		= name_jp;
						sub_info.m_name_en		= name_en;
						sub_info.m_name_rome	= name_rome;

						sub_info.m_time			= date;
						sub_info.m_type			= sub_dir.m_type;
						sub_info.m_source		= source;
						sub_info.m_sub_name		= Path.GetFileName(dir_sub_name);

						foreach(string extension in extension_list)
						{
							if(sub_info.m_extension.Length > 0)
								sub_info.m_extension += ";";

							sub_info.m_extension += extension;
						}	// for

						sub_info.m_providers	= providers;
						sub_info.m_desc			= desc;

						sub_info.m_path			= sub_dir.m_movie_path.Substring(CONFIG.SUBS.m_s_path.Length);
						if(sub_info.m_path[0] == '\\' || sub_info.m_path[0] == '/')
							sub_info.m_path = sub_info.m_path.Substring(1);
					}	// for
				}	// for
			}	// for

			CONFIG.SUBS.m_s_last_update_time	= DateTime.Now;
			CONFIG.m_s_dirty					= true;

			m_sw.Stop();

			if(WORK_PARAMS.m_s_scan_all)
			{
				DATA.m_s_all_subs		= all_subs;
				DATA.m_s_source_list	= source_list;
			}
			else
			{
				if(!WORK_PARAMS.m_s_scan_Partial_types && !WORK_PARAMS.m_s_scan_Partial_years)
					DATA.m_s_all_subs = all_subs;
				else
				{
					DATA.m_s_all_subs.RemoveAll((DATA.c_SubInfo sub_info) =>
					{
						if(WORK_PARAMS.m_s_scan_Partial_types && !WORK_PARAMS.m_s_Scan_Types.Contains(sub_info.m_type))
							return false;

						if(WORK_PARAMS.m_s_scan_Partial_years && !WORK_PARAMS.m_s_Scan_Years.Contains(sub_info.m_time.Year))
							return false;

						return true;
					});

					DATA.m_s_all_subs.AddRange(all_subs);
				}
			}

			// 排序
			DATA.m_s_all_subs.Sort((DATA.c_SubInfo info1, DATA.c_SubInfo info2) =>
			{
				if(info1.m_path != info2.m_path)
					return COMMON.StrCmpLogicalW(info1.m_path, info2.m_path);

				if(info1.m_source != info2.m_source)
					return COMMON.StrCmpLogicalW(info1.m_source, info2.m_source);

				return COMMON.StrCmpLogicalW(info1.m_sub_name, info2.m_sub_name);
			});

			// 364: 更新数据库完成（扫描 {0:d} 条数据，全部 {1:d} 条数据，耗时 {2:s}）
			COMMON.add_log(	string.Format(LANGUAGES.txt(364), all_subs.Count, DATA.m_s_all_subs.Count, m_sw.Elapsed.ToString()),
							Color.Green );

			FORMS.invoke(() =>
			{
				DATA.Data_to_DT();
			});

			DATA.m_s_dt.WriteXml(DATA.m_k_DB_FILENAME);
			COMMON.add_log(string.Format(LANGUAGES.txt(365), DATA.m_k_DB_FILENAME));	// 365: 写入数据到文件 {0:s} 完成

			FORMS.invoke(() =>
			{
				lock_controls(true);

				frm_Mainform.m_s_mainform.update_DataGridView();
				frm_Mainform.m_s_mainform.m_Search.update_Source_List();
			});

			m_is_updating_database = false;
		}
		#endregion

		#region 下载
		/*==============================================================
		 * 开始下载
		 *==============================================================*/
		async void start_download()
		{
			COMMON.add_log(LANGUAGES.txt(366));	// 366: 正在从远程服务器下载 db.xml ……

			c_HttpClient client = new();

			client.ProgressChanged		+= Client_ProgressChanged;
			client.DownloadCompleted	+= Client_DownloadCompleted;

			m_cts = new();

			m_sw.Restart();

			try
			{
				var task = client.DownloadFileAsync("https://github.com/foxofice/sub_share/raw/master/Subtitles DataBase/Files/db.xml",
													DATA.m_k_DB_FILENAME,
													m_cts.Token);
				await task;
			}
			catch(OperationCanceledException ex)
			{
				COMMON.add_log($"[Error] {ex.Message}", Color.Red);
			}
			catch(Exception ex)
			{
				COMMON.add_log($"[Error] {ex.Message}", Color.Red);
			}

			CONFIG.SUBS.m_s_last_update_time	= DateTime.Now;
			CONFIG.m_s_dirty					= true;

			// 加载数据
			DATA.read_data_from_file();

			frm_Mainform.m_s_mainform.update_DataGridView();
			lock_controls(true);

			m_is_updating_database = false;
		}

		private void Client_DownloadCompleted(object? sender, DownloadCompletedEventArgs e)
		{
			if(e.Success)
			{
				// 367: 下载 db.xml 完成
				COMMON.add_log(LANGUAGES.txt(367), Color.Green);
			}
			else
			{
				// 368: 下载 db.xml 失败（{0:s}）
				COMMON.add_log($"[Error] {string.Format(LANGUAGES.txt(368), e.Exception?.Message)}", Color.Red);
			}
		}

		private void Client_ProgressChanged(object? sender, DownloadProgressEventArgs e)
		{
			FORMS.invoke(() =>
			{
				toolStripStatusLabel_Log.Text		= $"{e.BytesReceived}/{e.TotalBytesToReceive} ({e.ProgressPercentage}%)";
				toolStripProgressBar_Update.Maximum	= (int)e.TotalBytesToReceive;
				toolStripProgressBar_Update.Value	= (int)e.BytesReceived;
				TASK_BAR.SetProgressValue((ulong)e.TotalBytesToReceive, (ulong)e.BytesReceived);
			});
		}

		/*==============================================================
		 * 停止下载
		 *==============================================================*/
		void stop_download()
		{
			m_cts!.Cancel();
		}
		#endregion

		/*==============================================================
		 * 更新 Type 列表
		 *==============================================================*/
		internal void update_Type_List()
		{
			// type -> Checked
			Dictionary<string, bool> checked_list = new();

			// 记录 Checked 状态
			for(int i=0; i<checkedListBox_Local_Scan_Partial_Type.Items.Count; ++i)
				checked_list.Add(checkedListBox_Local_Scan_Partial_Type.Items[i].ToString()!, checkedListBox_Local_Scan_Partial_Type.GetItemChecked(i));

			checkedListBox_Local_Scan_Partial_Type.Items.Clear();

			string[] dirs_type = DATA.get_types(false);

			foreach(string dir in dirs_type)
			{
				string	name		= Path.GetFileName(dir);
				bool	is_checked	= false;

				if(!checked_list.TryGetValue(name, out is_checked))
					is_checked = false;

				checkedListBox_Local_Scan_Partial_Type.Items.Add(name, is_checked);
			}	// for
		}

		/*==============================================================
		 * 下载 db.xml
		 *==============================================================*/
		internal void download_db_xml()
		{
			radioButton_UseRemoteData.Checked = true;
			button_Start.PerformClick();
		}

		#region 多语言
		/*==============================================================
		 * 更新多语言文本
		 *==============================================================*/
		internal void update_language_text()
		{
			this.Text								= LANGUAGES.txt(300);	// 300: 更新数据库
			radioButton_UseLocalData.Text			= LANGUAGES.txt(301);	// 301: 本地字幕数据 -> db.xml
			radioButton_UseRemoteData.Text			= LANGUAGES.txt(302);	// 302: 远程 db.xml -> db.xml

			tabPage_Local.Text						= LANGUAGES.txt(310);	// 310: 本地扫描设置
			tabPage_Remote.Text						= LANGUAGES.txt(311);	// 311: 远程下载设置

			radioButton_Local_ScanAll.Text			= LANGUAGES.txt(320);	// 320: 全部扫描
			radioButton_Local_Scan_Partial.Text		= LANGUAGES.txt(321);	// 321: 部分扫描
			groupBox_Local_Scan_Partial.Text		= LANGUAGES.txt(322);	// 322: 部分扫描设置
			checkBox_Local_Scan_Partial_Type.Text	= LANGUAGES.txt(323);	// 323: 类型
			checkBox_Local_Scan_Partial_Years.Text	= LANGUAGES.txt(324);	// 324: 年份

			label_Remote_Download_Threads.Text		= LANGUAGES.txt(330);	// 330: 下载线程数：

			// 350: 开始扫描
			// 352: 开始下载
			button_Start.Text						= radioButton_UseLocalData.Checked ? LANGUAGES.txt(350) : LANGUAGES.txt(352);

			// 351: 停止扫描
			// 353: 停止下载
			button_Stop.Text						= radioButton_UseLocalData.Checked ? LANGUAGES.txt(351) : LANGUAGES.txt(353);
		}
		#endregion
	};
}	// namespace sub_db
