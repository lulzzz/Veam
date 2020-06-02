using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace Barebone
{
    public static class HtmlHelperExtensions
    {
        private const string _partialViewScriptItemPrefix = "scripts_";

        public static IHtmlContent PartialSectionScripts(this IHtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            htmlHelper.ViewContext.HttpContext.Items[_partialViewScriptItemPrefix + Guid.NewGuid()] = template;
            return new HtmlContentBuilder();
        }

        public static IHtmlContent RenderPartialSectionScripts(this IHtmlHelper htmlHelper)
        {
            var partialSectionScripts = htmlHelper.ViewContext.HttpContext.Items.Keys
                .Where(k => Regex.IsMatch(
                    k.ToString(),
                    "^" + _partialViewScriptItemPrefix + "([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$"));

            var contentBuilder = new HtmlContentBuilder();

            foreach (var key in partialSectionScripts)
            {
                var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;

                if (template != null)
                {
                    var writer = new System.IO.StringWriter();
                    template(null).WriteTo(writer, HtmlEncoder.Default);
                    contentBuilder.AppendHtml(writer.ToString());
                }
            }

            return contentBuilder;
        }
    }

   // https://stackoverflow.com/a/56918543
    public static class HtmlHelpers
    {
        private const string ScriptsKey = "DelayedScripts";

        public static IDisposable BeginScripts(this IHtmlHelper helper)
        {
            return new ScriptBlock(helper.ViewContext);
        }

        public static HtmlString PageScripts(this IHtmlHelper helper)
        {
            return new HtmlString(string.Join(Environment.NewLine, GetPageScriptsList(helper.ViewContext.HttpContext)));
        }

        private static List<string> GetPageScriptsList(HttpContext httpContext)
        {
            var pageScripts = (List<string>)httpContext.Items[ScriptsKey];
            if (pageScripts == null)
            {
                pageScripts = new List<string>();
                httpContext.Items[ScriptsKey] = pageScripts;
            }
            return pageScripts;
        }

        private class ScriptBlock : IDisposable
        {
            private readonly TextWriter _originalWriter;
            private readonly StringWriter _scriptsWriter;

            private readonly ViewContext _viewContext;

            public ScriptBlock(ViewContext viewContext)
            {
                _viewContext = viewContext;
                _originalWriter = _viewContext.Writer;
                _viewContext.Writer = _scriptsWriter = new StringWriter();
            }

            public void Dispose()
            {
                _viewContext.Writer = _originalWriter;
                var pageScripts = GetPageScriptsList(_viewContext.HttpContext);
                pageScripts.Add(_scriptsWriter.ToString());
            }
        }
    }
}
