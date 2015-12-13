namespace RazorPdfGenerator
{
    public interface IHtmlGenerator
    {
        string GenerateHtml(string viewPath, object model);
    }
}