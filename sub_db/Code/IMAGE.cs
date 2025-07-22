using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sub_db
{
	internal class IMAGE
	{
		/*==============================================================
		 * Image <--> Icon
		 *==============================================================*/
		internal static Icon	img2icon(Image img)
		{
			return Icon.FromHandle(((Bitmap)img).GetHicon());
		}
		internal static Image	icon2img(Icon icon)
		{
			return Image.FromHbitmap(icon.ToBitmap().GetHbitmap());
		}

		/*==============================================================
		 * 获取当前 exe 的 Icon
		 *==============================================================*/
		internal static Icon get_exe_icon()
		{
			return Icon.ExtractAssociatedIcon(Process.GetCurrentProcess().MainModule!.FileName)!;
		}
	};
}	// namespace sub_db
