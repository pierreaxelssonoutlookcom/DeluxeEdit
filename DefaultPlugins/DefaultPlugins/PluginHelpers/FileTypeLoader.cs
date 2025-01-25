using Model;
using System.Collections.Generic;
using System.Linq;
using Extensions.Util;
using System;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Document;
using System.IO;
using System.Collections.ObjectModel;
using Extensions;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using System.Xml;

namespace DefaultPlugins.PluginHelpers
{
    public class FileTypeLoader
    {
        

        //public static List<FileTypeItem> AllFileTypes { get; set; }
        public static string CurrentPath { get; set; } = string.Empty;
        public TextEditor CurrentText { get; set; } = new TextEditor();
        public TextArea CurrentArea { get; set; } = new TextEditor().TextArea;
        public FileTypeItem? CurrentFileItem { get; set; } = new FileTypeItem();
        public FileTypeLoader()
        {
            var registration = new HighlightingRegistrationItem();
            registration.Name = "LogFile";
            registration.Extensions.Add(".log");
            registration.PathToDefinition = "./DefaultPlugins/PluginHelpers/LogFileDefinition.xshd";
            RegisterDefinition(registration);
        }



        public void LoadCurrent(string path)
        {
            var manager = HighlightingManager.Instance;
            
//            var logFileDefinition= LoadDefinitionFromFile();
            // RegisterDefinition("LogFile", ".log" , logFileDefinition);

            if (path.HasContent())
                CurrentFileItem = GetFileTypes().FirstOrDefault(p => path.EndsWith(p.FileExtension, StringComparison.OrdinalIgnoreCase));

            var definition = manager.GetDefinitionByExtension(new FileInfo(path).Extension);
            CurrentText = new TextEditor();

            CurrentArea = CurrentText.TextArea;
            CurrentArea.MinHeight = 500;
            CurrentArea.MinWidth = 1000;
            //CurrentText.SyntaxHighlighting = "C#";
            //CurrentDocument= CurrentText.Document;




                CurrentText.SyntaxHighlighting = definition;


            CurrentPath = path;
        }


        public List<FileTypeItem> GetFileTypes()
        {

            var names = Enum.GetNames(typeof(FileType));

            var result = names.Select(p => Enum.Parse<FileType>(p)).Select(p =>
            new FileTypeItem
            {
                FileExtension = WPFUtil.FileTypeToExtension(p),
                FileType = p
            }).ToList();
            return result;


        }

        public IHighlightingDefinition LoadDefinitionFromFile(HighlightingRegistrationItem registrationItem)
        {
//            string logFileDefinitionPath = "./DefaultPlugins/PluginHelpers/LogFileDefinition.xshd";
            using var reader = XmlReader.Create(registrationItem.PathToDefinition);
             var result=HighlightingLoader.Load(reader, HighlightingManager.Instance);
            return result;
        }

        public void RegisterDefinition(HighlightingRegistrationItem registrationItem)       
        {
            var definition = LoadDefinitionFromFile(registrationItem);
            var manager = HighlightingManager.Instance;
            manager.RegisterHighlighting(registrationItem.Name, registrationItem.Extensions.ToArray() ,definition);
        }
    }
}
