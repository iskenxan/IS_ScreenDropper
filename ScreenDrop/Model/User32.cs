using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenDropper.Model
{
    class User32
    {
        //This  methods are imported from Window System Library and are used to take screen shots of the desktop in ScreenCapture class
 
        [DllImport("user32.dll")]
        public extern static IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string cls, string win);


      //This  methods are imported from Window System Library and are used in MouseHook class to set up mouse hook
          [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    public static extern IntPtr SetWindowsHookEx(int idHook,

        ScreenDropper.Model.MouseHook.LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    [return: MarshalAs(UnmanagedType.Bool)]

    public static extern bool UnhookWindowsHookEx(IntPtr hhk);


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

        IntPtr wParam, IntPtr lParam);


    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    public static extern IntPtr GetModuleHandle(string lpModuleName);


    }
}
