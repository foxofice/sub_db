using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sub_db
{
	internal class SQL
	{
		/*==============================================================
		 * 修正字符串（转义字符）
		 *==============================================================*/
		internal static string	escape(string str, bool fix_RowFilter = true)
		{
			str = str.Replace("'", "''");

			if(!fix_RowFilter)
				return str;

			StringBuilder sb = new();

			foreach(char c in str)
			{
				switch(c)
				{
				case '*':
				case '%':
				case '[':
				case ']':
					sb.Append($"[{c}]");
					break;

				default:
					sb.Append(c);
					break;
				}
			}	// for

			return sb.ToString();
		}
	};
}	// namespace sub_db
