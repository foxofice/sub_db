using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;

namespace sub_db
{
	public partial class frm_Mainform : Form
	{
		public frm_Mainform()
		{
			InitializeComponent();
		}

		internal static frm_Mainform	m_s_mainform				= null;
		internal frm_UpdateDatabase		m_UpdateDatabase			= new frm_UpdateDatabase();
		internal frm_Search				m_Search					= new frm_Search();
		internal frm_Setting			m_Setting					= new frm_Setting();
		internal frm_About				m_About						= new frm_About();

		// DataGridView 的事件是否有效
		internal bool					m_DataGridView_event_enable	= true;

		#region Winform 事件
		/*==============================================================
		 * 窗口加载时
		 *==============================================================*/
		private void frm_Mainform_Load(object sender, EventArgs e)
		{
			m_s_mainform	= this;

			this.Icon		= IMAGE.img2icon(Resource1.Logo);
			this.Text		= $"{COMMON.m_k_PROGRAM_NAME} {COMMON.m_k_VERSION}";

			m_UpdateDatabase.Owner	= this;

			// 读取配置文件
			CONFIG.read_config();

			// 加载多语言模板
			LANGUAGES.read_languages_list();
			LANGUAGES.change_language_to_default();

			// 加载数据库文件
			DATA.read_data_from_file();
		}

		/*==============================================================
		 * 窗口关闭时
		 *==============================================================*/
		private void frm_Mainform_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = (MessageBox.Show(LANGUAGES.txt(1),    // 是否要退出程序？
										$"{COMMON.m_k_PROGRAM_NAME} {COMMON.m_k_VERSION}",
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Question,
										MessageBoxDefaultButton.Button2) == DialogResult.No);
		}

		/*==============================================================
		 * 调整窗口结束
		 *==============================================================*/
		private void frm_Mainform_ResizeEnd(object sender, EventArgs e)
		{
			CONFIG.m_s_window_width		= this.Width;
			CONFIG.m_s_window_height	= this.Height;
			CONFIG.m_s_window_x			= this.DesktopLocation.X;
			CONFIG.m_s_window_y			= this.DesktopLocation.Y;

			CONFIG.write_config();
		}

		/*==============================================================
		 * 激活窗口时
		 *==============================================================*/
		private void frm_Mainform_Activated(object sender, EventArgs e)
		{
			// Alt + Enter
			COMMON.RegHotKey(this.Handle, (int)COMMON.e_HotKeyID.OpenDir,	COMMON.e_KeyModifiers.Alt,	Keys.Enter);

			// Ctrl + F1
			COMMON.RegHotKey(this.Handle, (int)COMMON.e_HotKeyID.OpenURL,	COMMON.e_KeyModifiers.Ctrl,	Keys.F1);

			// Ctrl + F3
			COMMON.RegHotKey(this.Handle, (int)COMMON.e_HotKeyID.Search,	COMMON.e_KeyModifiers.Ctrl,	Keys.F3);

			// Ctrl + F5
			COMMON.RegHotKey(this.Handle, (int)COMMON.e_HotKeyID.UpdateDB,	COMMON.e_KeyModifiers.Ctrl,	Keys.F5);
		}

		/*==============================================================
		 * 取消激活窗口时
		 *==============================================================*/
		private void frm_Mainform_Deactivate(object sender, EventArgs e)
		{
			for(int i=1; i<(int)COMMON.e_HotKeyID.MAX; ++i)
				COMMON.UnregisterHotKey(this.Handle, i);
		}

		/*==============================================================
		 * Win32 消息处理
		 *==============================================================*/
		protected override void WndProc(ref Message msg)
		{
			const int WM_HOTKEY = 0x312;

			base.WndProc(ref msg);
			switch(msg.Msg)
			{
			case WM_HOTKEY:
				switch(msg.WParam.ToInt32())
				{
				case (int)COMMON.e_HotKeyID.OpenDir:
					ToolStripButton_Folder_Click(null, null);
					break;

				case (int)COMMON.e_HotKeyID.OpenURL:
					ToolStripButton_URL_Click(null, null);
					break;

				case (int)COMMON.e_HotKeyID.Search:
					ToolStripButton_Search_Click(null, null);
					break;

				case (int)COMMON.e_HotKeyID.UpdateDB:
					ToolStripButton_UpdateDB_Click(null, null);
					break;
				}
				break;

			default:
				break;
			}	// switch
		}

