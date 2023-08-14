using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;
using System.IO;

namespace DefaultPlugins.Misc
{ 
    public class PluginFileItemParser
    {
        public PluginFileItemParser()
        {

        }
        public PluginFileItem ParseFileName(string path)
        {
            var file = new FileInfo(path);
            var result = new PluginFileItem { LocalPath = file.FullName };

            var nameOnlyPart = file.Name.Split('.')[0];
            result.ID = nameOnlyPart;
            var first = nameOnlyPart.IndexOfDigit();
            var last = nameOnlyPart.LastIndexOfDigit();

            if (first.HasValue && last.HasValue)
            {
                string extractedVersion = nameOnlyPart.Substring(first.Value, last.Value - first.Value);
                result.Version = Version.Parse(extractedVersion);

                result.ID = nameOnlyPart.Substring(first.Value, last.Value - first.Value - 1);
            }
            return result;
        }
    }
}
