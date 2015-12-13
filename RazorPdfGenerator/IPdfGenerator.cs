namespace RazorPdfGenerator
{
    public interface IPdfGenerator
    {
        void GeneratePdf(string viewPath, object model, string pdfFilePath);
    }
}