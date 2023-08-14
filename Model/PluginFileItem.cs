using System;
using System.Collections.Generic;
using System.Text;
 
namespace Model
{
    public class PluginFileItem
    {
        public string ID { get; set;  }
        public Version? Version { get; set; }
        public string? LocalPath { get; set; }
        public string? Url { get; set; }
        public bool Enabled { get; set; }

    }
}