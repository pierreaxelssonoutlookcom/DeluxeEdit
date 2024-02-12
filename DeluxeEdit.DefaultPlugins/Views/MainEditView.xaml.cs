using DefaultPlugins.ViewModel;
using Model;
using System.Windows.Controls;
using Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Formats.Tar;

namespace DefaultPlugins.Views
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

            // temporary call
            //currenContents =editViewModel.UpdateLoad();
        }
        public void addOrUpddateTab(string header)
        {
            if (TabÉxist(header, TabFiles) ==false)
            { 
              var item = new TabItem { Header = header };
              TabFiles.Items.Add(item);
            }
        }
        public static bool TabÉxist(string header, TabControl control)
        {
            bool result=false;
            foreach(TabItem x in control.Items)
            {
                if (x.Header == header)
                {
                    result = true;
                    break;
                }

            }
            return result; 
        }

        private void Grid_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            MainEditViewModel.CurrenContent = editViewModel.KeyDown();
            if (MainEditViewModel.CurrenContent == null) return;



        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            MainEditViewModel.CurrenContent = MainEditViewModel.AllContents.First(p => p.Header == (e.Source as TabItem).Header);
            editViewModel.ChangeTab(MainEditViewModel.CurrenContent);

            MainEditViewModel.AllContents.Add(MainEditViewModel.CurrenContent);

            editViewModel.ChangeTab(MainEditViewModel.CurrenContent);

           // addTab(MainEditViewModel.CurrenContent.Header);
///       //     MainEditViewModel.AllContents.Add(MainEditViewModel.CurrenContent);


        }

        private void MainEditBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            editViewModel.ScrollTo(e.NewValue);
            MainEditBox.Text = MainEditViewModel.CurrenContent.Content;
        }

        
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            editViewModel = new MainEditViewModel();
            var  menu = editViewModel.LoadMenu();



            foreach (var item in menu )
            {
                int index= MainMenu.Items.Add( new MenuItem {  Header= item.Header });

                foreach (var inner in item.MenuItems)
                {
                    MenuItem newExistMenuItem = (MenuItem)this.MainMenu.Items[index];
                    newExistMenuItem.Items.Add(new MenuItem { Header = inner.Title });



                }





            }

        }

        private void MainEditBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var keyeddata = editViewModel.KeyDown();
            if (keyeddata == null) e.Handled = false;
            else
            {
                MainEditBox.Text = keyeddata.Content;
                addOrUpddateTab(keyeddata.Header);
                e.Handled = true;
            }

            
        }

        private void TabFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainEditViewModel.CurrenContent = MainEditViewModel.AllContents.First(p => p.Header == (e.Source as TabItem).Header);
            editViewModel.ChangeTab(MainEditViewModel.CurrenContent);


        }
    }
}
