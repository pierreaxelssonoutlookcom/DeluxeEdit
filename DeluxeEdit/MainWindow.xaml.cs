using Model;
using System.Windows.Controls;
using System.Windows;
using DefaultPlugins;
using System;

namespace DeluxeEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            //todo:add usercontols dynamically
            var plugin = AllPlugins.InvokePlugin(PluginType.FileOpen);
            var control= plugin.CreateControl(false);
            UserControl? userControl = null;
             if (control is UserControl) userControl= control as UserControl;
            //UserControl? userControl = null;
            //userControl= control!=null && control is UserControl ? control as UserControl: null;
            if (userControl == null) throw new NullReferenceException(); 
            
            
            Content = userControl;

            SizeToContent=SizeToContent.Width;

 //             if (WindowState == WindowState.Maximized)
     //         {
              //  userControl.Width = int.Parse( Width.ToString());
            //    userControl.Height = int.Parse(Height.ToString());
   //           }

        }
        private void Plugins_Click(object sender, RoutedEventArgs e)
        {
       }

        private void PluginFiles_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
