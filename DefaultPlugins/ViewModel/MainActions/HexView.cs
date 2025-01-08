using DefaultPlugins;
using Extensions.Util;
using ICSharpCode.AvalonEdit;
using Model;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ViewModel
{
    internal class HexView
    {
        private MainEditViewModel model;
         private ProgressBar progressBar;
        private FileTypeLoader fileTypeLoader;
        private HexPlugin hex;
        private TabControl tabFiles;
        public HexView(MainEditViewModel model, ProgressBar progressBar, TabControl tab)
        {
            this.model = model;
            this.tabFiles = tab;
            this.progressBar = progressBar;
            fileTypeLoader = new FileTypeLoader();
            hex = AllPlugins.InvokePlugin<HexPlugin>(PluginType.Hex);


        }
        public async Task<MyEditFile?> Load()
        {
            var result = new MyEditFile();
            if (MyEditFiles.Current == null || MyEditFiles.Current.Text == null) throw new NullReferenceException();

            model.SetStatusText($"Hex View:{MyEditFiles.Current.Path}");

            var progress = new Progress<long>(value => progressBar.Value = value);
            var parameter = new ActionParameter(MyEditFiles.Current.Path, MyEditFiles.Current.Encoding);
            var hexOutput = await hex.Perform(parameter, progress);
            
            result.Path = MyEditFiles.Current.Path;
            result.Content = hexOutput;
    
            var text = AddMyControls(result.Path, "hex:");
            text.Text = hexOutput;
            MyEditFiles.Add(result);


            return result;
        }
        public TextEditor AddMyControls(string path, string? overrideTabNamePrefix = null)
        {
            bool isNewFle = File.Exists(path) == false;
            var name = isNewFle ? path : new FileInfo(path).Name;
            TextEditor text;
            if (isNewFle)
                text = new TextEditor();
            else
            {
                fileTypeLoader.LoadCurrent(path);
                text = fileTypeLoader.CurrentText;
                progressBar.ValueChanged += model.ProgressBar_ValueChanged;
            }
            text.IsReadOnly = false;
            text.Name = name.Replace(".", "");
            text.Visibility = Visibility.Visible;
            text.KeyDown += model.Text_KeyDown;
            text.HorizontalAlignment = HorizontalAlignment.Stretch;
            text.VerticalAlignment = VerticalAlignment.Stretch;

            name = $"{overrideTabNamePrefix}{name}";
            var tab = WPFUtil.AddOrUpdateTab(name, tabFiles, fileTypeLoader.CurrentArea);

            model.ChangeTab(tab);
            return text;

        }
    }
}
