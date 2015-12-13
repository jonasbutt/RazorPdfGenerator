using System;
using System.IO;
using RazorEngine;
using RazorEngine.Templating;

namespace RazorPdfGenerator
{
    public class HtmlGenerator : IHtmlGenerator
    {
        public string GenerateHtml(string viewPath, object model)
        {
            var view = File.ReadAllText(viewPath);
            var templateKey = Guid.NewGuid().ToString();
            Engine.Razor.AddTemplate(templateKey, view);
            Engine.Razor.Compile(templateKey, model.GetType());
            var html = Engine.Razor.Run(templateKey, model.GetType(), model);
            return html;
        }
    }
}