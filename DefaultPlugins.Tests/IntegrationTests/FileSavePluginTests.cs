using System.Text;
using DefaultPlugins;
using Model;
using Xunit;
using System.IO;

namespace DeluxeEdit.DefaultPlugins.Tests.IntegrationTests
{
    public class FileSavePluginTests
    {
        public static string TestFile = "TestFiles/TextFilesave.txt";


        [Fact]
        public async Task FileSavePluginTest()
        {
            var plugin = AllPlugins.InvokePlugin<FileSavePlugin>(PluginType.FileSave);

            var expected = "ninjaåäÖ";
            await plugin.Perform(

               new ActionParameter(TestFile, "ninjaåäÖ", Encoding.UTF8)
              , new Progress<long>() );




            var actual =File.ReadAllText(TestFile, Encoding.UTF8);

            Assert.Equal(expected , actual);

  
        }

        [Fact]
        public async Task FileSaveAsPluginTest()
        {
            var plugin = AllPlugins.InvokePlugin<FileSaveAsPlugin>(PluginType.FileSaveAs);

            var expected = "ninjaåäÖ";
            
            await plugin.Perform(

               new ActionParameter(TestFile, "ninjaåäÖ", Encoding.UTF8)
              , new Progress<long>());

            var actual = File.ReadAllText(TestFile, Encoding.UTF8);
            
            Assert.Equal(expected, actual);


        }



    }
}