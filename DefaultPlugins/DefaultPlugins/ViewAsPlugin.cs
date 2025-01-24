using Model;
using System;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;
using ViewModel;
using System.Linq;
using DefaultPlugins.PluginHelpers;
using System.Windows.Controls;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit;

namespace DefaultPlugins
{
    public class ViewAsPlugin : INamedActionPlugin
    {
        public const string VersionString = "0.1";
        private FileTypeLoader fileTypeLoader;
        public TextEditor CurrentText { get; set; } = new TextEditor();
        public TextArea CurrentArea { get; set; } = new TextEditor().TextArea;
        public bool ParameterIsSelectedText { get; set; } = true;
        public Version Version { get; set; } = new Version(VersionString);
        public ActionParameter Parameter { get; set; } = new ActionParameter();
        public bool Enabled { get; set; }
        public Type Id { get; set; } =typeof(ViewAsPlugin);
        public ConfigurationOptions Configuration { get; set; } = new ConfigurationOptions();
        public string Path { get; set; } = "";
        public string ClassName { get; set; } = "";
        public FileTypeItem? CurrentFileItem { get; set; }
 //       public ComboBox? ComboForViewAs{ get;set; }
        public ViewAsPlugin()
        {
            fileTypeLoader = new FileTypeLoader();
            SetConfig();


        }

        public void SetConfig()
        {

        }

         public List<CustomMenuItem> GetSubMenuItemsForFileTypes()
        {
            var result = fileTypeLoader.GetFileTypes().Select(p =>
            new CustomMenuItem { Name=p.FileType.ToString(),  Title = p.ToString(), FileType = p.FileType, IsCheckable = true, IsChecked = false, Plugin=this }).ToList();
            return result;
        }

        private async Task<string> InternalDoIt()
        {
            var result = String.Empty;
            LoadCurrent(Parameter.Parameter);
            await Task.Delay(0);
        return result;

        }
        public void LoadCurrent(string path)
        {

 
                fileTypeLoader.LoadCurrent(path);
                CurrentText = fileTypeLoader.CurrentText;
                CurrentArea = fileTypeLoader.CurrentArea;

            CurrentFileItem = fileTypeLoader.CurrentFileItem;

           

        }
        public List<FileTypeItem> GetFileTypes()
        { 
            return fileTypeLoader.GetFileTypes(); 
        }
        public async Task<string> Perform(ActionParameter parameter, IProgress<long> progresss)
        {
            if (parameter == null) throw new ArgumentNullException();

            var dummy = await Task.FromResult(new List<string> { });
            Parameter = parameter;

            return await InternalDoIt();
        }
        public async Task<IEnumerable<string>> Perform(IProgress<long> progresss)
        {
            if (Parameter == null) throw new ArgumentNullException();

            return new List<string> { await InternalDoIt() };
 

        }

        public object CreateControl(bool showToo)
        {
            return new object();

        }
        public EncodingPath? GuiAction(INamedActionPlugin instance)
        {
            return null;
        }


    }


}
