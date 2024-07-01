using DefaultPlugins;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace DeluxeEdit.DefaultPlugins.ViewModel
{
    public class FileBufferManager
    {

        public async Task<List<string>> ReadPortion(FileOpenPlugin plugin, MyEditFile file)
        {
            var result = await plugin.Perform();
            return result.ToList();

            




        }




        public async void AppenBuffer(IEnumerable<string> data, MyEditFile file)
        {
            File.AppendAllLines(file.BufferPath, data);
        }




    }
}