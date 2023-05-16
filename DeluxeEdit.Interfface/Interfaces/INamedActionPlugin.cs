using System;

using System.Collections.Generic;

namespace DeluxeEdit.Interface
{
    public class PluginSource
    {
        public string Path { get; set; }
        public List <INamedActionPlugin>  Items { get; set; }
        public PluginSource()
        {
            Items = new List<INamedActionPlugin>();
        }
    }

    public interface INamedActionPlugin:  INamedAction
    {
        
       string Path { get; set; }
        string Name { get; set; }
         string Titel { get; set; }  
        List<Char> ShortCutCommand { get; set; }
        string Parameter { get; set; }
        string ClassName { get; set; }
        string Result { get; set; } 

        Func<string, string> Action { get; set; }
        INamedActionPlugin Object { get; set; }

        string Perform(string parameter);
        
        }

    
}
