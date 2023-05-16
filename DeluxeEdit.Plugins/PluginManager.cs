using DeluxeEdit.Interface;
using System;
using System.Reflection;

namespace DeluxeEdit.Plugins
{
    public class PluginManager
    {
        private static Assembly loadedAsm;

        public static void ShowPluginManager()
        {
        }
        public  void LoadPlugins(PluginSource source)
        {
            //done:could be multiple plugisn in the same, FILE
            loadedAsm = Assembly.LoadFile(source.Path);
            foreach (var item in source.Items)
            {
                var newItem = loadedAsm.CreateInstance(item.ClassName) as INamedActionPlugin;
                source.Items.Add(newItem);
            }
        }
        public static void LoadPlugins()
        {
        }
        public static void AddPlugin()
        {
        }
        public static void RemovePlugin()
        {
        }


    }
}
