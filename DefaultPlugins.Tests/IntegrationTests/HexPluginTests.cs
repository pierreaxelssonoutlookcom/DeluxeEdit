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
        public async void HexOpenFileTest()
        {
            var plugin = AllPlugins.InvokePlugin<HexPlugin>(PluginType.Hex);
            var expected = "efbbbf6e696e6a61c3a5c3a4c396";
            if (File.Exists(TestFile)) File.Delete(TestFile);
            File.WriteAllText(TestFile, "ninjaåäÖ", Encoding.UTF8);
            var actual = await plugin.Perform(
                new ActionParameter(TestFile), null);
            Assert.Equal(expected, actual);
        }
    }
}