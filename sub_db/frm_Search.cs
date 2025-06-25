using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
		 * 窗口加载时
		 *==============================================================*/
		private void frm_Search_Load(object sender, EventArgs e)
		{
			this.Icon	= IMAGE.img2icon(Resource1.Logo);
			this.Text	= string.Format(LANGUAGES.txt(11));	// 高级查找
		}

		/*==============================================================
		 * 窗口关闭时
		 *==============================================================*/
		private void frm_Search_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		/*==============================================================
		 * 影片放送日期
		 *==============================================================*/
		private void CheckBox_Time_CheckedChanged(object sender, EventArgs e)
		{
			radioButton_Time_EarlierThan.Enabled	= checkBox_Time.Checked;
			radioButton_Time_Equal.Enabled			= checkBox_Time.Checked;
			radioButton_Time_LaterThan.Enabled		= checkBox_Time.Checked;
			dateTimePicker_Time.Enabled				= checkBox_Time.Checked;
		}

		/*==============================================================
		 * 重置搜索条件
		 *==============================================================*/
		private void LinkLabel_Reset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if(MessageBox.Show(	LANGUAGES.txt(80),	// 是否重置搜索条件？
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
			comboBox_Type.SelectedIndex				= -1;
			comboBox_Source.Text					= "";
			checkBox_Time.Checked					= false;
			radioButton_Time_EarlierThan.Checked	= true;
			dateTimePicker_Time.Value				= DateTime.Now;
		}

		/*==============================================================
		 * 搜索
		 *==============================================================*/
		private void Button_Search_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();

			int count = 0;

			if(textBox_Name.TextLength > 0)
			{
				++count;

				string fix_Name_chs = SQL.fix_string(ChineseConverter.Convert(textBox_Name.Text, ChineseConversionDirection.TraditionalToSimplified));
				string fix_Name_cht = SQL.fix_string(ChineseConverter.Convert(textBox_Name.Text, ChineseConversionDirection.SimplifiedToTraditional));

				sb.Append($"([name_chs] like '%{fix_Name_chs}%' or [name_chs] like '%{fix_Name_cht}%' or ");
				sb.Append($"[name_cht] like '%{fix_Name_chs}%' or [name_cht] like '%{fix_Name_cht}%' or ");
				sb.Append($"[name_jp] like '%{fix_Name_chs}%' or [name_jp] like '%{fix_Name_cht}%' or ");
				sb.Append($"[name_en] like '%{fix_Name_chs}%' or ");
				sb.Append($"[name_rome] like '%{fix_Name_chs}%')");
			}

			if(textBox_SubName.TextLength > 0)
			{
				++count;

				string fix_SubName = SQL.fix_string(textBox_SubName.Text);

				if(sb.Length > 0)
					sb.Append(" and ");

				sb.Append($"([sub_name] like '%{fix_SubName}%')");
			}

			if(textBox_Extension.TextLength > 0)
			{
				++count;

				string fix_Extension = SQL.fix_string(textBox_Extension.Text);

				if(sb.Length > 0)
					sb.Append(" and ");

				sb.Append($"([extension] like '%{fix_Extension}%')");
			}

			if(textBox_Providers.TextLength > 0)
			{
				++count;

				string fix_Providers = SQL.fix_string(textBox_Providers.Text);

				if(sb.Length > 0)
					sb.Append(" and ");

				sb.Append($"([providers] like '%{fix_Providers}%')");
			}

			if(textBox_Desc.TextLength > 0)
			{
				++count;

				string fix_Desc = SQL.fix_string(textBox_Desc.Text);

				if(sb.Length > 0)
					sb.Append(" and ");

				sb.Append($"([desc] like '%{fix_Desc}%')");
			}

			if(comboBox_Type.SelectedIndex > 0)
			{
				++count;

				string fix_Type = SQL.fix_string(comboBox_Type.Text);

				if(sb.Length > 0)
					sb.Append(" and ");

				sb.Append($"([type] = '{fix_Type}')");
			}

			if(comboBox_Source.Text.Length > 0)
			{
				++count;

				string fix_Source = SQL.fix_string(comboBox_Source.Text);

				if(sb.Length > 0)
					sb.Append(" and ");

				sb.Append($"([source] like '%{fix_Source}%')");
			}

			if(checkBox_Time.Checked)
			{
				++count;

				if(sb.Length > 0)
					sb.Append(" and ");

				string op = "";

				if(radioButton_Time_EarlierThan.Checked)
					op = "<";
				else if(radioButton_Time_Equal.Checked)
					op = "=";
				else
					op = ">";

				sb.Append(string.Format("([time] {0:s} '{1:d}-{2:d}-{3:d}')",
										op,
										dateTimePicker_Time.Value.Year,
										dateTimePicker_Time.Value.Month,
										dateTimePicker_Time.Value.Day));
			}

			if(count == 1)
			{
				sb.Remove(0, 1);
				sb.Remove(sb.Length - 1, 1);
			}

			this.Close();

			frm_Mainform.m_s_mainform.radioButton_SearchBySQL.Checked	= true;
			frm_Mainform.m_s_mainform.textBox_Filter.Text				= sb.ToString();
			frm_Mainform.m_s_mainform.do_search();
		}
		#endregion
	};
}	// namespace sub_db
