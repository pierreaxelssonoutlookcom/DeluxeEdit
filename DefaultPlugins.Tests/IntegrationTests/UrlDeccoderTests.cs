using DefaultPlugins;
using Model;
using Xunit;


namespace DeluxeEdit.DefaultPlugins.Tests.IntegrationTests
{
    public class UrlDecoderTests
    {
        [Fact]
        public async Task UrlDecodeTest()
        {
            var plugin = AllPlugins.InvokePlugin(PluginType.UrlDecode) as UrlDecodePlugin;
            string actual=String.Empty;
            var expected = "Hej på dig";
            if (plugin != null) actual = await plugin.Perform(
                new ActionParameter("Hej+p%c3%a5+dig"), new Progress<long>());
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async Task UrlDecodeTestSimple()
        {
            var plugin = AllPlugins.InvokePlugin(PluginType.UrlDecode) as UrlDecodePlugin;
            var expected = "Ninja";
            string actual=string.Empty  ;
            if (plugin != null) actual = await plugin.Perform(
                new ActionParameter("Ninja"), new Progress<long>());
            Assert.Equal(expected, actual);
        }


    }
}