using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenDropper.Model
{
    //This class is used as an event arguments for the event in KeyboardHook class
    public class KeyboardHookEventArgs:EventArgs
    {
        public bool IsActive;
        public KeyboardHookEventArgs(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
