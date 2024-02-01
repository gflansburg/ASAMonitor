using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ASAMonitor
{
    public class NativeMethods
    {
        public class WindowTitle
        {
            public string Caption { get; set; }
            public string ClassName { get; set; }
            public IntPtr MainWindowHandle { get; set; }
            public int ProcessId { get; set; }
        }

        /// <summary> Find all windows that match the given filter </summary>
        /// <param name="filter"> A delegate that returns true for windows
        ///    that should be returned and false for windows that should
        ///    not be returned </param>
        public static IEnumerable<WindowTitle> FindWindows(EnumWindowsProc filter)
        {
            IntPtr found = IntPtr.Zero;
            List<WindowTitle> windows = new List<WindowTitle>();

            EnumWindows(delegate (IntPtr wnd, IntPtr param)
            {
                if (filter(wnd, param))
                {
                    // only add the windows that pass the filter
                    WindowTitle windowTitle = new WindowTitle()
                    {
                        Caption = GetWindowText(wnd),
                        MainWindowHandle = wnd,
                    };

                    int processId = 0;
                    GetWindowThreadProcessId(wnd, out processId);
                    windowTitle.ProcessId = processId;
                    windowTitle.ClassName = GetClassName(windowTitle.MainWindowHandle);
                    windows.Add(windowTitle);
                }

                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        // Delegate to filter which windows to include 
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary> Get the text for the window pointed to by hWnd </summary>
        public static string GetWindowText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            if (size > 0)
            {
                var builder = new StringBuilder(size + 1);
                GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }
            return String.Empty;
        }

        /// <summary> Find all windows that starts with the given title text </summary>
        /// <param name="titleText"> The text that the window title must start with. </param>
        public static IEnumerable<WindowTitle> FindWindowsStartsWithText(string titleText)
        {
            return FindWindows(delegate (IntPtr wnd, IntPtr param)
            {
                return GetWindowText(wnd).StartsWith(titleText, StringComparison.OrdinalIgnoreCase);
            });
        }

        public static IEnumerable<WindowTitle> FindWindowsStartsWithText(string titleText, string className)
        {
            return FindWindows(delegate (IntPtr wnd, IntPtr param)
            {
                return GetWindowText(wnd).StartsWith(titleText, StringComparison.OrdinalIgnoreCase) && GetClassName(wnd).Equals(className);
            });
        }

        public static IEnumerable<WindowTitle> FindWindowsEqualsText(string titleText)
        {
            return FindWindows(delegate (IntPtr wnd, IntPtr param)
            {
                return GetWindowText(wnd).Equals(titleText, StringComparison.OrdinalIgnoreCase);
            });
        }

        public static IEnumerable<WindowTitle> FindWindowsEqualsText(string titleText, string className)
        {
            return FindWindows(delegate (IntPtr wnd, IntPtr param)
            {
                return GetWindowText(wnd).Equals(titleText, StringComparison.OrdinalIgnoreCase) && GetClassName(wnd).Equals(className);
            });
        }

        public static string GetClassName(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetClassName(hWnd, sb, 1024);
            return sb.ToString();
        }

        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int processId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        public const uint SC_MINIMIZE = 0xf020;
        public const uint SC_MAXIMIZE = 0xF030;
        public const uint SC_CLOSE = 0xF060;
        public const uint WM_SYSCOMMAND = 0x0112;
    }
}
