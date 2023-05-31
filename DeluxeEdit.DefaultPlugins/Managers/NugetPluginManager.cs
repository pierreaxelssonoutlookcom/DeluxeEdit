using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DeluxeEdit.Model
{
    public class NugetPluginManager
    {
        private string futurePluginPath;

        public NugetPluginManager() 
        {
            futurePluginPath = $"{Environment.SpecialFolder.ApplicationData}\\DeluxeEdit\\plugins";

        }




        public IEnumerable<PluginSourceItem> RemoteList()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<PluginSourceItem> LocalList(string search)
        {
            var result = new List<PluginSourceItem>();
            var files = Directory.GetFiles(futurePluginPath, "*.dll");
            foreach (var f in files)
            {
                var resultItem = new PluginSourceItem { LocalPath = f };
                string fileNameFirstPart = f.Split('.')[0];
                var fileNameFirstPartArray = fileNameFirstPart.ToArray();
                for (int i = 0; i < fileNameFirstPartArray.Length - 1; i++)
                {
                    if (Char.IsDigit(fileNameFirstPartArray[i]))
                    {
                        resultItem.Version = Version.Parse(fileNameFirstPart.Substring(i));
                        resultItem.ID = fileNameFirstPart.Substring(0, i);
                        break;
                    }
                    if (resultItem.ID == null) resultItem.ID = fileNameFirstPart;
                }
                result.Add(resultItem);

            }
            return result;

        }          




    }
}
