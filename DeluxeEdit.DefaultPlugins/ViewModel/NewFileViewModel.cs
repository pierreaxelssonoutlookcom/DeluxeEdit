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

namespace DefaultPlugins.ViewModel
{
    public class NewFileViewModel
    {
        private INamedActionPlugin plugin;

        public NewFileViewModel()
        {
            plugin = AllPlugins.InvokePlugin(PluginType.FileNew);
        }
        public ContentPath GetNewFile()
        {
            var result = new ContentPath { Header = "newfile.txt", Content = "" };
            return result;
            //             AddNewTextControl(control, "newfile.txt");
        }
        public void AddNewTextControl(TabControl control, string name)
        {

            WPFUtil.AddOrUpddateTab(name, control);

            var text = new TextBox();
            text.Name = name;
            text.KeyDown += Text_KeyDown;
            control.Items.Add(text);
        }
        private void Text_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var keyeddata = KeyDown();
            if (keyeddata == null) e.Handled = false;
            else
            {


                e.Handled = true;
            }
        }
        public ContentPath? KeyDown()
        {
            //done:cast enum from int
            ContentPath result = null;
            bool keysOkProceed = false;
            var matchCount = plugin.Configuration.KeyCommand.Keys
                .Cast<System.Windows.Input.Key>()
                .Count(p => System.Windows.Input.Keyboard.IsKeyDown(p));

            keysOkProceed = matchCount == plugin.Configuration.KeyCommand.Keys.Count && plugin.Configuration.KeyCommand.Keys.Count > 0;
            if (keysOkProceed) result = GetNewFile();


            return result;


        }
    }
}