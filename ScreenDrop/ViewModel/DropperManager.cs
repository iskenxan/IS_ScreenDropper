using ScreenDropper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
   

namespace ScreenDropper.ViewModel
{
    //This class is used to set up binding in Dropper.xaml and provide some logic for hooks
    public class DropperManager:ObservableObject
    {
        //Texboxes in Dropper.xaml are bound to the properties of the instance of this class
        public MouseHook MouseHook { get { return mHook; } }
        //This property is bound to the toggle button that activates the mouse hook
        public bool IsWorking { get { return isWorking; } set { isWorking = value; if (value)Start(); else Stop(); OnPropertyChanged("IsWorking"); } }

        MouseHook mHook;
        KeyboardHook kHook;
        bool isWorking = false;

        public DropperManager()
        {
            mHook = new MouseHook();
            kHook=new KeyboardHook();
            kHook.OnShortCut += kHook_OnShortCut;
            kHook.Start();
        }

        void kHook_OnShortCut(object sender, EventArgs e)
        {//This event handler is called whenever user presses the short cut CTRL+D specified by the keyboard hook
            KeyboardHookEventArgs args = e as KeyboardHookEventArgs;
            if (args.IsActive)
            {
                if (!IsWorking)
                    IsWorking = true;
            }
            else
            {
                if (IsWorking)
                    IsWorking = false;
            }
        }
        public void Start()
        {
            mHook.Start();
        }
        public void Stop()
        {
            mHook.Stop();
        }
    }
}
