using Model;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using DefaultPlugins;
using Shared;
using System.Windows.Controls;
using Extensions.Util;
using System.Reflection.Metadata;
using System;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit;
using static System.Net.Mime.MediaTypeNames;

namespace ViewModel
{
    public class FileTypeLoader
    {
        private HighlightingManager man;

        public FileTypeLoader()
        {
            man = new HighlightingManager();
         }

        public List<FileTypeItem> LoadFileTypes()
        {
          var names = Enum.GetNames(typeof(FileType));
            
            var result=names.Select(p => Enum.Parse<FileType>(p)).Select(p =>
            new FileTypeItem { 
                FileExtension = WPFUtil.FileTypeToExtension(p), 
                FileType = p, 
                Definition=man.GetDefinitionByExtension(WPFUtil.FileTypeToExtension(p)) }
             ).ToList();

            

            return result;
        }




    }
}
