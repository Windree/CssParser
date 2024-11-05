using Windree.CssParser.Entities;

namespace Windree.CssParser.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestComment()
        {
            var parser = new CssParser("    /*Comment*/    ");
            var css = parser.Parse();
            Assert.AreEqual("Comment", css[0].Comment);
        }
    }
}