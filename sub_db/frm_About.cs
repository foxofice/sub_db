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

namespace sub_db
{
	public partial class frm_About : Form
	{
		public frm_About()
		{
			InitializeComponent();
		}

		#region Winform 事件
		/*==============================================================
		 * 窗口加载时
		 *==============================================================*/
		private void frm_About_Load(object sender, EventArgs e)
		{
			this.Icon				= IMAGE.img2icon(Resource1.Logo);
			this.Text				= string.Format("{0:s} {1:s} {2:s}",
													LANGUAGES.txt(14),	// 关于
													COMMON.m_k_PROGRAM_NAME,
													COMMON.m_k_VERSION);

			pictureBox_Icon.Image	= Resource1.Logo;

			if(File.Exists(PATH.m_k_CHANGELOG_FILENAME))
				textBox_ChangeLog.Text = File.ReadAllText(PATH.m_k_CHANGELOG_FILENAME, Encoding.UTF8);
		}

		/*==============================================================
		 * 窗口关闭时
		 *==============================================================*/
		private void frm_About_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		/*==============================================================
		 * 网站链接
		 *==============================================================*/
		private void LinkLabel_Website_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(linkLabel_Website.Text);
		}

		/*==============================================================
		 * 确定
		 *==============================================================*/
		private void Button_OK_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
	};
}	// namespace sub_db
