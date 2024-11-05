using Windree.CssParser.Entities;

namespace Windree.CssParser.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNoComment()
        {
            var parser = new CssParser("  .div {} ");
            var css = parser.Parse();
            Assert.AreEqual(0, css.Length);
        }
        [TestMethod]
        public void TestComment()
        {
            var parser = new CssParser("    /*Comment*/    ");
            var css = parser.Parse();
            Assert.AreEqual("Comment", css[0].Comment);
        }
        [TestMethod]
        public void TestUnclosedComment()
        {
            var parser = new CssParser("    /*Comment/    ");
            var css = parser.Parse();
            Assert.AreEqual("Comment/    ", css[0].Comment);
        }
    }
}