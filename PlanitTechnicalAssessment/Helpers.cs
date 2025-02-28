using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PlanitTechnicalAssessment
{
    public class Helpers
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void MaximizeWindow()
        {
            var chromiumProcess = Process.GetProcessesByName("chrome")
            .FirstOrDefault(p => p.MainWindowHandle != IntPtr.Zero && p.StartTime > DateTime.Now.AddMinutes(-1));
            ShowWindow(chromiumProcess.MainWindowHandle, 3);
        }
    }
}
