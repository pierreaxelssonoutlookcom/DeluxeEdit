using DefaultPlugins.DefaultPlugins.PluginHelpers;
using Extensions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace DefaultPlugins.ViewModel.MainActions
{
    public class ViewAs
    {
        private ProgressBar progressBar;
        private MenuItem root;
        private ViewAsPlugin? plugin;
        public string SelectedPath { get; set; }=String.Empty;
        public ViewAs(MenuItem menu, ProgressBar progressBar)
        {
            this.progressBar= progressBar;
            this.root = menu;
            //          a  this.fileTypeLoader=fileTypeLoader;
            plugin  = AllPlugins.InvokePlugin<ViewAsPlugin>(PluginType.ViewAs); ;
            
        }
        public async void SetSelectedPath(string path)
        {
            SelectedPath= path; 
            await Load();
        }
        public List<CustomMenuItem> GetSubMenuItemsForFileTypes()
        {
            if (plugin == null) throw new NullReferenceException();
            var result= plugin.GetSubMenuItemsForFileTypes();
            result.ForEach(p => root.Items.Add(p.Title));
            //        result.ForEach(p => root.Items.Add(p.Title));
            return result;
        }

        public async Task<MyEditFile?> Load(  )
        {
            if (plugin == null) throw new NullReferenceException();

            MyEditFile? result = null;
       
            var progress = new Progress<long>(value => progressBar.Value = value);
            var parameter = new ActionParameter(SelectedPath);
            await plugin.Perform(parameter, progress);
            return result;
        }

       

        
    }
}
