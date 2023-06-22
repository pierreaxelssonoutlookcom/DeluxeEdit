using DeluxeEdit.DefaultPlugins.Managers;
using DeluxeEdit.DefaultPlugins.ViewModel;
using DeluxeEdit.Model;
using DeluxeEdit.Model.Interface;
using System.Windows.Controls;
using DeluxeEdit.Extensions;
using System;

namespace DeluxeEdit.DefaultPlugins.Views
{
    /// <summary>
    /// Interaction logic for MainEdit.xaml
    /// </summary>
    public partial class MainEdit : UserControl
    {
        private MainEditViewModel editViewModel;
        private PluginManager manager;

        public MainEdit()
        {
            InitializeComponent();
            editViewModel = new MainEditViewModel();

            manager = new PluginManager();
            UpdateLoad();
        }

        public void UpdateLoad()
        {
            var plugin = AllPlugins.InvokePlugin(PluginId.FileOpen);
            string? path=plugin.GuiAction(plugin);
            //if user cancelled path is empty 
            if (path.HasContent() && !String.IsNullOrEmpty(path))
            { 
                editViewModel.Text=plugin.Perform( new ActionParameter(path) );
                MainEditBox.Text = editViewModel.Text;
            }
        }
        public void UpdateBeforeSave(INamedActionPlugin plugin, ActionParameter parameter)
        {


        }

    }
}
