using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace sub_db
{
	internal class CONFIG
	{
		const string	m_k_OPTION__SUBS_PATH					= "subs_path";			// 字幕列表路径
		const string	m_k_OPTION__LAST_UPDATA_DB_TIME			= "last_updata_db_time";// 最后更新数据库的时间

		const string	m_k_OPTION__WINDOW_WIDTH				= "window.width";		// 窗口宽度
		const string	m_k_OPTION__WINDOW_HEIGHT				= "window.height";		// 窗口高度

		const string	m_k_OPTION__WINDOW_X					= "window.x";			// 窗口 x 坐标
		const string	m_k_OPTION__WINDOW_Y					= "window.y";			// 窗口 y 坐标

		// 数据网格的样式（width = 宽度、idx = 显示顺序索引）
		const string	m_k_OPTION__COLUMN__TIME__WIDTH			= "column.time.width";

		const string	m_k_OPTION__COLUMN__NAME_CHS__WIDTH		= "column.name_chs.width";
		const string	m_k_OPTION__COLUMN__NAME_CHT__WIDTH		= "column.name_cht.width";
		const string	m_k_OPTION__COLUMN__NAME_JP__WIDTH		= "column.name_jp.width";
		const string	m_k_OPTION__COLUMN__NAME_EN__WIDTH		= "column.name_en.width";
		const string	m_k_OPTION__COLUMN__NAME_ROME__WIDTH	= "column.name_rome.width";

		const string	m_k_OPTION__COLUMN__TYPE__WIDTH			= "column.type.width";
		const string	m_k_OPTION__COLUMN__SOURCE__WIDTH		= "column.source.width";
		const string	m_k_OPTION__COLUMN__SUB_NAME__WIDTH		= "column.sub_name.width";
		const string	m_k_OPTION__COLUMN__EXTENSION__WIDTH	= "column.extension.width";
		const string	m_k_OPTION__COLUMN__PROVIDERS__WIDTH	= "column.providers.width";
		const string	m_k_OPTION__COLUMN__DESC__WIDTH			= "column.desc.width";
		const string	m_k_OPTION__COLUMN__PATH__WIDTH			= "column.path.width";

		const string	m_k_OPTION__COLUMN__TIME__IDX			= "column.time.idx";

		const string	m_k_OPTION__COLUMN__NAME_CHS__IDX		= "column.name_chs.idx";
		const string	m_k_OPTION__COLUMN__NAME_CHT__IDX		= "column.name_cht.idx";
		const string	m_k_OPTION__COLUMN__NAME_JP__IDX		= "column.name_jp.idx";
		const string	m_k_OPTION__COLUMN__NAME_EN__IDX		= "column.name_en.idx";
		const string	m_k_OPTION__COLUMN__NAME_ROME__IDX		= "column.name_rome.idx";

		const string	m_k_OPTION__COLUMN__TYPE__IDX			= "column.type.idx";
		const string	m_k_OPTION__COLUMN__SOURCE__IDX			= "column.source.idx";
		const string	m_k_OPTION__COLUMN__SUB_NAME__IDX		= "column.sub_name.idx";
		const string	m_k_OPTION__COLUMN__EXTENSION__IDX		= "column.extension.idx";
		const string	m_k_OPTION__COLUMN__PROVIDERS__IDX		= "column.providers.idx";
		const string	m_k_OPTION__COLUMN__DESC__IDX			= "column.desc.idx";
		const string	m_k_OPTION__COLUMN__PATH__IDX			= "column.path.idx";

		//==============================

		static internal string		m_s_subs_path			= "../subs_list";	// 字幕列表路径
		static internal DateTime	m_s_last_updata_db_time	= DateTime.MinValue;// 最后更新数据库的时间

		static internal int			m_s_window_width		= 0;				// 窗口宽度
		static internal int			m_s_window_height		= 0;				// 窗口高度

		static internal int			m_s_window_x			= -1;				// 窗口 x 坐标
		static internal int			m_s_window_y			= -1;				// 窗口 y 坐标

		// 数据网格的样式（width = 宽度、idx = 显示顺序索引）
		static internal int[]	m_s_column_width	= new int[(int)DATA.e_ColumnName.MAX]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		};
		static internal int[]	m_s_column_idx		= new int[(int)DATA.e_ColumnName.MAX]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		};

		/*==============================================================
		 * 读取配置文件
		 *==============================================================*/
		static internal void	read_config()
		{
			if(!File.Exists(PATH.m_k_CONFIG_FILENAME))
				return;

			string[] lines = File.ReadAllLines(PATH.m_k_CONFIG_FILENAME, Encoding.UTF8);

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

				if(w1 == m_k_OPTION__SUBS_PATH.ToLower())
				{
					m_s_subs_path = w2;
					continue;
				}

				if(w1 == m_k_OPTION__LAST_UPDATA_DB_TIME.ToLower())
				{
					DateTime.TryParse(w2, out m_s_last_updata_db_time);
					continue;
				}

				if(w1 == m_k_OPTION__WINDOW_WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_window_width);
					continue;
				}

				if(w1 == m_k_OPTION__WINDOW_HEIGHT.ToLower())
				{
					int.TryParse(w2, out m_s_window_height);
					continue;
				}

				if(w1 == m_k_OPTION__WINDOW_X.ToLower())
				{
					int.TryParse(w2, out m_s_window_x);
					continue;
				}

				if(w1 == m_k_OPTION__WINDOW_Y.ToLower())
				{
					int.TryParse(w2, out m_s_window_y);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__TIME__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.time]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__NAME_CHS__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.name_chs]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__NAME_CHT__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.name_cht]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__NAME_JP__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.name_jp]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__NAME_EN__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.name_en]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__NAME_ROME__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.name_rome]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__TYPE__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.type]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__SOURCE__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.source]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__SUB_NAME__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.sub_name]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__EXTENSION__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.extension]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__PROVIDERS__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.providers]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__DESC__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.desc]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__PATH__WIDTH.ToLower())
				{
					int.TryParse(w2, out m_s_column_width[(int)DATA.e_ColumnName.path]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__TIME__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.time]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__NAME_CHS__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.name_chs]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__NAME_CHT__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.name_cht]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__NAME_JP__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.name_jp]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__NAME_EN__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.name_en]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__NAME_ROME__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.name_rome]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__TYPE__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.type]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__SOURCE__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.source]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__SUB_NAME__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.sub_name]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__EXTENSION__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.extension]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__PROVIDERS__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.providers]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__DESC__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.desc]);
					continue;
				}

				if(w1 == m_k_OPTION__COLUMN__PATH__IDX.ToLower())
				{
					int.TryParse(w2, out m_s_column_idx[(int)DATA.e_ColumnName.path]);
					continue;
				}
			}	// for

			var mainform = frm_Mainform.m_s_mainform;

			if(m_s_window_width == 0)
				m_s_window_width = 1024;

			if(m_s_window_height == 0)
				m_s_window_height = 768;

			mainform.Size = new Size(m_s_window_width, m_s_window_height);

			if(m_s_window_x >= 0 && m_s_window_y >= 0)
				mainform.DesktopLocation = new Point(m_s_window_x, m_s_window_y);

			mainform.m_UpdateDatabase.append_log(	$"最后更新数据库的时间：{m_s_last_updata_db_time.ToString()}",
													Color.Blue );
		}

		/*==============================================================
		 * 写入配置文件
		 *==============================================================*/
		static internal void	write_config()
		{
			List<string> lines = new List<string>();

			lines.Add(LANGUAGES.txt(100));	//「// 字幕路径」
			lines.Add($"{m_k_OPTION__SUBS_PATH}: {m_s_subs_path}");
			lines.Add("");

			lines.Add(LANGUAGES.txt(101));	//「// 最后更新数据库的时间」
			lines.Add($"{m_k_OPTION__LAST_UPDATA_DB_TIME}: {m_s_last_updata_db_time.ToString()}");
			lines.Add("");

			lines.Add(LANGUAGES.txt(102));	//「// 窗口大小」
			lines.Add($"{m_k_OPTION__WINDOW_WIDTH}: {m_s_window_width}");
			lines.Add($"{m_k_OPTION__WINDOW_HEIGHT}: {m_s_window_height}");
			lines.Add("");

			lines.Add(LANGUAGES.txt(103));	//「// 窗口位置」
			lines.Add($"{m_k_OPTION__WINDOW_X}: {m_s_window_x}");
			lines.Add($"{m_k_OPTION__WINDOW_Y}: {m_s_window_y}");
			lines.Add("");

			lines.Add(LANGUAGES.txt(104));	//「// 数据网格的样式（width = 宽度、idx = 显示顺序索引）」
			lines.Add($"{m_k_OPTION__COLUMN__TIME__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.time]}");
			lines.Add($"{m_k_OPTION__COLUMN__NAME_CHS__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.name_chs]}");
			lines.Add($"{m_k_OPTION__COLUMN__NAME_CHT__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.name_cht]}");
			lines.Add($"{m_k_OPTION__COLUMN__NAME_JP__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.name_jp]}");
			lines.Add($"{m_k_OPTION__COLUMN__NAME_EN__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.name_en]}");
			lines.Add($"{m_k_OPTION__COLUMN__NAME_ROME__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.name_rome]}");
			lines.Add("");
			lines.Add($"{m_k_OPTION__COLUMN__TYPE__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.type]}");
			lines.Add($"{m_k_OPTION__COLUMN__SOURCE__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.source]}");
			lines.Add($"{m_k_OPTION__COLUMN__SUB_NAME__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.sub_name]}");
			lines.Add($"{m_k_OPTION__COLUMN__EXTENSION__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.extension]}");
			lines.Add($"{m_k_OPTION__COLUMN__PROVIDERS__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.providers]}");
			lines.Add($"{m_k_OPTION__COLUMN__DESC__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.desc]}");
			lines.Add($"{m_k_OPTION__COLUMN__PATH__WIDTH}: {m_s_column_width[(int)DATA.e_ColumnName.path]}");
			lines.Add("");
			lines.Add($"{m_k_OPTION__COLUMN__TIME__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.time]}");
			lines.Add($"{m_k_OPTION__COLUMN__NAME_CHS__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.name_chs]}");
			lines.Add($"{m_k_OPTION__COLUMN__NAME_CHT__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.name_cht]}");
			lines.Add($"{m_k_OPTION__COLUMN__NAME_JP__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.name_jp]}");
			lines.Add($"{m_k_OPTION__COLUMN__NAME_EN__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.name_en]}");
			lines.Add($"{m_k_OPTION__COLUMN__NAME_ROME__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.name_rome]}");
			lines.Add("");
			lines.Add($"{m_k_OPTION__COLUMN__TYPE__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.type]}");
			lines.Add($"{m_k_OPTION__COLUMN__SOURCE__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.source]}");
			lines.Add($"{m_k_OPTION__COLUMN__SUB_NAME__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.sub_name]}");
			lines.Add($"{m_k_OPTION__COLUMN__EXTENSION__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.extension]}");
			lines.Add($"{m_k_OPTION__COLUMN__PROVIDERS__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.providers]}");
			lines.Add($"{m_k_OPTION__COLUMN__DESC__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.desc]}");
			lines.Add($"{m_k_OPTION__COLUMN__PATH__IDX}: {m_s_column_idx[(int)DATA.e_ColumnName.path]}");

			File.WriteAllLines(PATH.m_k_CONFIG_FILENAME, lines, Encoding.UTF8);
		}
	};
}	// namespace sub_db
