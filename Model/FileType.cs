
using ICSharpCode.AvalonEdit.Highlighting;

namespace Model
{
    public enum FileType { Boo, CocoR, CPP, CS, HTML, Java, JavaScript, PatchFiles, PHP, TeX, VB, XML }

    public class FileTypeItem
    {
        public IHighlightingDefinition? Definition;
     public FileType FileType { get; set; }

        
        public string FileExtension { get; set; }=String.Empty;


    }
}
 