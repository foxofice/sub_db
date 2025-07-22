using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using Microsoft.VisualBasic.Logging;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace sub_db
{
	public partial class frm_Mainform : Form
	{
		#region ����/����
		internal static frm_Mainform	m_s_mainform				= null!;

		internal frm_About				m_About						= new();
		internal frm_Log				m_Log						= new();
		internal frm_Search				m_Search					= new();
		internal frm_UpdateDatabase		m_UpdateDatabase			= new();

		// DataGridView ���¼��Ƿ���Ч
		internal bool					m_DataGridView_event_enable	= false;
		#endregion

		#region ����
		/*==============================================================
		 * ���� dataGridView_Main �ĸ�����ʽ
		 *==============================================================*/
		internal void update_columns_style()
		{
			if(dataGridView_Main.Columns.Count == 0)
				return;

			bool DataGridView_event_enable = m_DataGridView_event_enable;
			m_DataGridView_event_enable = false;

			for(int i = 0; i < CONFIG.DATA_GRID_VIEW.m_s_Widths.Length; ++i)
			{
				if(CONFIG.DATA_GRID_VIEW.m_s_Widths[i] > 0)
					dataGridView_Main.Columns[((DATA.e_Column)i).ToString()]!.Width = CONFIG.DATA_GRID_VIEW.m_s_Widths[i];
			}	// for

			// idx -> ����
			SortedDictionary<int, string> sort_list = new();

			for(int i = 0; i < CONFIG.DATA_GRID_VIEW.m_s_Indices.Length; ++i)
			{
				if(CONFIG.DATA_GRID_VIEW.m_s_Indices[i] >= 0)
					sort_list.Add(CONFIG.DATA_GRID_VIEW.m_s_Indices[i], ((DATA.e_Column)i).ToString());
			}	// for

			foreach(var kvp in sort_list)
				dataGridView_Main.Columns[kvp.Value]!.DisplayIndex = kvp.Key;

			m_DataGridView_event_enable = DataGridView_event_enable;
		}

		/*==============================================================
		 * ���� SQL �ַ���
		 *==============================================================*/
		internal void set_SQL_filter(string txt)
		{
			radioButton_SearchBySQL.Checked	= true;
			textBox_Filter.Text				= txt;
		}

		/*==============================================================
		 * ���� dataGridView_Main.DataSource
		 *==============================================================*/
		void set_DataSource(DataTable dt)
		{
			bool DataGridView_event_enable = m_DataGridView_event_enable;
			m_DataGridView_event_enable = false;

			dataGridView_Main.DataSource = dt;

			m_DataGridView_event_enable = DataGridView_event_enable;
		}

		/*==============================================================
		 * ����������������
		 *==============================================================*/
		internal void do_search()
		{
			if(DATA.m_s_all_subs.Count == 0)
			{
				if(!m_UpdateDatabase.m_is_updating_database)
				{
					if(MessageBox.Show(	LANGUAGES.txt(450),	// 450: ����û���κ����ݣ��Ƿ�Ҫ�������µ� db.xml��
										$"{COMMON.m_k_PROGRAM_NAME} {COMMON.m_k_VERSION}",
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Question,
										MessageBoxDefaultButton.Button2 ) == DialogResult.Yes)
					{
						FORMS.active_form(m_UpdateDatabase);

						m_UpdateDatabase.download_db_xml();
					}
				}

				return;
			}

			if(textBox_Filter.TextLength == 0)
			{
				set_DataSource(DATA.m_s_dt);

				update_columns_style();
			}
			else
			{
				string filter_string;

				if(radioButton_SearchByName.Checked)
				{
					StringBuilder sb = new();

					string			fix_Name	= SQL.escape(textBox_Filter.Text);
					List<string>	list		= COMMON.GenerateSimplifiedTraditionalCombinations(fix_Name);

					sb.Append("(");

					foreach(string s in list)
					{
						sb.Append($"[name_chs] LIKE '%{s}%' OR ");
						sb.Append($"[name_cht] LIKE '%{s}%' OR ");
					}	// for

					sb.Append($"[name_jp] LIKE '%{fix_Name}%' OR ");
					sb.Append($"[name_en] LIKE '%{fix_Name}%' OR ");
					sb.Append($"[name_rome] LIKE '%{fix_Name}%')");

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

						for(int i = 0; i < DATA.m_s_dt_search.Columns.Count; ++i)
							dr_tmp[i] = dr[i];

						DATA.m_s_dt_search.Rows.Add(dr_tmp);
					}	// for

					set_DataSource(DATA.m_s_dt_search);

					update_columns_style();
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}

			update_status_bar();
		}

		/*==============================================================
		 * ����״̬��
		 *==============================================================*/
		internal void update_status_bar()
		{
			// 451: {0:d} ����¼
			toolStripStatusLabel_ItemsCount.Text = string.Format(LANGUAGES.txt(451), dataGridView_Main.Rows.Count);

			DataTable? dt = (DataTable?)dataGridView_Main.DataSource;
			if(dt != null)
			{
				HashSet<string> movies = new();

				foreach(DataRow dr in dt.Rows)
					movies.Add((string)dr[DATA.e_Column.path.ToString()]);

				// 452: {0:d} ������
				toolStripStatusLabel_MovieCount.Text = string.Format(LANGUAGES.txt(452), movies.Count);
			}
		}

		/*==============================================================
		 * ���� DataGridView
		 *==============================================================*/
		internal void update_DataGridView()
		{
			set_DataSource(DATA.m_s_dt);

			update_columns_style();
			update_status_bar();
		}
		#endregion

		#region ������
		// ��ǰѡ��� ToolStripMenuItem
		ToolStripMenuItem? m_current_language_ToolStripMenuItem = null;

		/*==============================================================
		 * �л�������
		 *==============================================================*/
		private void ToolStripMenuItem_Language_Click(object? sender, EventArgs e)
		{
			ToolStripMenuItem new_item = (ToolStripMenuItem)sender!;

			if(new_item.Checked)
				return;

			if(m_current_language_ToolStripMenuItem != null)
				m_current_language_ToolStripMenuItem.Checked = false;

			LANGUAGES.set_language(Get_Tag__Language(new_item));
			update_language_text();

			new_item.Checked = true;

			m_current_language_ToolStripMenuItem = new_item;
		}

		/*==============================================================
		 * ���¶������ı�
		 *==============================================================*/
		void update_language_text()
		{
			toolStripButton_UpdateDB.Text		= $"{LANGUAGES.txt(400)}(F5)";			// 400: �������ݿ�
			toolStripButton_Folder.Text			= $"{LANGUAGES.txt(401)}(Alt+Enter)";	// 401: �򿪱����ļ���
			toolStripButton_URL.Text			= $"{LANGUAGES.txt(402)}(F1)";			// 402: ��Զ������
			toolStripButton_Search.Text			= $"{LANGUAGES.txt(403)}(F3)";			// 403: �߼�����
			toolStripButton_Log.Text			= $"{LANGUAGES.txt(404)}(F4)";			// 404: ��־
			toolStripSplitButton_Languages.Text	= LANGUAGES.txt(405);					// 405: ����(Languages)
			toolStripButton_About.Text			= LANGUAGES.txt(406);					// 406: ����

			label_SubsPath.Text					= LANGUAGES.txt(420);					// 420: ��Ļ·����
			radioButton_SearchByName.Text		= LANGUAGES.txt(421);					// 421: �������Ʋ���
			radioButton_SearchBySQL.Text		= LANGUAGES.txt(422);					// 422: ʹ�ò�ѯ������

			update_status_bar();

			m_About.update_language_text();
			m_Log.update_language_text();
			m_Search.update_language_text();
			m_UpdateDatabase.update_language_text();
		}
		#endregion

		#region Tag
		/*==============================================================
		 * ����/��ȡ Tag�������ԣ�
		 *==============================================================*/
		void Set_Tag__Language(ToolStripMenuItem TSMI, string culture_name)
		{
			TSMI.Tag = culture_name;
		}
		//--------------------------------------------------
		string Get_Tag__Language(ToolStripMenuItem TSMI)
		{
			return (string)TSMI.Tag!;
		}
		#endregion

		public frm_Mainform()
		{
			InitializeComponent();

			m_s_mainform = this;
		}

		#region Winform �¼�
		/*==============================================================
		 * ���ڼ���/���ڹر�
		 *==============================================================*/
		private void frm_Mainform_Load(object sender, EventArgs e)
		{
			this.Icon = IMAGE.get_exe_icon();
			this.Text = $"{COMMON.m_k_PROGRAM_NAME} {COMMON.m_k_VERSION}";

			m_Search.Owner			= this;
			m_UpdateDatabase.Owner	= this;

			// ��ʼ��������
			LANGUAGES.read_list();
			LANGUAGES.set_language_to_default();

			foreach(var kvp in LANGUAGES.m_s_LanguagesList)
			{
				var lang = kvp.Value;

				string display_name = "";

				try
				{
					CultureInfo ci = new(lang.m_name);
					display_name = ci.DisplayName;
				}
				catch(Exception)
				{
				}

				ToolStripMenuItem item = new($"({lang.m_name}) {display_name}");

				if(lang == LANGUAGES.m_s_current_language)
				{
					item.Checked							= true;
					m_current_language_ToolStripMenuItem	= item;
				}

				Set_Tag__Language(item, lang.m_name);
				item.Click += ToolStripMenuItem_Language_Click;

				toolStripSplitButton_Languages.DropDownItems.Add(item);
			}	// for

			update_language_text();

			// ��ȡ�����ļ�
			CONFIG.read_config();

			if(CONFIG.WINDOW.m_s_width > 0 && CONFIG.WINDOW.m_s_height > 0)
				this.Size = new(CONFIG.WINDOW.m_s_width, CONFIG.WINDOW.m_s_height);

			if(CONFIG.WINDOW.m_s_X >= 0 && CONFIG.WINDOW.m_s_Y >= 0)
				this.DesktopLocation = new(CONFIG.WINDOW.m_s_X, CONFIG.WINDOW.m_s_Y);

			textBox_SubsPath.Text = CONFIG.SUBS.m_s_path;

			m_UpdateDatabase.update_Type_List();
			m_Search.update_Type_List();
			m_Search.update_Source_List();

			// �������ݿ��ļ�
			DATA.read_data_from_file();
			update_DataGridView();

			FORMS.Set_DoubleBuffered(dataGridView_Main, true);

			m_DataGridView_event_enable	= true;
			CONFIG.m_s_dirty			= false;
		}
		//--------------------------------------------------
		private void frm_Mainform_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = (MessageBox.Show(LANGUAGES.txt(453), // 453: �Ƿ�Ҫ�˳�����
										this.Text,
										MessageBoxButtons.YesNo,
										MessageBoxIcon.Question,
										MessageBoxDefaultButton.Button2) == DialogResult.No);

			CONFIG.save_config();
		}

		/*==============================================================
		 * �������ڽ���
		 *==============================================================*/
		private void frm_Mainform_ResizeEnd(object sender, EventArgs e)
		{
			CONFIG.WINDOW.m_s_width		= this.Width;
			CONFIG.WINDOW.m_s_height	= this.Height;
			CONFIG.WINDOW.m_s_X			= this.DesktopLocation.X;
			CONFIG.WINDOW.m_s_Y			= this.DesktopLocation.Y;

			CONFIG.m_s_dirty			= true;
		}

		/*==============================================================
		 * ��д ProcessCmdKey ���������񰴼���
		 *==============================================================*/
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			// F5
			if(keyData == Keys.F5)
			{
				toolStripButton_UpdateDB.PerformClick();
				return true;
			}

			// Alt + Enter
			if(keyData == (Keys.Alt | Keys.Enter))
			{
				toolStripButton_Folder.PerformClick();
				return true;
			}

			// F1
			if(keyData == Keys.F1)
			{
				toolStripButton_URL.PerformClick();
				return true;
			}

			// F3
			if(keyData == Keys.F3)
			{
				toolStripButton_Search.PerformClick();
				return true;
			}

			// F4
			if(keyData == Keys.F4)
			{
				toolStripButton_Log.PerformClick();
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);	// ���������������ദ��
		}

		/*==============================================================
		 * ��Ļ·��
		 *==============================================================*/
		private void textBox_SubsPath_TextChanged(object sender, EventArgs e)
		{
			CONFIG.SUBS.m_s_path	= textBox_SubsPath.Text;
			CONFIG.m_s_dirty		= true;

			m_Search.update_Type_List();
			m_UpdateDatabase.update_Type_List();
		}

		/*==============================================================
		 * ���
		 *==============================================================*/
		private void button_SubsPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new();

			if(Directory.Exists(textBox_SubsPath.Text))
			{
				DirectoryInfo di = new(textBox_SubsPath.Text);
				dlg.SelectedPath = di.FullName;
			}

			if(dlg.ShowDialog() == DialogResult.OK)
				textBox_SubsPath.Text = dlg.SelectedPath;
		}

		/*==============================================================
		 * ���ң��س���
		 *==============================================================*/
		private void textBox_Filter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == '\r')
				do_search();
		}

		/*==============================================================
		 * ���ң���ť��
		 *==============================================================*/
		private void pictureBox_Search_Click(object sender, EventArgs e)
		{
			do_search();
		}

		/*==============================================================
		 * ��ѯ�﷨����
		 *==============================================================*/
		private void linkLabel_FilterHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			COMMON.OpenURL("https://www.csharp-examples.net/dataview-rowfilter/");
		}

		/*==============================================================
		 * �����п�
		 *==============================================================*/
		private void dataGridView_Main_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			if(!m_DataGridView_event_enable)
				return;

			for(int i = 0; i < (int)DATA.e_Column.MAX; ++i)
				CONFIG.DATA_GRID_VIEW.m_s_Widths[i] = dataGridView_Main.Columns[((DATA.e_Column)i).ToString()]!.Width;

			CONFIG.m_s_dirty = true;
		}

		/*==============================================================
		 * ������˳��
		 *==============================================================*/
		private void dataGridView_Main_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
		{
			if(!m_DataGridView_event_enable)
				return;

			for(int i = 0; i < (int)DATA.e_Column.MAX; ++i)
				CONFIG.DATA_GRID_VIEW.m_s_Indices[i] = dataGridView_Main.Columns[((DATA.e_Column)i).ToString()]!.DisplayIndex;

			CONFIG.m_s_dirty = true;
		}
		#endregion

		#region �����˵�
		/*==============================================================
		 * �������ݿ�
		 *==============================================================*/
		private void toolStripButton_UpdateDB_Click(object sender, EventArgs e)
		{
			FORMS.active_form(m_UpdateDatabase);
		}

		/*==============================================================
		 * �򿪱����ļ���
		 *==============================================================*/
		private void toolStripButton_Folder_Click(object sender, EventArgs e)
		{
			DataTable? dt = (DataTable?)dataGridView_Main.DataSource;

			if(dt == null)
				return;

			DataRow? dr = (dataGridView_Main.CurrentRow?.DataBoundItem as DataRowView)?.Row;

			if(dr == null)
				return;

			string dir = Path.Combine(	CONFIG.SUBS.m_s_path,
										(string)dr[DATA.e_Column.path.ToString()],
										(string)dr[DATA.e_Column.source.ToString()],
										(string)dr[DATA.e_Column.sub_name.ToString()] );

			if(!Directory.Exists(dir))
			{
				MessageBox.Show(string.Format(LANGUAGES.txt(454), dir));	// 454: �Ҳ����ļ��� {0:s}
				return;
			}

			PATH.open_dir(dir);
		}

		/*==============================================================
		 * ��Զ������
		 *==============================================================*/
		private void toolStripButton_URL_Click(object sender, EventArgs e)
		{
			DataTable? dt = (DataTable?)dataGridView_Main.DataSource;

			if(dt == null)
				return;

			DataRow? dr = (dataGridView_Main.CurrentRow?.DataBoundItem as DataRowView)?.Row;

			if(dr == null)
				return;

			string dir = string.Format(	"{0:s}/{1:s}/{2:s}",
										(string)dr[DATA.e_Column.path.ToString()],
										(string)dr[DATA.e_Column.source.ToString()],
										(string)dr[DATA.e_Column.sub_name.ToString()] ).Replace("\\", "/");
			dir = Uri.EscapeDataString(dir);

			COMMON.OpenURL($"https://github.com/foxofice/sub_share/tree/master/subs_list/{dir}");
		}

		/*==============================================================
		 * �߼�����
		 *==============================================================*/
		private void toolStripButton_Search_Click(object sender, EventArgs e)
		{
			FORMS.active_form(m_Search);
		}

		/*==============================================================
		 * ��־
		 *==============================================================*/
		private void toolStripButton_Log_Click(object sender, EventArgs e)
		{
			FORMS.active_form(m_Log);
		}

		/*==============================================================
		 * ����
		 *==============================================================*/
		private void toolStripButton_About_Click(object sender, EventArgs e)
		{
			FORMS.active_form(m_About);
		}
		#endregion

		#region ��ʱ��
		/*==============================================================
		 * ���������ļ�
		 *==============================================================*/
		private void timer_SaveConfig_Tick(object sender, EventArgs e)
		{
			CONFIG.save_config();
		}
		#endregion
	};
}	// namespace sub_db
