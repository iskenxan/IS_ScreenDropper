using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ScreenDropTest.Commands
{
    class MaximizeCommand:ICommand
    {
        //This command is used for maximizing/setting to normal window and switching the icons of the maximize button
        CommandManager manager;
        public MaximizeCommand(CommandManager manager)
        {
            this.manager = manager;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (manager.Window.WindowState == WindowState.Normal)
            {
                manager.MaximizeSource = new BitmapImage(new Uri("Resources/restore.png",UriKind.Relative));
                manager.Window.WindowState = WindowState.Maximized;
            }

            else if (manager.Window.WindowState == WindowState.Maximized)
            {
                manager.MaximizeSource = new BitmapImage(new Uri("Resources/maximize.png",UriKind.Relative));
                manager.Window.WindowState = WindowState.Normal;
            }
                
        }


        public event EventHandler CanExecuteChanged;
    }
}
