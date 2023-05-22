using System;
using System.Collections.Generic;

namespace DeluxeEdit.Model.Interface
{

    public interface INamedActionPlugin:  INamedAction
    {

        public string HasGuiPartClassName { get; set; }

        string Path { get; set; }
        string ClassName { get; set; }

        
        }

    
}
