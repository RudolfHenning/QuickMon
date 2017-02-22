using System;
using System.Runtime.InteropServices;
using System.Text;

namespace HenIT.Runtime.InteropServices.APIs
{
	public class APIsUxTheme
	{
		[DllImport("UxTheme.dll", CharSet=CharSet.Auto)]
		static public extern IntPtr OpenThemeData(
			IntPtr hWnd, string pszClassList);
		[DllImport("UxTheme.dll", CharSet=CharSet.Auto)]
		static public extern int CloseThemeData(IntPtr hTheme);
		[DllImport("UxTheme.dll", CharSet=CharSet.Auto)]
		static public extern bool IsThemeActive();
		[DllImport("UxTheme.dll", CharSet=CharSet.Auto)]
		static public extern bool IsAppThemed();
		[DllImport("UxTheme.dll", CharSet=CharSet.Auto)]
		static public extern int DrawThemeBackground(
			IntPtr hWnd, IntPtr hDc, int iPartId, int iStateId,
			APIsStructs.RECT pRect, APIsStructs.RECT pClipRect);
		[DllImport("UxTheme.dll", CharSet=CharSet.Auto)]
		static public extern int GetCurrentThemeName(
			StringBuilder pszThemeFileName, int dwMaxNameChars,
			StringBuilder pszColorBuff, int cchMaxColorChars,
			StringBuilder pszSizeBuff, int cchMaxSizeChars);
	}
}
