using Model;
using System.Windows.Controls;
using System.Windows;
using DefaultPlugins;
using System;
using System.Net.NetworkInformation;
using ViewModel;
using Views;

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
            
            
            Content = new MainEdit();

            SizeToContent=SizeToContent.Width;

 //             if (WindowState == WindowState.Maximized)
     //         {
              //  userControl.Width = int.Parse( Width.ToString());
            //    userControl.Height = int.Parse(Height.ToString());
   //           }

        }
        private void PlugiSns_Click(object sender, RoutedEventArgs e)
        {
       }

        private void PluginFiles_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
