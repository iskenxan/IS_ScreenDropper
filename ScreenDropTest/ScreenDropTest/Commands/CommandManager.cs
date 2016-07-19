using ScreenDropper.Model;
using ScreenDropTest.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ScreenDropTest.Commands
{
    class CommandManager:ObservableObject
    {
        public CloseCommand CloseCommand { get { return closeCommand; } }
        public MinimizeCommand MinimizeCommand { get { return minimizeCommand; } }
        public MaximizeCommand MaximizeCommand { get { return maximizeCommand; } }

        //used to change the source of the image inside the maximize button depending on the state of the window
        public BitmapImage MaximizeSource { get { return maximizeSource; } set { maximizeSource = value; OnPropertyChanged("MaximizeSource"); } }
        public Window Window { get { return window; } }
        BitmapImage maximizeSource;
        MaximizeCommand maximizeCommand;
        MinimizeCommand minimizeCommand;
        CloseCommand closeCommand;
        Window window;
        public CommandManager(Window window)
        {
            this.window = window;
            closeCommand = new CloseCommand(this);
            minimizeCommand = new MinimizeCommand(this);
            maximizeCommand = new MaximizeCommand(this);
            maximizeSource = new BitmapImage(new Uri("Resources/maximize.png", UriKind.Relative));
        }
    }
}
