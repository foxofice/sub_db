using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sub_db
{
	internal class DATA
	{
		// 字幕信息
		internal class c_SubInfo
		{
			internal DateTime	m_time		= default;	// 最早放送日期

			// 番剧名称
			internal string		m_name_chs	= "";		// (简体)
			internal string		m_name_cht	= "";		// (繁体)
			internal string		m_name_jp	= "";		// (日文)
			internal string		m_name_en	= "";		// (英文)
			internal string		m_name_rome	= "";		// (罗马字)

			internal string		m_type		= "";		// 分类（animation/movie/...）
			internal string		m_source	= "";		// 字幕匹配的片源（DB/DVD/TV/test/...）
			internal string		m_sub_name	= "";		// 字幕名称
			internal string		m_extension	= "";		// 字幕后缀名（多种格式时用;分割，例如：.ass;.srt）
			internal string		m_providers	= "";		// 字幕组/提供者
			internal string		m_desc		= "";		// 字幕说明

			internal string		m_path		= "";		// 路径
		};

		internal const string				m_k_DB_FILENAME	= "Files\\db.xml";

		// 字幕列表
		internal static List<c_SubInfo>		m_s_all_subs	= new();

		internal static DataTable			m_s_dt			= new("subs");
		internal static DataTable			m_s_dt_search	= new("subs");

		// 片源（BD/TV/Web...）
		internal static SortedSet<string>	m_s_source_list	= new();

		// 数据各列的名字
		internal enum e_Column
		{
			time,

			name_chs,
			name_cht,
			name_jp,
			name_en,
			name_rome,

			type,
			source,
			sub_name,
			extension,
			providers,
			desc,
			path,

			MAX,
		};

		/*==============================================================
		 * 自动创建表结构
		 *==============================================================*/
		internal static void	auto_create_schema()
		{
			if(m_s_dt.Columns.Count == 0)
			{
				bool DataGridView_event_enable = frm_Mainform.m_s_mainform.m_DataGridView_event_enable;
				frm_Mainform.m_s_mainform.m_DataGridView_event_enable = false;

				var columns_desc = new List<(e_Column col_name, string type_name)>
				{
					(e_Column.time,		"System.DateTime"),

					(e_Column.name_chs,	"System.String"),
					(e_Column.name_cht,	"System.String"),
					(e_Column.name_jp,	"System.String"),
					(e_Column.name_en,	"System.String"),
					(e_Column.name_rome,"System.String"),

					(e_Column.type,		"System.String"),
					(e_Column.source,	"System.String"),
					(e_Column.sub_name,	"System.String"),
					(e_Column.extension,"System.String"),
					(e_Column.providers,"System.String"),
					(e_Column.desc,		"System.String"),
					(e_Column.path,		"System.String"),
				};

				foreach(var desc in columns_desc)
					m_s_dt.Columns.Add(desc.col_name.ToString(), Type.GetType(desc.type_name)!);

				m_s_dt_search = m_s_dt.Clone();

				frm_Mainform.m_s_mainform.m_DataGridView_event_enable = DataGridView_event_enable;
			}
		}

		/*==============================================================
		 * c_SubInfo <--> DataTable
		 *==============================================================*/
		static DataRow	SubInfo_to_DR(c_SubInfo sub_info)
		{
			DataRow dr = m_s_dt.NewRow();

			dr[e_Column.time.ToString()]		= sub_info.m_time;

			dr[e_Column.name_chs.ToString()]	= sub_info.m_name_chs;
			dr[e_Column.name_cht.ToString()]	= sub_info.m_name_cht;
			dr[e_Column.name_jp.ToString()]		= sub_info.m_name_jp;
			dr[e_Column.name_en.ToString()]		= sub_info.m_name_en;
			dr[e_Column.name_rome.ToString()]	= sub_info.m_name_rome;

			dr[e_Column.type.ToString()]		= sub_info.m_type;
			dr[e_Column.source.ToString()]		= sub_info.m_source;
			dr[e_Column.sub_name.ToString()]	= sub_info.m_sub_name;
			dr[e_Column.extension.ToString()]	= sub_info.m_extension;
			dr[e_Column.providers.ToString()]	= sub_info.m_providers;
			dr[e_Column.desc.ToString()]		= sub_info.m_desc;
			dr[e_Column.path.ToString()]		= sub_info.m_path;

			return dr;	
		}
		//--------------------------------------------------
		static c_SubInfo	DR_to_SubInfo(DataRow dr)
		{
			c_SubInfo sub_info = new();

			sub_info.m_time			= (DateTime)dr[e_Column.time.ToString()];

			sub_info.m_name_chs		= (string)dr[e_Column.name_chs.ToString()];
			sub_info.m_name_cht		= (string)dr[e_Column.name_cht.ToString()];
			sub_info.m_name_jp		= (string)dr[e_Column.name_jp.ToString()];
			sub_info.m_name_en		= (string)dr[e_Column.name_en.ToString()];
			sub_info.m_name_rome	= (string)dr[e_Column.name_rome.ToString()];

			sub_info.m_type			= (string)dr[e_Column.type.ToString()];
			sub_info.m_source		= (string)dr[e_Column.source.ToString()];
			sub_info.m_sub_name		= (string)dr[e_Column.sub_name.ToString()];
			sub_info.m_extension	= (string)dr[e_Column.extension.ToString()];
			sub_info.m_providers	= (string)dr[e_Column.providers.ToString()];
			sub_info.m_desc			= (string)dr[e_Column.desc.ToString()];
			sub_info.m_path			= (string)dr[e_Column.path.ToString()];

			return sub_info;
		}

		/*==============================================================
		 * m_s_all_subs -> DataTable
		 *==============================================================*/
		internal static void	Data_to_DT()
		{
			auto_create_schema();

			m_s_dt.Rows.Clear();

			foreach(c_SubInfo sub_info in m_s_all_subs)
				m_s_dt.Rows.Add(SubInfo_to_DR(sub_info));
		}

		/*==============================================================
		 * 从数据库文件读取数据
		 *==============================================================*/
		internal static void	read_data_from_file()
		{
			if(!File.Exists(m_k_DB_FILENAME))
				return;

			auto_create_schema();

			m_s_dt.Rows.Clear();
			m_s_dt.ReadXml(m_k_DB_FILENAME);

			m_s_all_subs.Clear();

			foreach(DataRow dr in m_s_dt.Rows)
				m_s_all_subs.Add(DR_to_SubInfo(dr));

			update_source_list();
		}

		/*==============================================================
		 * 获取 Types
		 *==============================================================*/
		internal static string[]	get_types(bool from_DataTable)
		{
			if(from_DataTable)
			{
				SortedSet<string> types = new();

				foreach(c_SubInfo sub_info in m_s_all_subs)
					types.Add(sub_info.m_type);

				return types.ToArray();
			}
			else
			{
				if(!Directory.Exists(CONFIG.SUBS.m_s_path))
					return [];

				string[] dirs_type = Directory.GetDirectories(CONFIG.SUBS.m_s_path, "*.*", SearchOption.TopDirectoryOnly);

				for(int i=0; i<dirs_type.Length; ++i)
					dirs_type[i] = Path.GetFileName(dirs_type[i]);

				return dirs_type;
			}
		}

		/*==============================================================
		 * 更新 Source 列表
		 *==============================================================*/
		static void	update_source_list()
		{
			m_s_source_list.Clear();

			foreach(c_SubInfo sub_info in m_s_all_subs)
				m_s_source_list.Add(sub_info.m_source);
		}
	};
}	// namespace sub_db
