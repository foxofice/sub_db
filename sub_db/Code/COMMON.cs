using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace sub_db
{
	internal class COMMON
	{
		internal const string	m_k_PROGRAM_NAME		= "Subtitles Database";
		internal const string	m_k_VERSION				= "v0.22";

		internal const int		m_k_MAX_PROGRESS_VALUE	= 10000;

		// 热键 ID
		internal enum e_HotKeyID
		{
			OpenDir	= 1,	// 打开本地文件夹
			OpenURL,		// 打开远程链接
			Search,			// 查找
			UpdateDB,		// 更新数据库

			MAX,
		};

		[Flags()]
		public enum e_KeyModifiers
		{
			None		= 0,
			Alt			= 1,
			Ctrl		= 2,
			Shift		= 4,
			WindowsKey	= 8
		};

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool RegisterHotKey(IntPtr hWnd, int id, e_KeyModifiers fsModifiers, Keys vk);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

		/*==============================================================
		 * 设置任务栏进度
		 *==============================================================*/
		internal static void	SetProgressValue(int currentValue)
		{
			frm_Mainform.m_s_mainform.m_UpdateDatabase.progressBar_Update.Value = currentValue;

			if(Environment.OSVersion.Version.Major >= 6)
			{
				if(TaskbarManager.IsPlatformSupported)
					TaskbarManager.Instance.SetProgressValue(currentValue, m_k_MAX_PROGRESS_VALUE);
			}
		}

		/*==============================================================
		 * 注册热键
		 *==============================================================*/
		internal static void	RegHotKey(IntPtr hwnd, int hotKeyId, e_KeyModifiers keyModifiers, Keys key)
		{
			if(!RegisterHotKey(hwnd, hotKeyId, keyModifiers, key))
			{
				int errorCode = Marshal.GetLastWin32Error();

				string err_txt = (errorCode == 1409) ? "热键被占用！" : $"注册热键失败！({errorCode})";

				frm_Mainform.m_s_mainform.toolStripStatusLabel_ErrorMsg.Text		= err_txt;
				frm_Mainform.m_s_mainform.toolStripStatusLabel_ErrorMsg.Visible	= true;
			}
		}

		/*==============================================================
		 * 注销热键
		 *==============================================================*/
		internal static void	UnRegHotKey(IntPtr hwnd, int hotKeyId)
		{
			UnregisterHotKey(hwnd, hotKeyId);
		}
	};
}	// namespace sub_db
