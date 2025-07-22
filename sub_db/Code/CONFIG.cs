using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sub_db
{
	internal class CONFIG
	{
		const string			m_k_CONFIG_FILE		= "Files\\config.txt";	// 配置文件的文件名
		const string			m_k_CONFIG_FILE_TMP	= "Files\\config.tmp";	// 配置文件的文件名（临时）
		internal static bool	m_s_dirty			= false;                // 设置是否已改变

		#region OPTION
		const string	OPTION__SUBS_PATH				= "subs.path";				// 字幕列表路径
		const string	OPTION__SUBS_LAST_UPDATE_TIME	= "subs.last_update_time";	// 最后更新数据库的时间

		const string	OPTION__WINDOW_WIDTH			= "window.width";			// 窗口宽度
		const string	OPTION__WINDOW_HEIGHT			= "window.height";			// 窗口高度

		const string	OPTION__WINDOW_X				= "window.x";				// 窗口 x 坐标
		const string	OPTION__WINDOW_Y				= "window.y";				// 窗口 y 坐标

		// 数据网格的样式（width = 宽度、idx = 显示顺序索引）
		const string	OPTION__COLUMN_WIDTH__TIME		= "column.width.time";

		const string	OPTION__COLUMN_WIDTH__NAME_CHS	= "column.width.name_chs";
		const string	OPTION__COLUMN_WIDTH__NAME_CHT	= "column.width.name_cht";
		const string	OPTION__COLUMN_WIDTH__NAME_JP	= "column.width.name_jp";
		const string	OPTION__COLUMN_WIDTH__NAME_EN	= "column.width.name_en";
		const string	OPTION__COLUMN_WIDTH__NAME_ROME	= "column.width.name_rome";

		const string	OPTION__COLUMN_WIDTH__TYPE		= "column.width.type";
		const string	OPTION__COLUMN_WIDTH__SOURCE	= "column.width.source";
		const string	OPTION__COLUMN_WIDTH__SUB_NAME	= "column.width.sub_name";
		const string	OPTION__COLUMN_WIDTH__EXTENSION	= "column.width.extension";
		const string	OPTION__COLUMN_WIDTH__PROVIDERS	= "column.width.providers";
		const string	OPTION__COLUMN_WIDTH__DESC		= "column.width.desc";
		const string	OPTION__COLUMN_WIDTH__PATH		= "column.width.path";

		const string	OPTION__COLUMN_IDX__TIME		= "column.idx.time";

		const string	OPTION__COLUMN_IDX__NAME_CHS	= "column.idx.name_chs";
		const string	OPTION__COLUMN_IDX__NAME_CHT	= "column.idx.name_cht";
		const string	OPTION__COLUMN_IDX__NAME_JP		= "column.idx.name_jp";
		const string	OPTION__COLUMN_IDX__NAME_EN		= "column.idx.name_en";
		const string	OPTION__COLUMN_IDX__NAME_ROME	= "column.idx.name_rome";

		const string	OPTION__COLUMN_IDX__TYPE		= "column.idx.type";
		const string	OPTION__COLUMN_IDX__SOURCE		= "column.idx.source";
		const string	OPTION__COLUMN_IDX__SUB_NAME	= "column.idx.sub_name";
		const string	OPTION__COLUMN_IDX__EXTENSION	= "column.idx.extension";
		const string	OPTION__COLUMN_IDX__PROVIDERS	= "column.idx.providers";
		const string	OPTION__COLUMN_IDX__DESC		= "column.idx.desc";
		const string	OPTION__COLUMN_IDX__PATH		= "column.idx.path";
		#endregion

		//==============================

		internal class SUBS
		{
			internal static string		m_s_path				= "..\\subs_list";	// 字幕列表路径
			internal static DateTime	m_s_last_update_time	= default;			// 最后更新数据库的时间
		};

		internal class WINDOW
		{
			internal static int	m_s_width	= 0;
			internal static int	m_s_height	= 0;

			internal static int	m_s_X		= -1;
			internal static int	m_s_Y		= -1;
		};

		internal class DATA_GRID_VIEW
		{
			internal static int[]	m_s_Widths	= Enumerable.Repeat(-1, (int)DATA.e_Column.MAX).ToArray();
			internal static int[]	m_s_Indices	= Enumerable.Repeat(-1, (int)DATA.e_Column.MAX).ToArray();
		};

		/*==============================================================
		 * 读取配置文件
		 *==============================================================*/
		static internal void	read_config()
		{
			string conf_file = m_k_CONFIG_FILE;

			if(!File.Exists(m_k_CONFIG_FILE))
			{
				if(!File.Exists(m_k_CONFIG_FILE_TMP))
					return;

				conf_file = m_k_CONFIG_FILE_TMP;
			}

			string[] lines = File.ReadAllLines(conf_file, Encoding.UTF8);

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

				// 字幕路径
				if(string.Compare(w1, OPTION__SUBS_PATH, true) == 0)
				{
					SUBS.m_s_path = w2;
					continue;
				}

				// 最后更新数据库的时间
				if(string.Compare(w1, OPTION__SUBS_LAST_UPDATE_TIME, true) == 0)
				{
					DateTime.TryParse(w2, out SUBS.m_s_last_update_time);
					continue;
				}

				// 窗口大小
				if(string.Compare(w1, OPTION__WINDOW_WIDTH, true) == 0)
				{
					int.TryParse(w2, out WINDOW.m_s_width);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__WINDOW_HEIGHT, true) == 0)
				{
					int.TryParse(w2, out WINDOW.m_s_height);
					continue;
				}

				// 窗口位置
				if(string.Compare(w1, OPTION__WINDOW_X, true) == 0)
				{
					int.TryParse(w2, out WINDOW.m_s_X);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__WINDOW_Y, true) == 0)
				{
					int.TryParse(w2, out WINDOW.m_s_Y);
					continue;
				}

				// 数据网格（宽度）
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__TIME, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.time]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__NAME_CHS, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.name_chs]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__NAME_CHT, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.name_cht]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__NAME_JP, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.name_jp]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__NAME_EN, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.name_en]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__NAME_ROME, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.name_rome]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__TYPE, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.type]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__SOURCE, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.source]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__SUB_NAME, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.sub_name]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__EXTENSION, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.extension]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__PROVIDERS, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.providers]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__DESC, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.desc]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_WIDTH__PATH, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.path]);
					continue;
				}

				// 数据网格（索引）
				if(string.Compare(w1, OPTION__COLUMN_IDX__TIME, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.time]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__NAME_CHS, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.name_chs]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__NAME_CHT, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.name_cht]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__NAME_JP, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.name_jp]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__NAME_EN, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.name_en]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__NAME_ROME, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.name_rome]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__TYPE, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.type]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__SOURCE, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.source]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__SUB_NAME, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.sub_name]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__EXTENSION, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.extension]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__PROVIDERS, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.providers]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__DESC, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.desc]);
					continue;
				}
				//--------------------------------------------------
				if(string.Compare(w1, OPTION__COLUMN_IDX__PATH, true) == 0)
				{
					int.TryParse(w2, out DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.path]);
					continue;
				}
			}	// for

			// 10: 最后更新数据库的时间：
			COMMON.add_log($"{LANGUAGES.txt(10)}{SUBS.m_s_last_update_time.ToString("yyyy-MM-dd HH:mm:ss")}", Color.Blue);
		}

		/*==============================================================
		 * 保存配置文件
		 *==============================================================*/
		static internal void	save_config()
		{
			if(!m_s_dirty)
				return;

			StringBuilder sb = new();

			// 字幕路径
			sb.AppendLine($"// {LANGUAGES.txt(20)}");	// 20: 字幕路径
			sb.AppendLine($"{OPTION__SUBS_PATH}: {SUBS.m_s_path}");
			sb.AppendLine();

			// 最后更新数据库的时间
			sb.AppendLine($"// {LANGUAGES.txt(21)}");	// 21: 最后更新数据库的时间
			sb.AppendLine($"{OPTION__SUBS_LAST_UPDATE_TIME}: {SUBS.m_s_last_update_time}");
			sb.AppendLine();

			// 窗口大小
			sb.AppendLine($"// {LANGUAGES.txt(22)}");	// 22: 窗口大小
			sb.AppendLine($"{OPTION__WINDOW_WIDTH}: {WINDOW.m_s_width}");
			sb.AppendLine($"{OPTION__WINDOW_HEIGHT}: {WINDOW.m_s_height}");
			sb.AppendLine();

			// 窗口位置
			sb.AppendLine($"// {LANGUAGES.txt(23)}");	// 23: 窗口位置
			sb.AppendLine($"{OPTION__WINDOW_X}: {WINDOW.m_s_X}");
			sb.AppendLine($"{OPTION__WINDOW_Y}: {WINDOW.m_s_Y}");
			sb.AppendLine();

			// 数据网格
			sb.AppendLine($"// {LANGUAGES.txt(24)}");	// 24: 数据网格
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__TIME}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.time]}");

			sb.AppendLine($"{OPTION__COLUMN_WIDTH__NAME_CHS}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.name_chs]}");
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__NAME_CHT}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.name_cht]}");
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__NAME_JP}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.name_jp]}");
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__NAME_EN}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.name_en]}");
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__NAME_ROME}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.name_rome]}");
			sb.AppendLine();

			sb.AppendLine($"{OPTION__COLUMN_WIDTH__TYPE}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.type]}");
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__SOURCE}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.source]}");
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__SUB_NAME}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.sub_name]}");
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__EXTENSION}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.extension]}");
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__PROVIDERS}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.providers]}");
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__DESC}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.desc]}");
			sb.AppendLine($"{OPTION__COLUMN_WIDTH__PATH}: {DATA_GRID_VIEW.m_s_Widths[(int)DATA.e_Column.path]}");
			sb.AppendLine();

			sb.AppendLine($"{OPTION__COLUMN_IDX__TIME}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.time]}");

			sb.AppendLine($"{OPTION__COLUMN_IDX__NAME_CHS}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.name_chs]}");
			sb.AppendLine($"{OPTION__COLUMN_IDX__NAME_CHT}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.name_cht]}");
			sb.AppendLine($"{OPTION__COLUMN_IDX__NAME_JP}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.name_jp]}");
			sb.AppendLine($"{OPTION__COLUMN_IDX__NAME_EN}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.name_en]}");
			sb.AppendLine($"{OPTION__COLUMN_IDX__NAME_ROME}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.name_rome]}");
			sb.AppendLine();

			sb.AppendLine($"{OPTION__COLUMN_IDX__TYPE}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.type]}");
			sb.AppendLine($"{OPTION__COLUMN_IDX__SOURCE}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.source]}");
			sb.AppendLine($"{OPTION__COLUMN_IDX__SUB_NAME}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.sub_name]}");
			sb.AppendLine($"{OPTION__COLUMN_IDX__EXTENSION}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.extension]}");
			sb.AppendLine($"{OPTION__COLUMN_IDX__PROVIDERS}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.providers]}");
			sb.AppendLine($"{OPTION__COLUMN_IDX__DESC}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.desc]}");
			sb.AppendLine($"{OPTION__COLUMN_IDX__PATH}: {DATA_GRID_VIEW.m_s_Indices[(int)DATA.e_Column.path]}");

			File.WriteAllText(m_k_CONFIG_FILE_TMP, sb.ToString(), Encoding.UTF8);

			if(File.Exists(m_k_CONFIG_FILE))
				File.Delete(m_k_CONFIG_FILE);

			File.Move(m_k_CONFIG_FILE_TMP, m_k_CONFIG_FILE);

			// 11: 保存配置文件 {0:s}
			COMMON.add_log(string.Format(LANGUAGES.txt(11), m_k_CONFIG_FILE), Color.Blue);

			m_s_dirty = false;
		}
	};
}	// namespace sub_db
