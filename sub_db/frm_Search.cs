using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;

namespace sub_db
{
	public partial class frm_Search : Form
	{
		public frm_Search()
		{
			InitializeComponent();
		}

		#region Winform 事件
		/*==============================================================
		 * 窗口加载/窗口关闭
		 *==============================================================*/
		private void frm_Search_Load(object sender, EventArgs e)
		{
			this.Icon = IMAGE.get_exe_icon();

			update_Type_List();
			update_Source_List();
		}
		//--------------------------------------------------
		private void frm_Search_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		/*==============================================================
		 * 番剧放送日期
		 *==============================================================*/
		private void checkBox_Time_CheckedChanged(object sender, EventArgs e)
		{
			comboBox_Time.Enabled		= checkBox_Time.Checked;
			dateTimePicker_Time.Enabled	= checkBox_Time.Checked;
		}

		/*==============================================================
		 * 重置搜索条件
		 *==============================================================*/
		private void linkLabel_Reset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if(MessageBox.Show(	LANGUAGES.txt(250),	// 250: 是否重置搜索条件？
								$"{COMMON.m_k_PROGRAM_NAME} {COMMON.m_k_VERSION}",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Question,
								MessageBoxDefaultButton.Button2 ) == DialogResult.No)
				return;

			textBox_Name.Clear();
			textBox_SubName.Clear();
			textBox_Extension.Clear();
			textBox_Providers.Clear();
			textBox_Desc.Clear();
			comboBox_Type.SelectedIndex	= -1;
			comboBox_Source.Text		= "";
			checkBox_Time.Checked		= false;
			comboBox_Time.SelectedIndex	= 0;
			dateTimePicker_Time.Value	= DateTime.Now;
		}

		/*==============================================================
		 * 搜索
		 *==============================================================*/
		private void button_Search_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new();

			int count = 0;

			if(textBox_Name.TextLength > 0)
			{
				++count;

				string fix_Name = SQL.escape(textBox_Name.Text);

				List<string> list = COMMON.GenerateSimplifiedTraditionalCombinations(fix_Name);

				sb.Append("(");

				foreach(string s in list)
				{
					sb.Append($"[name_chs] LIKE '%{s}%' OR ");
					sb.Append($"[name_cht] LIKE '%{s}%' OR ");
				}	// for

				sb.Append($"[name_jp] LIKE '%{fix_Name}%' OR ");
				sb.Append($"[name_en] LIKE '%{fix_Name}%' OR ");
				sb.Append($"[name_rome] LIKE '%{fix_Name}%')");
			}

			if(textBox_SubName.TextLength > 0)
			{
				++count;

				string fix_SubName = SQL.escape(textBox_SubName.Text);

				if(sb.Length > 0)
					sb.Append(" AND ");

				sb.Append($"([sub_name] LIKE '%{fix_SubName}%')");
			}

			if(textBox_Extension.TextLength > 0)
			{
				++count;

				string fix_Extension = SQL.escape(textBox_Extension.Text);

				if(sb.Length > 0)
					sb.Append(" AND ");

				sb.Append($"([extension] LIKE '%{fix_Extension}%')");
			}

			if(textBox_Providers.TextLength > 0)
			{
				++count;

				string fix_Providers = SQL.escape(textBox_Providers.Text);

				if(sb.Length > 0)
					sb.Append(" AND ");

				sb.Append($"([providers] LIKE '%{fix_Providers}%')");
			}

			if(textBox_Desc.TextLength > 0)
			{
				++count;

				string fix_Desc = SQL.escape(textBox_Desc.Text);

				if(sb.Length > 0)
					sb.Append(" AND ");

				sb.Append($"([desc] LIKE '%{fix_Desc}%')");
			}

			if(comboBox_Type.SelectedIndex > 0)
			{
				++count;

				string fix_Type = SQL.escape(comboBox_Type.Text);

				if(sb.Length > 0)
					sb.Append(" AND ");

				sb.Append($"([type] = '{fix_Type}')");
			}

			if(comboBox_Source.Text.Length > 0)
			{
				++count;

				string fix_Source = SQL.escape(comboBox_Source.Text);

				if(sb.Length > 0)
					sb.Append(" AND ");

				sb.Append($"([source] LIKE '%{fix_Source}%')");
			}

			if(checkBox_Time.Checked && comboBox_Time.SelectedIndex >= 0)
			{
				++count;

				if(sb.Length > 0)
					sb.Append(" AND ");

				sb.Append($"([time] {comboBox_Time.Text} '{dateTimePicker_Time.Value.ToString("yyyy-MM-dd")}')");
			}

			this.Close();

			frm_Mainform.m_s_mainform.set_SQL_filter(sb.ToString());
			frm_Mainform.m_s_mainform.do_search();
		}
		#endregion

		/*==============================================================
		 * 更新 Type 列表
		 *==============================================================*/
		internal void update_Type_List()
		{
			comboBox_Type.Items.Clear();

			string[] types = DATA.get_types(true);
			if(types.Length == 0)
				types = DATA.get_types(false);

			foreach(string type in types)
				comboBox_Type.Items.Add(type);
		}

		/*==============================================================
		 * 更新 Source 列表
		 *==============================================================*/
		internal void update_Source_List()
		{
			comboBox_Source.Items.Clear();

			foreach(string source in DATA.m_s_source_list)
				comboBox_Source.Items.Add(source);
		}

		#region 多语言
		/*==============================================================
		 * 更新多语言文本
		 *==============================================================*/
		internal void update_language_text()
		{
			this.Text				= LANGUAGES.txt(200);	// 200: 高级查找
			label_Name.Text			= LANGUAGES.txt(201);	// 201: 番剧名称：
			label_SubName.Text		= LANGUAGES.txt(202);	// 202: 字幕名称：
			label_Extension.Text	= LANGUAGES.txt(203);	// 203: 字幕文件后缀：
			label_Providers.Text	= LANGUAGES.txt(204);	// 204: 提供者/字幕组：
			label_Desc.Text			= LANGUAGES.txt(205);	// 205: 描述：
			label_Type.Text			= LANGUAGES.txt(206);	// 206: 类型：
			label_Source.Text		= LANGUAGES.txt(207);	// 207: 片源：
			checkBox_Time.Text		= LANGUAGES.txt(208);	// 208: 放送日期：
			linkLabel_Reset.Text	= LANGUAGES.txt(209);	// 209: 重置搜索条件
			button_Search.Text		= LANGUAGES.txt(210);	// 210: 搜索
		}
		#endregion
	};
}	// namespace sub_db
