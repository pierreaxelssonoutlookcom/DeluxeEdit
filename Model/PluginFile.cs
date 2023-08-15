using System;
using System.Collections.Generic;
using System.Text;
 
namespace Model
{
    public class PluginFile
    {
        public string? LocalPath { get; set; }
        public string? Url { get; set; }

    }
    public class PluginItem
    {
        public string ID { get; set; }
        public Version? Version { get; set; }

        public PluginFile File { get; set; }

        public bool Enabled { get; set; }

    }
}