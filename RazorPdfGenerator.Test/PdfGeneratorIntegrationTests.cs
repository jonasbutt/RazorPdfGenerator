using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RazorPdfGenerator.Test
{
    [TestClass]
    public class PdfGeneratorIntegrationTests
    {
        [TestMethod]
        public void CanGeneratePdf()
        {
            // Arrange
            var currentPath = Directory.GetCurrentDirectory();
            var viewPath = Path.Combine(currentPath, "View.cshtml");
            var pdfFilePath = Path.Combine(currentPath, "Pdf.pdf");
            var pdfGenerator = new PdfGenerator(new HtmlGenerator());

            // Act
            pdfGenerator.GeneratePdf(viewPath, new Model { Value = "Hello World!" }, pdfFilePath);

            // Assert
            Assert.IsTrue(File.Exists(pdfFilePath));
            Process.Start(pdfFilePath);
        }
    }
}