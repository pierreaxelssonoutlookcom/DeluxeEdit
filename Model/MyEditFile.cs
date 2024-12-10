using ICSharpCode.AvalonEdit;
using System;
using System.Text;
using System.Windows.Controls;
namespace Model
{
  public class MyEditFile: IEquatable<MyEditFile>
    {
        public string BufferPath { get { return Path+".buff"; } }
        public Encoding? Encoding { get; set; }

        public string Path { get; set; } = "";
        public string Content { get; set; } = "";
        public string Header { get; set; } = "";
        public bool  IsNewFile { get; set; }
        public TextEditor Text { get; set; } = new TextEditor();
        public TabControl? Tab { get; set; }
 

        public bool Equals(MyEditFile? other)
        {
            bool result = other != null ? other.Path == Path && other.Content == Content && other.Header == Header : false;
            return result;
            throw new NotImplementedException();
        }
    }



}
