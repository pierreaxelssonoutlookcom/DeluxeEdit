using DefaultPlugins;
using Extensions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace ViewModel.MainActions
{
    public class ViewAs
    {
        private ProgressBar progressBar;
        private MenuItem root;

        private ViewAsPlugin plugin;
        public string SelectedPath { get; set; }=String.Empty;
        public ViewAs(ProgressBar progressBar, MenuItem menu)
        {
            this.progressBar= progressBar;
           this.root = menu;
            plugin  = AllPlugins.InvokePlugin<ViewAsPlugin>(PluginType.ViewAs); ;
        }
        public async void SetSelectedPath(string path)
        {
            SelectedPath= path; 
            await Load();
        }



        public async Task<MyEditFile?> Load(  )
        {
 
            MyEditFile? result = null;
       
            var progress = new Progress<long>(value => progressBar.Value = value);
            var parameter = new ActionParameter(SelectedPath);
            await plugin.Perform(parameter, progress);
            string headerString = "View As ";
            if (plugin.CurrentText.SyntaxHighlighting != null)
                headerString = String.Concat(headerString, plugin.CurrentText.SyntaxHighlighting.ToString());
            root.Header = headerString;
          

    return result;                
    }

       
        
    }
}
