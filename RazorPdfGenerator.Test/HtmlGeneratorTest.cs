using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RazorPdfGenerator.Test
{
    [TestClass]
    public class HtmlGeneratorTest
    {
        [TestMethod]
        public void CanGenerateHtml()
        {
            // Arrange
            var currentPath = Directory.GetCurrentDirectory();
            var viewPath = Path.Combine(currentPath, "View.cshtml");
            var htmlGenerator = new HtmlGenerator();

            // Act
            var html = htmlGenerator.GenerateHtml(viewPath, new Model { Value = "Hello World!" });

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(html));
        }
    }
}