using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MAM.Console.Sniffer
{
    public static class Applications
    {
        public static Process[] GetD2RunningProcesses => Process.GetProcessesByName("dofus");

        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); //ShowWindow needs an IntPtr

        public static void FocusProcess(Process process)
        {
            IntPtr hWnd; //change this to IntPtr

            hWnd = process.MainWindowHandle; //use it as IntPtr not int
            ShowWindow(hWnd, 3);
            SetForegroundWindow(hWnd); //set to topmost
        }
    }
}
