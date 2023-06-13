using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DeluxeEdit.DefaultPlugins.ViewModel
{
    public class MainEditViewModel: INotifyPropertyChanged
    {
        // Declare the event
        public event PropertyChangedEventHandler? PropertyChanged;
        public string Text { get; set; }
        public MainEditViewModel()
        {
            Text = string.Empty;
        }

         

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.

        public void Show()

        {
            OnPropertyChanged(); 
        }
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Text));
            
        }   
    }
}
