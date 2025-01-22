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
        private ComboBox viewAsCombo;

        //    private MenuItem root;
        private ViewAsPlugin plugin;
        public string SelectedPath { get; set; }=String.Empty;
        public ViewAs(ProgressBar progressBar, ComboBox viewAsCombo)
        {
            this.progressBar= progressBar;
            this.viewAsCombo= viewAsCombo;
          //  this.root = menu;
            //          a  this.fileTypeLoader=fileTypeLoader;
            plugin  = AllPlugins.InvokePlugin<ViewAsPlugin>(PluginType.ViewAs); ;
            LoadFileTypes();
        }
        public async void SetSelectedPath(string path)
        {
            SelectedPath= path; 
            await Load();
        }
        
       
        public void  LoadFileTypes()
        {
            viewAsCombo.Items.Clear();
            viewAsCombo.ItemsSource= plugin.GetFileTypes();
            viewAsCombo.DisplayMemberPath = "AsPrinted";
            //      result.ForEach(p => root.Items.Add(p));
            //        result.ForEach(p => root.Items.Add(p.Title));
            
        }

        public async Task<MyEditFile?> Load(  )
        {
 
            MyEditFile? result = null;
       
            var progress = new Progress<long>(value => progressBar.Value = value);
            var parameter = new ActionParameter(SelectedPath);
            await plugin.Perform(parameter, progress);
            if (plugin.CurrentFileItem!=null ) viewAsCombo.SelectedItem= plugin.CurrentFileItem;
            return result;
        }

       

        
    }
}
