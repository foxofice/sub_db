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
	public partial class frm_Log : Form
	{
		public frm_Log()
		{
			InitializeComponent();
		}

		#region Winform 事件
		private void frm_Log_Load(object sender, EventArgs e)
		{
			this.Icon = IMAGE.get_exe_icon();

			FORMS.Set_DoubleBuffered(listView_Log, true);
		}
		//--------------------------------------------------
		private void frm_Log_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		/*==============================================================
		 * ListView 调整大小
		 *==============================================================*/
		private void listView_Log_Resize(object sender, EventArgs e)
		{
			columnHeader_Time.Width	= 122;
			columnHeader_Log.Width	= listView_Log.Width - columnHeader_Time.Width - 21;
		}
		#endregion

		/*==============================================================
		 * 添加日志
		 *==============================================================*/
		internal void add_log(string txt, Color color = default)
		{
			ListViewItem LVI = new([DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), txt])
			{
				ForeColor = color,
			};

			listView_Log.Items.Add(LVI);

			LVI.EnsureVisible();
		}

		#region 多语言
		/*==============================================================
		 * 更新多语言文本
		 *==============================================================*/
		internal void update_language_text()
		{
			this.Text				= LANGUAGES.txt(150);	// 150: 日志
			columnHeader_Time.Text	= LANGUAGES.txt(151);	// 151: 时间
			columnHeader_Log.Text	= LANGUAGES.txt(152);	// 152: 日志
		}
		#endregion
	};
}	// namespace sub_db
