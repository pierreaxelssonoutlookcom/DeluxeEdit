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
    public enum PluginType { FileOpen,  UrlDecode, UrlEncode}
    public class AllPlugins
    {
        public static INamedActionPlugin  InvokePlugin(PluginType plugin)
        {
            Type? myType = null;
            switch (plugin)
            {
                case PluginType.FileOpen: 
                    myType = typeof(FileOpenPlugin);
                    break;
                    case PluginType.UrlDecode: 
                    myType = typeof(UrlDecodePlugin);
                    break;
                    case PluginType.UrlEncode:
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
