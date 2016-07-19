using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using ScreenDropper.ViewModel;
using System.Windows.Controls.Primitives;

namespace ScreenDrop.View
{
    /// <summary>
    /// Interaction logic for Dropper.xaml
    /// </summary>
    public partial class Dropper : System.Windows.Controls.UserControl
    {
        public DropperManager Manager;
        public Dropper()
        {
            InitializeComponent();
            Manager=new DropperManager();
            DataContext = Manager;
        }
    }
}
