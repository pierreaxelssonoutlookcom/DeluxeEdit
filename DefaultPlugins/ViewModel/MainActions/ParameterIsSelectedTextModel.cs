using Extensions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ViewModel;

namespace DefaultPlugins.ViewModel.MainActions
{
    public class ParameterIsSelectedTextModel
    {
        private LoadFile loadFile;
        private ProgressBar progressBar;

        public ParameterIsSelectedTextModel(LoadFile loadFile,ProgressBar progressBar)
        {
            this.loadFile = loadFile;
            this.progressBar=progressBar;
        }
        public async Task<string> HandleOtherPlugins(CustomMenuItem? myMenuItem)
        {
            var progress = new Progress<long>(value => progressBar.Value = value);

            string selectedText = loadFile.CurrentText != null ? loadFile.CurrentText.SelectedText : String.Empty;
            string result = String.Empty;
            if (myMenuItem != null && myMenuItem.Plugin != null && myMenuItem.Plugin.ParameterIsSelectedText && selectedText.HasContent())
                result = await myMenuItem.Plugin.Perform(new ActionParameter(selectedText), progress);
            else if (myMenuItem != null && myMenuItem.Plugin != null && myMenuItem.Plugin.Parameter != null)
                result = await myMenuItem.Plugin.Perform(myMenuItem.Plugin.Parameter, progress);
            return result;
        }


        public void invoke (LoadFile loadFile)
        {
            this.loadFile = loadFile;
        }
    }
}
