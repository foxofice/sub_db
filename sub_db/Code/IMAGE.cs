using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
	};
}	// namespace sub_db
