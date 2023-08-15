using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;
using System.IO;
using Model.Interface;

namespace DefaultPlugins.Misc
{ 
    public class PluginFileItemParser
    {
        public PluginFileItemParser()
        {

        }
        public PluginFile ParseFileName(string path)
        {
            var file = new FileInfo(path);
            var result = new PluginFile { LocalPath = file.FullName };

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


        public PluginItem ParsePluginItem(INamedActionPlugin item)
        {
            var result = new PluginItem();
            var nameOnlyPart = file.Name.Split('.')[0];
            result.ID = item.Id;
            result.Version = item.;

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
