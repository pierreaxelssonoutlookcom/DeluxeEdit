using Model.Interface;
using Model;
using System;

using Extensions;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Shared;
using System.Windows.Controls;
using DeluxeEdit.DefaultPlugins;
using MS.WindowsAPICodePack.Internal;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using DefaultPlugins.Model;

namespace DefaultPlugins.ViewModel
{
    public class NewFileViewModel
    {
        private INamedActionPlugin plugin;
        private TabControl currentTab;

        public NewFileViewModel(TabControl tab)
        {
            plugin = AllPlugins.InvokePlugin(PluginType.FileNew);
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