		/*==============================================================
		 * 查找（回车）
		 *==============================================================*/
		private void TextBox_Filter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == '\r')
				do_search();
		}

		/*==============================================================
		 * 查找（按钮）
		 *==============================================================*/
		private void PictureBox_Search_Click(object sender, EventArgs e)
		{
			do_search();
		}

		/*==============================================================
		 * 查询语法帮助
		 *==============================================================*/
		private void LinkLabel_FilterHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://www.csharp-examples.net/dataview-rowfilter/");
		}

		/*==============================================================
		 * 调整列宽
		 *==============================================================*/
		private void DataGridView_Main_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			if(!m_DataGridView_event_enable)
				return;

			for(int i=0; i<(int)DATA.e_ColumnName.MAX; ++i)
				CONFIG.m_s_column_width[i] = dataGridView_Main.Columns[((DATA.e_ColumnName)i).ToString()].Width;

			CONFIG.write_config();
		}

		/*==============================================================
		 * 调整列顺序
		 *==============================================================*/
		private void DataGridView_Main_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
		{
			if(!m_DataGridView_event_enable)
				return;

			for(int i=0; i<(int)DATA.e_ColumnName.MAX; ++i)
				CONFIG.m_s_column_idx[i] = dataGridView_Main.Columns[((DATA.e_ColumnName)i).ToString()].DisplayIndex;

			CONFIG.write_config();
		}
		#endregion

		#region 顶部菜单
		/*==============================================================
		 * 更新数据库
		 *==============================================================*/
		private void ToolStripButton_UpdateDB_Click(object sender, EventArgs e)
		{
			FORMS.active_form(m_UpdateDatabase);
		}

		/*==============================================================
		 * 高级查找
		 *==============================================================*/
		private void ToolStripButton_Search_Click(object sender, EventArgs e)
		{
			FORMS.active_form(m_Search);
		}

		/*==============================================================
		 * 设置
		 *==============================================================*/
		private void ToolStripButton_Settings_Click(object sender, EventArgs e)
		{
			FORMS.active_form(m_Setting);
		}

		/*==============================================================
		 * 关于
		 *==============================================================*/
		private void ToolStripButton_About_Click(object sender, EventArgs e)
		{
			FORMS.active_form(m_About);
		}

		/*==============================================================
		 * 打开本地文件夹
		 *==============================================================*/
		private void ToolStripButton_Folder_Click(object sender, EventArgs e)
		{
			if(dataGridView_Main.SelectedCells.Count == 0)
				return;

			DataTable dt = (DataTable)dataGridView_Main.DataSource;
			if(dt == null)
				return;

			DataRow dr = ((DataRowView)dataGridView_Main.SelectedCells[0].OwningRow.DataBoundItem).Row;

			string dir = string.Format("{0:s}/{1:s}/{2:s}/{3:s}",
										CONFIG.m_s_subs_path.Replace("\\", "/"),
										(string)dr[DATA.e_ColumnName.path.ToString()],
										(string)dr[DATA.e_ColumnName.source.ToString()],
										(string)dr[DATA.e_ColumnName.sub_name.ToString()]);

			if(!Directory.Exists(dir))
			{
				MessageBox.Show(string.Format(LANGUAGES.txt(25), dir));	// 找不到文件夹 {0:s}
				return;
			}

			PATH.open_dir(dir);
		}

		/*==============================================================
		 * 打开远程链接
		 *==============================================================*/
		private void ToolStripButton_URL_Click(object sender, EventArgs e)
		{
			if(dataGridView_Main.SelectedCells.Count == 0)
				return;

			DataTable dt = (DataTable)dataGridView_Main.DataSource;
			if(dt == null)
				return;

			DataRow dr = ((DataRowView)dataGridView_Main.SelectedCells[0].OwningRow.DataBoundItem).Row;

			string dir = string.Format("{0:s}/{1:s}/{2:s}",
										(string)dr[DATA.e_ColumnName.path.ToString()],
										(string)dr[DATA.e_ColumnName.source.ToString()],
										(string)dr[DATA.e_ColumnName.sub_name.ToString()]);
			dir = Uri.EscapeDataString(dir);

			Process.Start($"https://github.com/foxofice/sub_share/tree/master/subs_list/{dir}");
		}
		#endregion

		/*==============================================================
		 * 更新 dataGridView_Main 的各列样式
		 *==============================================================*/
		internal void	update_columns_style()
		{
			m_DataGridView_event_enable = false;

			for(int i=0; i<CONFIG.m_s_column_width.Length; ++i)
			{
				if(CONFIG.m_s_column_width[i] > 0)
					dataGridView_Main.Columns[((DATA.e_ColumnName)i).ToString()].Width = CONFIG.m_s_column_width[i];
			}

			SortedDictionary<int, string> sort_list = new SortedDictionary<int, string>();

			for(int i=0; i<CONFIG.m_s_column_idx.Length; ++i)
			{
				if(CONFIG.m_s_column_idx[i] >= 0)
					sort_list.Add(CONFIG.m_s_column_idx[i], ((DATA.e_ColumnName)i).ToString());
			}

			foreach(var kvp in sort_list)
				dataGridView_Main.Columns[kvp.Value].DisplayIndex = kvp.Key;

			m_DataGridView_event_enable = true;
		}

		/*==============================================================
		 * 根据条件查找数据
		 *==============================================================*/
		internal void	do_search()
		{
			DATA.m_s_lock.EnterReadLock();

			if(DATA.m_s_all_subs.Count == 0)
			{
				DATA.m_s_lock.ExitReadLock();

				if(!m_UpdateDatabase.m_is_updating_database)
				{
					if(MessageBox.Show(	LANGUAGES.txt(26),	// 本地没有任何数据，是否要下载最新的字幕索引？
										$"{COMMON.m_k_PROGRAM_NAME} {COMMON.m_k_VERSION}",
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Question,
										MessageBoxDefaultButton.Button2 ) == DialogResult.Yes)
					{
						FORMS.active_form(m_UpdateDatabase);

						m_UpdateDatabase.radioButton_UseRemoteData.Checked = true;
						m_UpdateDatabase.PictureBox_Start_Click(null, null);
					}
				}

				return;
			}

			if(textBox_Filter.TextLength == 0)
			{
				m_DataGridView_event_enable = false;
				dataGridView_Main.DataSource = DATA.m_s_dt;
				update_columns_style();
				m_DataGridView_event_enable = true;
			}
			else
			{
				string filter_string;

				if(radioButton_SearchByName.Checked)
				{
					StringBuilder sb = new StringBuilder();

					string fix_Name_chs = SQL.fix_string(ChineseConverter.Convert(textBox_Filter.Text, ChineseConversionDirection.TraditionalToSimplified));
					string fix_Name_cht = SQL.fix_string(ChineseConverter.Convert(textBox_Filter.Text, ChineseConversionDirection.SimplifiedToTraditional));

					sb.Append($"[name_chs] like '%{fix_Name_chs}%' or [name_chs] like '%{fix_Name_cht}%' or ");
					sb.Append($"[name_cht] like '%{fix_Name_chs}%' or [name_cht] like '%{fix_Name_cht}%' or ");
					sb.Append($"[name_jp] like '%{fix_Name_chs}%' or [name_jp] like '%{fix_Name_cht}%' or ");
					sb.Append($"[name_en] like '%{fix_Name_chs}%' or ");
					sb.Append($"[name_rome] like '%{fix_Name_chs}%'");

					filter_string = sb.ToString();
				}
				else
					filter_string = textBox_Filter.Text;

				try
				{
					DataRow[] dr_list = DATA.m_s_dt.Select(filter_string);

					DATA.m_s_dt_search.Rows.Clear();
					foreach(DataRow dr in dr_list)
					{
						DataRow dr_tmp = DATA.m_s_dt_search.NewRow();
						for(int i=0; i<DATA.m_s_dt_search.Columns.Count; ++i)
							dr_tmp[i] = dr[i];

						DATA.m_s_dt_search.Rows.Add(dr_tmp);
					}

					m_DataGridView_event_enable = false;
					dataGridView_Main.DataSource = DATA.m_s_dt_search;
					update_columns_style();
					m_DataGridView_event_enable = true;
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}

			DATA.m_s_lock.ExitReadLock();

			update_status();
		}

		/*==============================================================
		 * 更新状态栏
		 *==============================================================*/
		internal void	update_status()
		{
			toolStripStatusLabel_ItemsCount.Text = string.Format(	LANGUAGES.txt(23),	// {0:d} 条记录
																	dataGridView_Main.Rows.Count );

			DataTable dt = (DataTable)dataGridView_Main.DataSource;
			if(dt != null)
			{
				HashSet<string> movies = new HashSet<string>();

				foreach(DataRow dr in dt.Rows)
					movies.Add((string)dr[DATA.e_ColumnName.path.ToString()]);

				toolStripStatusLabel_MovieCount.Text = string.Format(	LANGUAGES.txt(24),	// {0:d} 部影片
																		movies.Count );
			}
		}
	};
}	// namespace sub_db
