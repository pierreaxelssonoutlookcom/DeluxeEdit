using Model;
using System;
using System.Collections.Generic;
using DefaultPlugins.Misc;

namespace DefaultPlugins.ViewModel
{
    public class PluginViewModel
    {
        private PluginManager manager;

        public PluginViewModel()
        {
            manager = new PluginManager();    
        }   
        public IEnumerable<PluginFile> RemoteList()
        {
            return manager.RemoteList();
        }
        public IEnumerable<PluginFile> LocalList()
        {
            var result=manager.LocalList();
            return result;
        }

    }
}
