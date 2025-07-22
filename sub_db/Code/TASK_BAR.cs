using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sub_db
{
	internal class TASK_BAR
	{
		// 定义 ITaskbarList3 接口
		[ComImport]
		[Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		private interface ITaskbarList3
		{
			// ITaskbarList
			void HrInit();
			void AddTab(IntPtr hwnd);
			void DeleteTab(IntPtr hwnd);
			void ActivateTab(IntPtr hwnd);
			void SetActiveAlt(IntPtr hwnd);

			// ITaskbarList2
			void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

			// ITaskbarList3
			void SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);
			void SetProgressState(IntPtr hwnd, TBPFLAG tbpFlags);
		}

		// 任务栏进度状态标志
		private enum TBPFLAG
		{
			TBPF_NOPROGRESS		= 0,
			TBPF_INDETERMINATE	= 0x1,
			TBPF_NORMAL			= 0x2,
			TBPF_ERROR			= 0x4,
			TBPF_PAUSED			= 0x8,
		}

		// COM 类定义
		[ComImport]
		[Guid("56FDF344-FD6D-11d0-958A-006097C9A090")]
		[ClassInterface(ClassInterfaceType.None)]
		private class TaskbarList { }

		static ITaskbarList3?	m_s_taskbar	= null;
		static IntPtr			m_s_Handle	= 0;

		/*==============================================================
		 * 自动初始化
		 *==============================================================*/
		static void auto_init()
		{
			if(m_s_taskbar == null)
			{
				m_s_taskbar = (ITaskbarList3)new TaskbarList();
				m_s_taskbar.HrInit();

				m_s_Handle = Process.GetCurrentProcess().MainWindowHandle;

				Show();
			}
		}

		/*==============================================================
		 * 显示任务栏进度
		 *==============================================================*/
		internal static void	Show()
		{
			m_s_taskbar!.SetProgressState(m_s_Handle, TBPFLAG.TBPF_NORMAL);
		}

		/*==============================================================
		 * 隐藏任务栏进度
		 *==============================================================*/
		internal static void	Hide()
		{
			m_s_taskbar!.SetProgressState(m_s_Handle, TBPFLAG.TBPF_NOPROGRESS);
		}

		/*==============================================================
		 * 隐藏任务栏进度
		 *==============================================================*/
		internal static void	SetProgressValue(ulong value, ulong max_value)
		{
			auto_init();
			m_s_taskbar!.SetProgressValue(m_s_Handle, value, max_value);
		}
	};
}	// namespace sub_db
