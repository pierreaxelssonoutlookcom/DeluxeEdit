using Model.Interface;
using Model;
using System.Windows.Controls;











namespace DefaultPlugins.ViewModel
{
    public class NewFileViewModel
    {
        private INamedActionPlugin plugin;
        private TabControl currentTab;

        public NewFileViewModel(TabControl tab)
        {
            plugin = AllPlugins.InvokePlugin<FileNewPlugin>(PluginType.FileNew);
            currentTab = tab;
        }




        public MyEditFile GetNewFile()
        {
            var result = new MyEditFile { Path = "newfile.txt", Header = "newfile.txt", Content = "", IsNewFile = true };
            //        var combos= AddMyContols("newfile.txt");
            //           MyEditFiles.Files.Add(new MyEditFile { Header = result.Header });
            //result.Text = combos.Text;

            //            MyEditFiles.Add(result);



            return result;
        }

    }
}