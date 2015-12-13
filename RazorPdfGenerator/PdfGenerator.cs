using System.Threading;
using Spire.Pdf;
using Spire.Pdf.HtmlConverter;

namespace RazorPdfGenerator
{
    public class PdfGenerator : IPdfGenerator
    {
        private readonly IHtmlGenerator htmlGenerator;

        public PdfGenerator(IHtmlGenerator htmlGenerator)
        {
            this.htmlGenerator = htmlGenerator;
        }

        public void GeneratePdf(string viewPath, object model, string pdfFilePath)
        {
            var html = this.htmlGenerator.GenerateHtml(viewPath, model);
            var pdfDocument = new PdfDocument();
            var thread = new Thread(() =>
            {
                var pdfPageSettings = new PdfPageSettings { Size = PdfPageSize.A4 };
                var pdfHtmlLayoutFormat = new PdfHtmlLayoutFormat { IsWaiting = false };
                pdfDocument.LoadFromHTML(html, false, pdfPageSettings, pdfHtmlLayoutFormat);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            pdfDocument.CompressionLevel = PdfCompressionLevel.None;
            pdfDocument.SaveToFile(pdfFilePath);
            pdfDocument.Close();
        }
    }
}