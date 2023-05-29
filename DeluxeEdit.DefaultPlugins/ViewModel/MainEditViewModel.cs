using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeEdit.DefaultPlugins.ViewModel
{
    public class MainEditViewModel: INotifyPropertyChanged
    {
        private MainEdit mainEdit;

        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;
        public MainEditViewModel()
        {
            mainEdit = new MainEdit();
            
        }


  //      OnPropertyChange();

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    
        public void Show()
        { 
            
        }
    }
}
