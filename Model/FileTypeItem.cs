using ICSharpCode.AvalonEdit.Highlighting;
namespace Model
{
    public class FileTypeItem
    {
        public FileType FileType { get; set; }
        public string FileExtension { get; set; } = String.Empty;
        public string AsPrinted { get { return ToString(); } }
        public override string ToString()
        {
            return $"As {FileType} ({FileExtension})";
        }

    }

}
