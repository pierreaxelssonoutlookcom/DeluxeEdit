using ModelMisc;
using Model;
using System;
using System.Collections.Generic;

namespace DefaultPlugins.ViewModel
{
    public class PluginViewModel
    {
        private Views.Plugins pluginView;
        private PluginManager manager;

        public PluginViewModel()
        {
            pluginView = new Views.Plugins();
            manager = new PluginManager();    
        }   
        public IEnumerable<PluginFileItem> RemoteList()
        {
            return manager.RemoteList();
        }
        public IEnumerable<PluginFileItem> LocalList()
        {
            var result=manager.LocalList();
            return result;
        }

    }
}
