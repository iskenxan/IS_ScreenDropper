using ScreenDrop.View;
using ScreenDropper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ScreenDropTest.Commands
{
    class CloseCommand:ICommand
    {//This command closes the window and stops the Hooks set by the dropper control
        CommandManager manager;
        public CloseCommand(CommandManager manager)
        {
            this.manager = manager;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Dropper dropper = manager.Window.FindName("dropper") as Dropper;
            dropper.Manager.Stop();
            manager.Window.Close();
        }


        public event EventHandler CanExecuteChanged;
    }
}
