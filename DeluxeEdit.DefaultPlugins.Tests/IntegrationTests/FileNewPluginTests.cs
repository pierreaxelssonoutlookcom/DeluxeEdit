using System.Text;
using DefaultPlugins;
using Model;

namespace DeluxeEdit.DefaultPlugins.Tests.IntegrationTests
{
    public class FileNewPluginTests
    {
        public static string TempDir = "C:/temp";
        public static string TestFile = TempDir + "/testfile.txt";
        public static string TestFile2 = TempDir + "/testfile2.txt";

        [Fact]
        public void FileNewPluginTest()
        {
            var plugin = AllPlugins.InvokePlugin(PluginType.FileNew) as FileNewPlugin;
                
   

            var actual = plugin.Perform(new ActionParameter());
           ;
        }
        

    }
}