using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sub_db
{
	internal class PATH
	{
		/*==============================================================
		 * 打开所在的文件夹
		 *==============================================================*/
		internal static void	open_dir(string dir)
		{
			Process.Start("explorer.exe", dir);
		}
	};
}	// namespace sub_db
