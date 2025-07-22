using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sub_db
{
	public partial class frm_About : Form
	{
		const string m_k_CHANGELOG_FILENAME = "Files\\changelog.txt";

		public frm_About()
		{
			InitializeComponent();
		}

		#region Winform 事件
		/*==============================================================
		 * 窗口加载/关闭
		 *==============================================================*/
		private void frm_About_Load(object sender, EventArgs e)
		{
			this.Icon				= IMAGE.get_exe_icon();
			pictureBox_Icon.Image	= IMAGE.icon2img(IMAGE.get_exe_icon());

			if(File.Exists(m_k_CHANGELOG_FILENAME))
				textBox_ChangeLog.Text = File.ReadAllText(m_k_CHANGELOG_FILENAME, Encoding.UTF8);
		}
		//--------------------------------------------------
		private void frm_About_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		/*==============================================================
		 * Github
		 *==============================================================*/
		private void linkLabel_Github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			COMMON.OpenURL(((LinkLabel)sender).Text);
		}

		/*==============================================================
		 * 官网
		 *==============================================================*/
		private void linkLabel_Website_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			COMMON.OpenURL("https://www.acgdev.com");
		}

		/*==============================================================
		 * 确定
		 *==============================================================*/
		private void button_OK_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region 多语言
		/*==============================================================
		 * 更新多语言文本
		 *==============================================================*/
		internal void update_language_text()
		{
			this.Text				= $"{LANGUAGES.txt(100)} {COMMON.m_k_PROGRAM_NAME} {COMMON.m_k_VERSION}";	// 100: 关于
			label_ChangeLog.Text	= LANGUAGES.txt(101);														// 101: 更新日志：
			linkLabel_Website.Text	= LANGUAGES.txt(102);														// 102: 官网
			button_OK.Text			= LANGUAGES.txt(103);														// 103: 确定
		}
		#endregion
	};
}	// namespace sub_db
