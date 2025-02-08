using DefaultPlugins;
using ICSharpCode.AvalonEdit;
using Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace ViewModel
{
    public partial class MainEditViewModel
    {
        private void ItemForSelectedText(object sender, RoutedEventArgs e)
        {
            paramerIsSelectedText.Invoke(sender);
            ;
        }
        private async void  NewMenu_Click(object sender, RoutedEventArgs e)
        {
            await newFile.Load();
        }

        private async void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            await loadFile.Load();
        }
 
        private async void HexViewMenu_Click(object sender, RoutedEventArgs e)
        {
            await hex.LoadHexView();
        }

        private async void SaveAsMenu_Click(object sender, RoutedEventArgs e)
        {
            await saveFile.SaveAs();        }

        private async void SaveMenu_Click(object sender, RoutedEventArgs e)
        {
           await saveFile.Save();
        }


        private async void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (e.Source is MenuItem)
            {
                var clicked = e.Source is MenuItem ? e.Source as MenuItem : null;

                if (clicked != null) await DoCommand(clicked);

            }
        }

        public void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //   if (!lastFileLength.HasValue) return;

            var percent = e.NewValue;
            //progressText.Text = $"{percent}%%";

        }   
        private void TabFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var casted = tabFiles.SelectedItem != null && tabFiles.SelectedItem is TabItem ? tabFiles.SelectedItem as TabItem : null;
            if (casted != null) ChangeTab(casted);
        }
        public void Text_TextChanged(object? sender, EventArgs e)
        {
            textChange.Load();
   
        }
        private void TabFiles_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var keyeddata = KeyDown();
            if (keyeddata == null) e.Handled = false;
            else
                e.Handled = true;
        }

        public void Text_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var keyeddata = KeyDown();
            if (keyeddata == null) 
                e.Handled = false;
            else
             e.Handled = true;
            
        }

        public async Task<MyEditFile?> KeyDown()
        {
            //done:cast enum from int
            MyEditFile? result = null;
            bool keysOkProceed = false;
            foreach (var plugin in relevantPlugins)
            {
                var keys = plugin.Configuration.KeyCommand.Keys;
                var matchCount = 
                keys.Count(p => System.Windows.Input.Keyboard.IsKeyDown(p));
                
                keysOkProceed = (matchCount == keys.Count) && keys.Count>0;
                if (keysOkProceed)
                {
                    if (plugin is FileOpenPlugin)
                        result = await loadFile.Load();
                    else if (plugin is FileSavePlugin)
                        await saveFile.Save();
                    else if (plugin is FileSaveAsPlugin)
                       await saveFile.SaveAs();
                    else if (plugin is FileNewPlugin)
                        await newFile.Load();
                    else if (plugin is HexPlugin)
                        await hex.Load();


                }

            }
            return result;
        }




    }
}
