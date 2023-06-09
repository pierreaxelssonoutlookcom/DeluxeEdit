using DeluxeEdit.DefaultPlugins.Managers;
using DeluxeEdit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeEdit.DefaultPlugins.ViewModel
{
    public class PluginViewModel
    {
        private NugetPluginManager manager;

        public PluginViewModel()
        {
            manager=new NugetPluginManager();        
        }
        public IEnumerable<PluginSourceItem> RemoteList()
                        {
            throw new NotImplementedException();
        }


        public IEnumerable<PluginSourceItem> LocalList()
        {
            var result=manager.LocalList();
            return result;

        }

    }
}
