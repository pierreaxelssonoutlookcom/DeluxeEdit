using System.IO;
using System.Text;
using DefaultPlugins;
using Model;
using Xunit;
 
namespace DeluxeEdit.DefaultPlugins.Tests.IntegrationTests
{
    public class FileOpenPluginTests
     {
        public static string TestFile = "TestFiles/testfileopen.txt";

        [Fact]
        public async Task FileOpenPluginTest()
        {
            var plugin = AllPlugins.InvokePlugin<FileOpenPlugin>(PluginType.FileOpen);

            var expected = "ninjaåäÖ";
            
            var actual = await plugin.Perform(
                     new ActionParameter(TestFile, Encoding.UTF8), new Progress<long>());
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async Task FileOpenPluginTestSimple()
        {
            var plugin = AllPlugins.InvokePlugin<FileOpenPlugin>(PluginType.FileOpen);

            var expected = "ninjaåäÖ";
            var actual = await plugin.Perform(
                new ActionParameter(TestFile), new Progress<long>());
            Assert.Equal(expected, actual);
        }




    }
}