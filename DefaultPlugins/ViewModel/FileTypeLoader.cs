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

namespace ViewModel
{
    public class FileTypeLoader
    {

        public static List<FileTypeItem> AllFileTypes { get; set; }= LoadFileTypes();
        public static string CurrentPath { get; set; }=String.Empty;
        public TextEditor CurrentText { get; set; } = new TextEditor();
        public TextArea CurrentArea { get; set; } = new TextEditor().TextArea;
    //    public FileTypeItem? CurrentFileItem { get; set; } = new FileTypeItem();
        public IHighlightingDefinition? CurrentDefinition { get; private set; }

        public static FileTypeItem? GetFileTypeItemByMenu(string menuTitle)
        {
            var result = AllFileTypes.FirstOrDefault(p => p.ToString() == menuTitle && menuTitle.StartsWith("As "));
            return result;
        }
        public static FileTypeItem GetFileTypeItemByFileType(FileType fileType)
        {
            var result = AllFileTypes.First(p => p.FileType == fileType);
            return result;
        }



 
        public void LoadCurrent(string path)   
        {
            var manager = HighlightingManager.Instance;
            

//            if (path.HasContent() )
 //               CurrentFileItem=  AllFileTypes.FirstOrDefault(p =>  path.EndsWith(p.FileExtension, StringComparison.OrdinalIgnoreCase));

           string extension = Path.GetExtension(path);
            
            CurrentDefinition = manager.GetDefinitionByExtension(extension);
            CurrentText = new TextEditor();

          CurrentArea = CurrentText.TextArea;
            CurrentArea.MinHeight = 500;
            CurrentArea.MinWidth = 1000;
            //CurrentText.SyntaxHighlighting = "C#";
            //CurrentDocument= CurrentText.Document;
      
       


            if (CurrentDefinition != null) 
                CurrentText.SyntaxHighlighting = CurrentDefinition;


            CurrentPath = path; 
        }

         
        public static  List<FileTypeItem> LoadFileTypes()
        {
            var manager = new HighlightingManager();

            var names = Enum.GetNames(typeof(FileType));
            
            var result=names.Select(p => Enum.Parse<FileType>(p)).Select(p =>
            new FileTypeItem { 
                FileExtension = WPFUtil.FileTypeToExtension(p), 
                FileType = p, 
                Definition=manager.GetDefinitionByExtension(WPFUtil.FileTypeToExtension(p)) }
             ).ToList();
            return result;
            

        }




    }
}
