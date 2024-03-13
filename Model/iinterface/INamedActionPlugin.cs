using System;

namespace Model.Interface
{

    
    
    
    public interface INamedActionPlugin
    {
        ConfigurationOptions Configuration { get; set; }


        bool ParameterIsSelectedText        { get; set; }
        bool Enabled { get; set; }
        Version Version { get; set; }

        string Id { get; set; }
        string Titel { get; set; }

        ActionParameter?  Parameter { get; set; }
        string Perform(ActionParameter parameter);



        EncodingPath? GuiAction(INamedActionPlugin instance);
        object CreateControl(bool showToo);
        string Path { get; set; } 
  
        
        }

   
}
