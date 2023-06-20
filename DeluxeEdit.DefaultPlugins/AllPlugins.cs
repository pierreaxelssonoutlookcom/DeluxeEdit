using DeluxeEdit.DefaultPlugins.Managers;
using DeluxeEdit.Model.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeEdit.DefaultPlugins
{
    public enum PluginId { FileOpen,  UrlDecode, UrlEncode}
    public class AllPlugins
    {
        public static INamedActionPlugin  InvokePlugin(PluginId plugin)
        {
            Type? myType = null;
            switch (plugin)
            {
                case PluginId.FileOpen: 
                    myType = typeof(FileOpenPlugin);
                    break;
                    case PluginId.UrlDecode: 
                    myType = typeof(UrlDecodePlugin);
                    break;
                    case PluginId.UrlEncode:
                    myType = typeof(UrlEncodePlugin);
                    break;
            }
            if (myType == null) throw new NullReferenceException();

            var man = new PluginManager();
            var result=man.InvokePlugin(myType);
            return result;
        }
    }
}
