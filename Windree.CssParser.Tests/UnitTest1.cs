using Windree.CssParser.Entities;

namespace Windree.CssParser.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ContentBlock[] css;
        public UnitTest1()
        {
            var parser = new RootContentBlock(" /*start*/ 'string' {width:100%/*width - 100%*/; height: '30px'} /**/''");
            css = parser.Parse();
        }

        [TestMethod]
        public void TestCommentInRootEmpty()
        {
            Assert.AreEqual(CodeBlockType.Comment, css[3].Type);
            Assert.AreEqual(65, css[3].StartOffset);
            Assert.AreEqual(69, css[3].EndOffset);
        }
        [TestMethod]
        public void TestStringInRootEmpty()
        {
            Assert.AreEqual(CodeBlockType.String, css[4].Type);
            Assert.AreEqual(69, css[4].StartOffset);
            Assert.AreEqual(71, css[4].EndOffset);
        }
        [TestMethod]
        public void TestCommentInRoot()
        {
            Assert.AreEqual(CodeBlockType.Comment, css[0].Type);
            Assert.AreEqual(1, css[0].StartOffset);
            Assert.AreEqual(10, css[0].EndOffset);
        }
        [TestMethod]
        public void TestStringInRoot()
        {
            Assert.AreEqual(CodeBlockType.String, css[1].Type);
            Assert.AreEqual(11, css[1].StartOffset);
            Assert.AreEqual(19, css[1].EndOffset);
        }
        [TestMethod]
        public void TestProperties()
        {
            Assert.AreEqual(CodeBlockType.Properties, css[2].Type);
            Assert.AreEqual(20, css[2].StartOffset);
            Assert.AreEqual(64, css[2].EndOffset);
        }

    }
}