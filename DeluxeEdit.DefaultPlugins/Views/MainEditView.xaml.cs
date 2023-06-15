using DeluxeEdit.DefaultPlugins.ViewModel;
using DeluxeEdit.Model;
using DeluxeEdit.Model.Interface;
using System.Windows.Controls;


namespace DeluxeEdit.DefaultPlugins.Views
{
    /// <summary>
    /// Interaction logic for MainEdit.xaml
    /// </summary>
    public partial class MainEdit : UserControl
    {
        private MainEditViewModel editViewModel;

        public MainEdit()
        {
            InitializeComponent();
            editViewModel = new MainEditViewModel();

            MainEditBox.Text = editViewModel.Text; 


        }

        public void UpdateBeforeLoad(INamedActionPlugin plugin, ActionParameter parameter)
        {
            new FileOpenPlugin();
        }
        public void UpdateBeforeSave(INamedActionPlugin plugin, ActionParameter parameter)
        {


        }

    }
}
