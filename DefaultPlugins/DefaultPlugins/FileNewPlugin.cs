using Model;
using Model.Interface;
using DeluxeEdit.DefaultPlugins.Views;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using CustomFileApiFile;
using Shared;
using System.IO.MemoryMappedFiles;
using System.Linq;
using Extensions;

namespace DefaultPlugins
{
    public class FileNewPlugin : INamedActionPlugin
    {

        public bool ParameterIsSelectedText { get; set; } = false;


        public Version Version { get; set; } = new Version();
        public string VersionString { get; set; } = "0.2";


        public long FileSize { get; set; } = 0;
        public long BytesRead { get; set; }

        public ActionParameter? Parameter { get; set; } = new ActionParameter();
       
        public bool Enabled { get; set; }

        public bool AsReaOnly { get; set; }
        public Encoding? OpenEncoding { get; set; }
        public string Id { get; set; } = "FileNewPlugin";
        public string Titel { get; set; } = "";
        public int SortOrder { get; set; }
        public Stream? InputStream { get; set; } = null;

        public List<string> ContentBuffer { get; set; } = new List<string>();
        public ConfigurationOptions Configuration { get; set; }= new ConfigurationOptions();
        public string Path { get; set; } = "";

        private  StreamWriter writer;

 

        public FileNewPlugin()
        {
            SetConfig();
        }
        public object CreateControl(bool showToo)
        {
            return new object();  
        }
       public  void SetConfig()
        {
            Configuration.ShowInMenu = "File";
            Configuration.ShowInMenuItem = "New";
            Configuration.KeyCommand.Keys = new List<Key> { Key.LeftCtrl, Key.N };
            Version = Version.Parse(VersionString ?? "0.0");

        }

        public EncodingPath? GuiAction(INamedActionPlugin instance)
        {
            string oldDir = @"c:\";

            if (Parameter != null) oldDir = new DirectoryInfo(Parameter.Parameter).FullName;
            var dialog = new DeluxeFileDialog();
            var result = dialog.ShowFileOpenDialog(oldDir);
            return result;
        }

        public async Task<IEnumerable<string>> Perform(IProgress<long> progress)
        {
            WritesAllPortions(progress);
            return new List<string>();


        }

        public void WritesAllPortions(IProgress<long> progress)
        {
            if (Parameter == null) throw new ArgumentNullException();

            if (!File.Exists(Parameter.Parameter)) throw new FileNotFoundException(Parameter.Parameter);
            if (writer == null) { }
            if (writer == null)
            {
                if (Parameter == null) throw new ArgumentNullException();

                using var mmf = MemoryMappedFile.CreateFromFile(Parameter.Parameter);
                InputStream = mmf.CreateViewStream();
                writer = OpenEncoding == null ? new StreamWriter(InputStream) : new StreamWriter(InputStream, OpenEncoding);
            }
            for (int i = 0; i < Parameter.InData.Count / SystemConstants.ReadPortionBufferSizeLines; i++)
            {
                var batch = Parameter.InData.Take(SystemConstants.ReadPortionBufferSizeLines).ToList();
                WritePortion(batch, progress);
            }



        }


        public async void WritePortion(List<string> indata, IProgress<long> progress)
        {
            if (Parameter == null) throw new ArgumentNullException();

            if (!File.Exists(Parameter.Parameter)) throw new FileNotFoundException(Parameter.Parameter);




            if (writer == null)
            {
                using var mmf = MemoryMappedFile.CreateFromFile(Parameter.Parameter);
                InputStream = mmf.CreateViewStream();
                writer = OpenEncoding == null ? new StreamWriter(InputStream) : new StreamWriter(InputStream, OpenEncoding);
            }


            int lineCount = await writer.WriteLinesMax(indata, SystemConstants.ReadPortionBufferSizeLines);
            if (progress != null) progress.Report(lineCount);

            await writer.FlushAsync();

        }





        public async Task<string> Perform(ActionParameter parameter, IProgress<long> progress)
        {
            WritesAllPortions(progress);
            return String.Empty; 
        }


    
    }



}
