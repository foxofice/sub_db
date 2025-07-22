using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sub_db
{
	internal class LANGUAGES
	{
		internal class c_Language
		{
			internal string						m_name	= "";

			// 文本列表（idx -> txt）
			internal Dictionary<int, string>	m_txt	= new();
		};

		const string				m_k_LANGUAGE_DIR		= "Files\\Languages";
		internal static c_Language?	m_s_current_language	= null;

		// culture_name -> c_Language
		internal static SortedDictionary<string, c_Language>	m_s_LanguagesList	= new();

		/*==============================================================
		 * 读取语言列表
		 *==============================================================*/
		internal static void	read_list()
		{
			if(!Directory.Exists(m_k_LANGUAGE_DIR))
				return;

			string[] files = Directory.GetFiles(m_k_LANGUAGE_DIR, "*.txt", SearchOption.TopDirectoryOnly);

			m_s_LanguagesList.Clear();

			foreach(string file in files)
			{
				c_Language language = new() { m_name = Path.GetFileNameWithoutExtension(file) };

				m_s_LanguagesList.Add(language.m_name.ToLower(), language);

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

					string w1 = line.Substring(0, idx).Trim();
					string w2 = line.Substring(idx + 1).Trim();

					if(int.TryParse(w1, out int num))
						language.m_txt[num] = w2;
				}	// for
			}	// for
		}

		/*==============================================================
		 * 设置当前语言
		 *==============================================================*/
		internal static void	set_language(string culture_name)
		{
			c_Language? lang = null;

			if(m_s_LanguagesList.TryGetValue(culture_name.ToLower(), out lang))
				m_s_current_language = lang;
			else if(m_s_LanguagesList.TryGetValue("en-US".ToLower(), out lang))
				m_s_current_language = lang;
			else
				m_s_current_language = null;
		}

		/*==============================================================
		 * 设置默认语言
		 *==============================================================*/
		internal static void	set_language_to_default()
		{
			set_language(CultureInfo.CurrentCulture.Name);
		}

		/*==============================================================
		 * 获取文本
		 *==============================================================*/
		internal static string	txt(int num)
		{
			if(m_s_current_language != null)
			{
				if(m_s_current_language.m_txt.ContainsKey(num))
					return m_s_current_language.m_txt[num];
			}

			return "(no msg)";
		}
	}
}	// namespace sub_db
