using HTMLEasyDotnet.Actions;
using Xunit;

namespace HTMLEasyDotnet.Tests
{
    public class LoadDocumentTests
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
    }
}
