using Windree.CssParser.Entities;

namespace Windree.CssParser.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSpaceNonEmpty()
        {
            var parser = new CssParser("  ");
            var css = parser.Parse();
            Assert.AreEqual(CodeBlockType.Space, css[0].Type);
            Assert.AreEqual(0, css[0].StartOffset);
            Assert.AreEqual(2, css[0].EndOffset);
        }
        [TestMethod]
        public void TestTwoSpaceOneLetter()
        {
            var parser = new CssParser("  a   ");
            var css = parser.Parse();
            Assert.AreEqual(CodeBlockType.Space, css[0].Type);
            Assert.AreEqual(0, css[0].StartOffset);
            Assert.AreEqual(2, css[0].EndOffset);
            Assert.AreEqual(3, css[1].StartOffset);
            Assert.AreEqual(6, css[1].EndOffset);

        }
        [TestMethod]
        public void TestTwoSpaceTwoLetter()
        {
            var parser = new CssParser("  a   b");
            var css = parser.Parse();
            Assert.AreEqual(CodeBlockType.Space, css[0].Type);
            Assert.AreEqual(0, css[0].StartOffset);
            Assert.AreEqual(2, css[0].EndOffset);
            Assert.AreEqual(3, css[1].StartOffset);
            Assert.AreEqual(6, css[1].EndOffset);

        }
        [TestMethod]
        public void TestOneSpaceTwoLetter()
        {
            var parser = new CssParser("a   b");
            var css = parser.Parse();
            Assert.AreEqual(CodeBlockType.Space, css[0].Type);
            Assert.AreEqual(1, css[0].StartOffset);
            Assert.AreEqual(4, css[0].EndOffset);
        }
        [TestMethod]
        public void TestTwoSpaceTwoLetterAndSpace()
        {
            var parser = new CssParser("a   b ");
            var css = parser.Parse();
            Assert.AreEqual(CodeBlockType.Space, css[0].Type);
            Assert.AreEqual(1, css[0].StartOffset);
            Assert.AreEqual(4, css[0].EndOffset);
            Assert.AreEqual(5, css[1].StartOffset);
            Assert.AreEqual(6, css[1].EndOffset);
        }

        //[TestMethod]
        //public void TestNoComment()
        //{
        //    var parser = new CssParser("  .div {} ");
        //    var css = parser.Parse();
        //    Assert.AreEqual(0, css.Length);
        //}
        //[TestMethod]
        //public void TestComment()
        //{
        //    var parser = new CssParser("    /*Comment*/    ");
        //    var css = parser.Parse();
        //    Assert.AreEqual("Comment", css[0].Comment);
        //}
        //[TestMethod]
        //public void TestUnclosedComment()
        //{
        //    var parser = new CssParser("    /*Comment/    ");
        //    var css = parser.Parse();
        //    Assert.AreEqual("Comment/    ", css[0].Comment);
        //}
        //[TestMethod]
        //public void TestUnclosedSelector()
        //{
        //    var parser = new CssParser("    div {    ");
        //    var css = parser.Parse();
        //    Assert.AreEqual("div", css[0].Selector?.CssPaths[0].Item[0].Name);
        //}
        //[TestMethod]
        //public void TestTagSelector()
        //{
        //    var parser = new CssParser("    div { width:1px;}   ");
        //    var css = parser.Parse();
        //    Assert.AreEqual("div", css[0].Selector?.CssPaths[0].Item[0].Name);
        //}
        //[TestMethod]
        //public void TestIdSelector()
        //{
        //    var parser = new CssParser("    #id { width:1px;}   ");
        //    var css = parser.Parse();
        //    Assert.AreEqual("#id", css[0].Selector?.CssPaths[0].Item[0].Name);
        //}
        //[TestMethod]
        //public void TestClassSelector()
        //{
        //    var parser = new CssParser("    .class { width:1px;}   ");
        //    var css = parser.Parse();
        //    Assert.AreEqual(".class", css[0].Selector?.CssPaths[0].Item[0].Name);
        //}
    }
}