using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefaultPlugins;
using Model;

namespace DeluxeEdit.DefaultPlugins.Tests.IntegrationTests
{
    public class UrlEncodeTests
    {
        [Fact]
        public void UrlEncodeTest()
        {
            var plugin = new UrlEncodePlugin();
            var expected = "Hej+p%c3%a5+dig";
            var actual = plugin.Perform(
                new ActionParameter("Hej på dig"));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UrlEncodeTestSimple()
        {
            var plugin = new UrlEncodePlugin();
            var expected = "Ninja";
            var actual = plugin.Perform(
                new ActionParameter("Ninja"));
            Assert.Equal(expected, actual);
        }

    }
}
    