using Model;
using System.Windows.Controls;
using DefaultPlugins;
using Extensions.Util;
using System.Formats.Tar;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit;
using System.IO;
using System.Windows;

namespace ViewModel
{
    public class NewFile
    {
        private TabControl tabFiles;
        private MainEditViewModel model;

        public NewFile(MainEditViewModel model, TabControl tab)
        {
            this.tabFiles = tab;
            this.model=model;   
        }



        public async Task<MyEditFile?> Load()
        {
            var file = GetNewFile();
            MyEditFiles.Add(file);
            var text = AddMyControlsForNew(file.Path);
            await Task.Delay(0);
            return file;



        }

        private  MyEditFile GetNewFile()
        {
            var result = new MyEditFile { Path = "newfile.txt", Header = "newfile.txt", Content = "", IsNewFile = true };
            //        var combos= AddMyContols("newfile.txt");
            //           MyEditFiles.Files.Add(new MyEditFile { Header = result.Header });
            //result.Text = combos.Text;

            //            MyEditFiles.Add(result);



            return result;
        }
        private TextEditor AddMyControlsForNew(string path, string? overrideTabNamePrefix = null)
        {
            var name = path;
            var text = new TextEditor();
            text.IsReadOnly = false;
            text.Name = name.Replace(".", "");
            text.Visibility = Visibility.Visible;
            text.KeyDown += model.Text_KeyDown;
            text.HorizontalAlignment = HorizontalAlignment.Stretch;
            text.VerticalAlignment = VerticalAlignment.Stretch;

            name = $"{overrideTabNamePrefix}{name}";
            var tab = WPFUtil.AddOrUpdateTab(name, tabFiles, text.TextArea);

            model.ChangeTab(tab);
            return text;

        }
        


    }
}