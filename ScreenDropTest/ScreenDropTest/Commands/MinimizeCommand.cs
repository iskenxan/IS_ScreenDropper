using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ScreenDropTest.Commands
{
    //This command is used for minimizing the window
    class MinimizeCommand:ICommand
    {
        CommandManager manager;
        public MinimizeCommand(CommandManager manager)
        {
            this.manager = manager;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            manager.Window.WindowState = WindowState.Minimized;
        }


        public event EventHandler CanExecuteChanged;
    }
}
