using System.Text;
using DefaultPlugins;
using Model;
using Xunit;
using System.IO;
using DefaultPlugins.PluginHelpers;

namespace DefaultPlugins.Tests.IntegrationTests
{
    public class FileTypeLoaderTests
    {
        public static string TestFile = "TestFiles/LogFileDefinition.xml";


        [Fact]
        public void LoadDefinitionTest()
        {
            var loader = new FileTypeLoader();
            var definition = loader.LoadDefinitionFromFile();


            Assert.NotNull(definition);


        }

        [Fact]
        public void RegisterDefinitionTest()
        {
            var loader = new FileTypeLoader();
            var definition = loader.LoadDefinitionFromFile();

            loader.RegisterDefinition("LogFile",".log",definition);






        }



    }
}