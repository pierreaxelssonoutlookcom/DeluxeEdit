using DefaultPlugins;
using Model;
using Xunit;

namespace DeluxeEdit.DefaultPlugins.Tests.IntegrationTests
{
    public class UrlEncodeTests
    {
        [Fact]
        public async Task UrlEncodeTest()
        {
            var plugin = AllPlugins.InvokePlugin(PluginType.UrlEncode);
            var expected = "Hej+p%c3%a5+dig";
            string actual = String.Empty;
               actual = await plugin.Perform(
                new ActionParameter("Hej på dig"), new Progress<long>());
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task UrlEncodeTestSimple()
        {
            var plugin = AllPlugins.InvokePlugin(PluginType.UrlEncode);
            var expected = "Ninja";
            string actual=String.Empty;
            
            actual =  await plugin.Perform(
                new ActionParameter("Ninja"), new Progress<long>());
            Assert.Equal(expected, actual);
        }

    }
}
    