using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace sub_db
{
	internal class PATH
	{
		internal const string	m_k_CHANGELOG_FILENAME	= "Files/changelog.txt";
		internal const string	m_k_CONFIG_FILENAME		= "Files/config.txt";
		internal const string	m_k_DB_FILENAME			= "Files/db.xml";

		internal const string	m_k_LANGUAGE_DIR		= "Files/Languages";

		/*==============================================================
		 * 打开所在的文件夹
		 *==============================================================*/
		internal static void	open_dir(string dir)
		{
			DirectoryInfo di = new DirectoryInfo(dir);

			// 打开所在文件夹
			if(Directory.Exists(dir))
				Process.Start("Explorer", $"/select,\"{di.FullName}\"");
		}
	};
}	// namespace sub_db
