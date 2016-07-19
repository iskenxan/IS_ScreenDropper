using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Windows.Media;

namespace ScreenDropper.Model
{
    //This class is used to set up mouse hook that fires when user presses left mouse.
    //It takes a screen shot and finds out the color of the pixel at the location that user pressed and stores its values at the databound properties
    public class MouseHook : ObservableObject
    {
        private LowLevelMouseProc _proc;

        private static IntPtr _hookID = IntPtr.Zero;
        ScreenCapture screenCapture;
        ColorConverter converter;
        Color color;

        int r = 0, g = 0, b = 0;
        string hex = String.Empty;
        //RGB color values
        public int R { get { return r; } set { r = value; OnPropertyChanged("R"); } }
        public int G { get { return g; } set { g = value; OnPropertyChanged("G"); } }
        public int B { get { return b; } set { b = value; OnPropertyChanged("B"); } }

        //Hexadecimal value
        public string HEX { get { return hex; } set { hex = value; OnPropertyChanged("HEX"); } }
        public void Start()
        {
            screenCapture = new ScreenCapture();
            converter = new ColorConverter();
            color = new Color();
            _proc = HookCallback;
            _hookID = SetHook(_proc);


        }
        public void Stop()
        {
            User32.UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {

            using (Process curProcess = Process.GetCurrentProcess())

            using (ProcessModule curModule = curProcess.MainModule)
            {

                return User32.SetWindowsHookEx(WH_MOUSE_LL, proc,

                    User32.GetModuleHandle(curModule.ModuleName), 0);

            }

        }


        public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);


        private IntPtr HookCallback(

            int nCode, IntPtr wParam, IntPtr lParam)
        {

            if (nCode >= 0 &&

                MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {

                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                int curX = hookStruct.pt.x;
                int curY = hookStruct.pt.y;

                //var cursorPos = Cursor.Position;

                // This isn't ideal, but it fixes the coordinate system:
                curX -= (int)SystemParameters.VirtualScreenLeft;
                curY -= (int)SystemParameters.VirtualScreenTop;

                color = converter.GetColor(screenCapture.CaptureScreen(), curX, curY);

                R = color.R;
                G = color.G;
                B = color.B;

                HEX = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            }

            return User32.CallNextHookEx(_hookID, nCode, wParam, lParam);

        }


        private const int WH_MOUSE_LL = 14;


        private enum MouseMessages
        {

            WM_LBUTTONDOWN = 0x0201,

            WM_LBUTTONUP = 0x0202,

            WM_MOUSEMOVE = 0x0200,

            WM_MOUSEWHEEL = 0x020A,

            WM_RBUTTONDOWN = 0x0204,

            WM_RBUTTONUP = 0x0205

        }


        [StructLayout(LayoutKind.Sequential)]

        private struct POINT
        {

            public int x;

            public int y;

        }


        [StructLayout(LayoutKind.Sequential)]

        private struct MSLLHOOKSTRUCT
        {

            public POINT pt;

            public uint mouseData;

            public uint flags;

            public uint time;

            public IntPtr dwExtraInfo;

        }




    }
}
