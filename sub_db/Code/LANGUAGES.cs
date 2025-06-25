using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace sub_db
{
	internal class LANGUAGES
	{
		internal class c_Language
		{
			internal string						m_filename	= "";	// 语言模板文件

			internal int						m_codepage	= 0;	// CodePage
			internal string						m_name		= "";	// 语言名称

			// 文本列表
			internal Dictionary<int, string>	m_txt		= new Dictionary<int, string>();
		};

		static List<c_Language>	m_s_LanguagesList			= new List<c_Language>();
		static int				m_s_current_language_idx	= 0;

		/*==============================================================
		 * 读取语言列表
		 *==============================================================*/
		internal static void	read_languages_list()
		{
			if(!Directory.Exists(PATH.m_k_LANGUAGE_DIR))
				return;

			string[] files = Directory.GetFiles(PATH.m_k_LANGUAGE_DIR,
												"*.txt",
												SearchOption.TopDirectoryOnly);

			m_s_LanguagesList.Clear();

			foreach(string file in files)
			{
				c_Language language = new c_Language();
				language.m_filename = file;

				m_s_LanguagesList.Add(language);

				string[] lines = File.ReadAllLines(file, Encoding.UTF8);

				foreach(string line in lines)
				{
					if(line.Length < 2)
						continue;

					if(line[0] == '/' && line[1] == '/')
						continue;

					int idx = line.IndexOf(":");
					if(idx < 0)
						continue;

					string w1 = line.Substring(0, idx).Trim().ToLower();
					string w2 = line.Substring(idx + 1).Trim();

					if(w1 == "codepage")
					{
						int.TryParse(w2, out language.m_codepage);
						continue;
					}

					if(w1 == "name")
					{
						language.m_name = w2;
						continue;
					}

					int num;
					if(int.TryParse(w1, out num))
						language.m_txt[num] = w2.Trim();
				}	// for
			}	// for

			// 更新 UI
			frm_Mainform.m_s_mainform.toolStripSplitButton_Languages.DropDownItems.Clear();

			for(int i=0; i<m_s_LanguagesList.Count; ++i)
			{
				c_Language lang = m_s_LanguagesList[i];

				ToolStripMenuItem item = new ToolStripMenuItem(lang.m_name);
				item.Tag = i;

				item.Click += Language_Click;

				frm_Mainform.m_s_mainform.toolStripSplitButton_Languages.DropDownItems.Add(item);
			}	// for
		}

		/*==============================================================
		 * 改变语言的事件
		 *==============================================================*/
		internal static void Language_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;

			int index = (int)item.Tag;

			change_language(index);
		}

		/*==============================================================
		 * 读取语言列表
		 *==============================================================*/
		internal static void	change_language(int index)
		{
			var mainform	= frm_Mainform.m_s_mainform;
			var about		= frm_Mainform.m_s_mainform.m_About;
			var setting		= frm_Mainform.m_s_mainform.m_Setting;
			var update_db	= frm_Mainform.m_s_mainform.m_UpdateDatabase;
			var adv_search	= frm_Mainform.m_s_mainform.m_Search;

			((ToolStripMenuItem)mainform.toolStripSplitButton_Languages.DropDownItems[m_s_current_language_idx]).Checked = false;
			((ToolStripMenuItem)mainform.toolStripSplitButton_Languages.DropDownItems[index]).Checked = true;

			m_s_current_language_idx = index;

			// 顶部菜单按钮
			mainform.toolStripButton_UpdateDB.Text			= txt(10) + "(Ctrl + F5)";	// 更新数据库
			mainform.toolStripButton_Folder.Text			= txt(15) + "(Alt + Enter)";// 打开本地文件夹
			mainform.toolStripButton_URL.Text				= txt(16) + "(Ctrl + F1)";	// 打开远程链接
			mainform.toolStripButton_Search.Text			= txt(11) + "(Ctrl + F3)";	// 高级查找
			mainform.toolStripSplitButton_Languages.Text	= txt(12);					// 语言(Languages)
			mainform.toolStripButton_Settings.Text			= txt(13);					// 设置
			mainform.toolStripButton_About.Text				= txt(14);					// 关于

			// mainform
			mainform.radioButton_SearchByName.Text			= txt(20);	// 根据名称查找
			mainform.radioButton_SearchBySQL.Text			= txt(21);	// 使用查询语句查找
			FORMS.m_s_Tooltip.SetToolTip(mainform.pictureBox_Search, txt(22));	// 查找

			mainform.update_status();

			// about
			about.Text					= string.Format("{0:s} {1:s} {2:s}",
														txt(14),	// 关于
														COMMON.m_k_PROGRAM_NAME,
														COMMON.m_k_VERSION);

			about.label_ChangeLog.Text	= string.Format("{0:s} {1:s}",
														COMMON.m_k_PROGRAM_NAME,
														txt(30));	// 更新日志

			about.button_OK.Text						= txt(0);	// 确定

			// setting
			setting.Text								= txt(13);	// 设置
			setting.label_subs_path.Text				= txt(40);	// 字幕路径：
			setting.button_OK.Text						= txt(0);	// 确定

			// update_database
			FORMS.m_s_Tooltip.SetToolTip(update_db.pictureBox_Start, txt(50));	// 开始更新数据库
			FORMS.m_s_Tooltip.SetToolTip(update_db.pictureBox_Stop,	txt(51));	// 停止更新数据库
			update_db.Text								= txt(10);	// 更新数据库
			update_db.columnHeader_Time.Text			= txt(52);	// 时间
			update_db.columnHeader_Log.Text				= txt(53);	// 日志
			update_db.radioButton_UseLocalData.Text		= txt(64);	// 使用本地字幕数据
			update_db.radioButton_UseRemoteData.Text	= txt(65);	// 使用服务器字幕数据

			// search
			adv_search.label_Name.Text					= txt(70);	// 影片名称：
			adv_search.label_SubName.Text				= txt(71);	// 字幕名称：
			adv_search.label_Extension.Text				= txt(72);	// 字幕文件后缀：
			adv_search.label_Providers.Text				= txt(73);	// 提供者/字幕组：
			adv_search.label_Desc.Text					= txt(74);	// 描述：
			adv_search.label_Type.Text					= txt(75);	// 类型：
			adv_search.label_Source.Text				= txt(76);	// 片源：
			adv_search.checkBox_Time.Text				= txt(77);	// 影片放送日期
			adv_search.linkLabel_Reset.Text				= txt(78);	// 重置搜索条件
			adv_search.button_Search.Text				= txt(79);	// 搜索
		}

		/*==============================================================
		 * 设置默认语言
		 *==============================================================*/
		internal static void	change_language_to_default()
		{
			int idx = -1;

			for(int i=0; i<m_s_LanguagesList.Count; ++i)
			{
				c_Language lang = m_s_LanguagesList[i];

				if(lang.m_codepage == Encoding.Default.CodePage)
				{
					idx = i;
					break;
				}
			}	// for

			if(idx < 0)
				idx = 2;

			change_language(idx);
		}

		/*==============================================================
		 * 获取文本
		 *==============================================================*/
		internal static string	txt(int num)
		{
			if(m_s_current_language_idx < m_s_LanguagesList.Count)
			{
				var txt_list = m_s_LanguagesList[m_s_current_language_idx].m_txt;

				if(txt_list.ContainsKey(num))
					return txt_list[num];
			}

			return "(no msg)";
		}
	}
}	// namespace sub_db
