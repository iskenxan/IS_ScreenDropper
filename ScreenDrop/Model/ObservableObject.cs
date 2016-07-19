using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenDropper.Model
{
   public  abstract class ObservableObject:INotifyPropertyChanged
    {
       //This abstract class provides classes inheriting from it with the way to use binding properly
        public event PropertyChangedEventHandler PropertyChanged;

       //This method is used to be called every time a value of the bound property is updated
       public virtual void OnPropertyChanged(string propName)
        {
            var pc = PropertyChanged;
           if(pc!=null)
           {
               pc(this, new PropertyChangedEventArgs(propName));
           }
        }
    }
}
