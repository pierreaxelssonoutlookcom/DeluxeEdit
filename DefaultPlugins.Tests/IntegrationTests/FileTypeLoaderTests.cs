using System.Text;
using DefaultPlugins;
using Model;
using Xunit;
using System.IO;
using DefaultPlugins.DefaultPlugins.PluginHelpers;

namespace DeluxeEdit.DefaultPlugins.Tests.IntegrationTests
{
    public class FileTypeLoaderTests
    {
        public static string TestFile = "TestFiles/LogFileDefinition.xml";


        [Fact]
        public void LoadDefinitionTest()
        {
            var loader = new FileTypeLoader();
            var definition = loader.LoadDefinitionFromFile(TestFile);


            Assert.NotNull(definition);


        }

        [Fact]
        public void RegisterDefinitionTest()
        {
            var loader = new FileTypeLoader();
            var definition = loader.LoadDefinitionFromFile(TestFile);

            loader.RegisterDefinition("LogFile",".log",definition);






        }



    }
}