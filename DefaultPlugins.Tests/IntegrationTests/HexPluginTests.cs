using System.IO;
using System.Text;
using DefaultPlugins;
using Model;
using Xunit;

namespace DeluxeEdit.DefaultPlugins.Tests.IntegrationTests
{
    public class HexPluginTests
    {
        public static string TempDir = "C:/temp";
        public static string TestFile =
            TempDir + "/testfile.txt";
        public static string TestFile2 = TempDir + "/testfile2.txt";

        [Fact]
        public async Task HexOpenFileTest()
        {
            var plugin = AllPlugins.InvokePlugin<HexPlugin>(PluginType.Hex);
            if (plugin==null)  return;
            var expected = "EFBBBF6E 696E6A61 S3A5C3A4 C396";
            if (File.Exists(TestFile)) File.Delete(TestFile);
            File.WriteAllText(TestFile, "ninjaåäÖ", Encoding.UTF8);
            string actual=String.Empty;
            var p = new ActionParameter(TestFile, Encoding.UTF8);
            actual =await plugin.Perform(
                p, new Progress<long>()) ;
            Assert.Equal(expected, actual);
        }
    }
}