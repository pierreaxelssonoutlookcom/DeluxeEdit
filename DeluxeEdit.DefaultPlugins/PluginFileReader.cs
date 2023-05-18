using DeluxeEdit.Model;
using DeluxeEdit.Model.Interface;
using System;
using System.Collections.Generic;

namespace DeluxeEdit.Shared
{
    public class PluginFileReader 
    {


        private static List<PluginSource>? sourcesAndPlugins;
        private PluginManager manager;
        public PluginFileReader()
        {
            manager = new PluginManager();
            SetupCaches();

        }

        private  void SetupCaches()
        {
            sourcesAndPlugins=GetAllDefaultPlugins();

            ;
        }

        public List<PluginSource> GetAllSources()
        {
             var sources = new List<PluginSource>();
            var item = new PluginSource
            {
                Path = "\"C:\\gitroot\\personal\\DeluxeEdit\\DeluxeEdit.DefaultPlugins\\bin\\Debug\\netstandard2.1\\DeluxeEdit.DefaultActions.dll\""
            };

            return sources;

        }
            public  List<PluginSource> GetAllDefaultPlugins()
            {
                var sources= GetAllSources()
                ;
                foreach ( var source in sources ) 
                {
                    manager.LoadPlugins( source );  
                }


                return sources;

            }
        }
}

