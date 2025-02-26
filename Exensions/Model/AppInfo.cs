using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.Model
{
    public class AppInfo
    {

        public string Name { get; set; } = "";
        public Version Version { get; set; } = new Version();
        public AppEnvironment Environment { get; set; }
        public override string ToString()
        {
            return $"{Name} v {Version} Env {Environment}"; 
        }
    }
}
  