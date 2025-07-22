using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sub_db
{
	internal class COMMON
	{
		internal const string	m_k_PROGRAM_NAME		= "Subtitles Database";
		internal const string	m_k_VERSION				= "v0.23";

		internal const int		m_k_MAX_PROGRESS_VALUE	= 10000;

		/*==============================================================
		 * 添加日志
		 *==============================================================*/
		internal static void add_log(string txt, Color color = default)
		{
			FORMS.invoke(() =>
			{
				frm_Mainform.m_s_mainform.m_Log.add_log(txt, color);
			});
		}

		/*==============================================================
		 * 打开 URL
		 *==============================================================*/
		internal static void	OpenURL(string url)
		{
			ProcessStartInfo psi = new()
			{
				FileName		= url,
				UseShellExecute	= true	// 确保 URL 由 shell 处理（默认浏览器）
			};

			Process.Start(psi);
		}

		// 导入 Windows API 的 StrCmpLogicalW 函数（Windows 资源管理器的自然排序）
		[DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
		internal static extern int StrCmpLogicalW(string psz1, string psz2);

		/*==============================================================
		 * 生成所有简繁体的排列组合
		 *==============================================================*/
		internal static List<string>	GenerateSimplifiedTraditionalCombinations(string input)
		{
			// 1、转换为全简体和全繁体
			string chs = ChineseConverter.Convert(input, ChineseConversionDirection.TraditionalToSimplified);
			string cht = ChineseConverter.Convert(input, ChineseConversionDirection.SimplifiedToTraditional);

			// 2、找到不同的字符位置
			List<(int idx, char chs_char, char cht_char)> differences = new();
			for(int i = 0; i < chs.Length && i < cht.Length; ++i)
			{
				if(chs[i] != cht[i])
					differences.Add((i, chs[i], cht[i]));
			}	// for

			// 3、生成所有可能的组合
			List<string> combinations = new();

			void GenerateCombinations(char[] current, int diffIndex)
			{
				if(diffIndex >= differences.Count)
				{
					combinations.Add(new string(current));
					return;
				}

				var diff = differences[diffIndex];

				// 尝试简体字符
				current[diff.idx] = diff.chs_char;
				GenerateCombinations(current, diffIndex + 1);

				// 尝试繁体字符
				current[diff.idx] = diff.cht_char;
				GenerateCombinations(current, diffIndex + 1);
			}

			GenerateCombinations(chs.ToCharArray(), 0);
			return combinations;
		}
	};
}	// namespace sub_db
