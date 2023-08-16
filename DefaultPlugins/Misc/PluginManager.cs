using DefaultPlugins.Misc;
using Model;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DefaultPlugins.Misc
 {
    public class PluginManager
    { 
        private static string pluginPath;
        private static Dictionary<string, Assembly>? loadedAsms;
        public static List<INamedActionPlugin> Instances= new List<INamedActionPlugin>();
        public List<PluginFile> SourceFiles;

        static PluginManager()
        {
            pluginPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\DeluxeEdit\\plugins";
        }
        public void LoadFiles()
        {
            SourceFiles =
                Directory.GetFiles(pluginPath, "*.dll").ToList()
                .Select(p => new PluginFile { LocalPath = p }).ToList();

            foreach (var file in SourceFiles)
            {
                file.Instances = LoadPluginFile(file.LocalPath);               SourceFiles.Select(p => LoadPluginFile(p.LocalPath));
            }
        }
     

        public static INamedActionPlugin InvokePlugin(Type pluginType)
        {
            object? newItem = Activator.CreateInstance(pluginType);




          var newItemCasted = newItem is INamedActionPlugin ? newItem as INamedActionPlugin : null; ;
            if (newItemCasted == null) throw new InvalidCastException();
            //now recording all plugin objects
            Instances.Add(newItemCasted);
            return newItemCasted;

        }

        private static INamedActionPlugin CreateObjects(object item, Type t)
        {
            var newItemCasted = item is INamedActionPlugin ? item as INamedActionPlugin : null; ;
            if (newItemCasted == null) throw new NullReferenceException();
             
            if (newItemCasted.ControlType != null)
                newItemCasted.Control = Activator.CreateInstance(newItemCasted.ControlType);
            

            return newItemCasted;
        }
  
        public static List<INamedActionPlugin> LoadPluginFile(string path)
        {
            if (loadedAsms == null) loadedAsms = new Dictionary<string, Assembly>();


            var result = new List<INamedActionPlugin>();
            if (loadedAsms!=null && !loadedAsms.ContainsKey(path))
            {
                 loadedAsms[path]=Assembly.LoadFile(path);
            }

            if (loadedAsms == null) throw new NullReferenceException();
            //done:could be multiple plugisAssemblyn in the same, FILE
            var allTypes = loadedAsms[path].GetTypes().ToList();
            foreach (var t in allTypes)
            {

                 object testObject=Activator.CreateInstance(t);
                if (testObject is  INamedActionPlugin)
                { 
                    var newItemCasted = CreateObjects(testObject, t);
                    result.Add(newItemCasted);

                }
             }
            
            return result;
        }




    }
}
