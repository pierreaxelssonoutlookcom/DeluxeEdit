

using ICSharpCode.AvalonEdit.Highlighting;

namespace Model
{
    public  class HighlightingRegistrationItem
    {
        public IHighlightingDefinition? Definition { get; set; }
        public string PathToDefinition { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<string> Extensions { get; set; }
        public HighlightingRegistrationItem()
        {
            Extensions = new List<string>();
        }
    }
}  
