using HTMLEasyDotnet.Actions;
using Xunit;

namespace HTMLEasyDotnet.Tests
{
    public class DocumentTests
    {
        [Theory]
        [InlineData("https://luizcamargo.dev/")]
        public void TestLoadDocumentSuccess(string url)
        {
            var response = Document.Load(url);
            Assert.NotNull(response);
        }

        [Theory]
        [InlineData("https://DSDSDS.dev/")]
        public void TestLoadDocumentFail(string url)
        {
            var document = Document.Load(url);
            Assert.Null(document);
        }

        [Theory]
        [InlineData("https://ge.globo.com/", "glb-topo", "glb-topo")]
        [InlineData("https://www.dicio.com.br/", "header", "home")]
        [InlineData("https://luizcamargo.dev/", "linkedin", "round_picture contacts")]
        [InlineData("https://github.com/", "start-of-content", "show-on-focus")]
        public void TestClassNameGetElementByIdSuccess(string url, string id, string resultExpected)
        {
            var document = Document.Load(url);
            var element = document.GetElementById(id);
            Assert.Equal(resultExpected, element.ClassName);
        }

        [Theory]
        [InlineData("https://luizcamargo.dev/", "testeFail")]
        public void TestClassNameGetElementByIdFail(string url, string id)
        {
            var document = Document.Load(url);
            var element = document.GetElementById(id);
            Assert.Null(element.ClassName);
        }
    }
}
