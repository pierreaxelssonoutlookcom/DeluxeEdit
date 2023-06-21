using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeluxeEdit.DefaultPlugins;
using DeluxeEdit.Model;

namespace DeluxeEdit.DefaultPlugins.Tests.IntegrationTests
{
    public class FilreOpenPluginTests
     {
        public static string TempDir = "C:/temp";
        public static string TestFile= TempDir+"/testfile.txt";
        [Fact]
        public void FileOpenPluginTest()
        {
            var expected = "ninjaåäö";
            if (File.Exists(TestFile)) File.Delete(TestFile);
            File.WriteAllText(TestFile, "ninjaåäö", Encoding.UTF8);
            var plugin = new FileOpenPlugin();
            plugin.OpenEncoding=Encoding.UTF8;
            var actual = plugin.Perform(
                new ActionParameter(TestFile));
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void UrlDecodeTestSimple()
        {
            var plugin = new UrlDecodePlugin();
            var expected = "Ninja";
            var actual = plugin.Perform(
                new ActionParameter("Ninja"));
            Assert.Equal(expected, actual);
        }


    }
}