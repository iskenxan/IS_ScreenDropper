using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ScreenDropper.ViewModel;

namespace ScreenDropper.Model
{
    class KeyboardHook:ObservableObject
    {
        public delegate void ShortCutEventHandler(object sender, EventArgs e);

        private bool isActive = false;
        public event ShortCutEventHandler OnShortCut;
         private const int WH_KEYBOARD_LL = 13;

    private const int WM_KEYDOWN = 0x0100;

    private LowLevelKeyboardProc _proc;

    private static IntPtr _hookID = IntPtr.Zero;

    public KeyboardHook()
    {
        _proc = HookCallback;
    }
        public void Start()
        {
            
            _hookID = SetHook(_proc);
        }
        public void Stop()
        {
            UnhookWindowsHookEx(_hookID);
        }


    private static IntPtr SetHook(LowLevelKeyboardProc proc)

    {

        using (Process curProcess = Process.GetCurrentProcess())

        using (ProcessModule curModule = curProcess.MainModule)

        {

            return SetWindowsHookEx(WH_KEYBOARD_LL, proc,

                GetModuleHandle(curModule.ModuleName), 0);

        }

    }


    private delegate IntPtr LowLevelKeyboardProc(

        int nCode, IntPtr wParam, IntPtr lParam);


    private  IntPtr HookCallback(

        int nCode, IntPtr wParam, IntPtr lParam)

    {

        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)

        {

            int vkCode = Marshal.ReadInt32(lParam);
            //Checks to see if CTRL+D is pressed
            if ((Keys)vkCode == Keys.D && Control.ModifierKeys==Keys.Control)
            {
                if(isActive)
                {
                    isActive = false;
                    OnShortCut(this, new KeyboardHookEventArgs(isActive));
                }
                else
                {
                    isActive = true;
                    OnShortCut(this, new KeyboardHookEventArgs(isActive));
                }
            }
        }

        return CallNextHookEx(_hookID, nCode, wParam, lParam);

    }


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern IntPtr SetWindowsHookEx(int idHook,

        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    [return: MarshalAs(UnmanagedType.Bool)]

    private static extern bool UnhookWindowsHookEx(IntPtr hhk);


    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

        IntPtr wParam, IntPtr lParam);


    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
