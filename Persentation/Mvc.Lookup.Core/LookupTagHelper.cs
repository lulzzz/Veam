using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NonFactors.Mvc.Lookup
{
    [HtmlTargetElement("div", Attributes = "mvc-lookup,url")]
    [HtmlTargetElement("div", Attributes = "mvc-lookup-for,url")]
    public class LookupTagHelper : TagHelper
    {
        public String? Url { get; set; }
        public Int32? Rows { get; set; }
        public String? Name { get; set; }
        public String? Sort { get; set; }
        public Object? Value { get; set; }
        public String? Title { get; set; }
        public String? Search { get; set; }
        public String? Dialog { get; set; }
        public String? Filters { get; set; }
        public Boolean? Multi { get; set; }
        public Boolean? Browser { get; set; }
        public Boolean? Readonly { get; set; }
        public String? Placeholder { get; set; }
        public new LookupSortOrder? Order { get; set; }

        [HtmlAttributeName("mvc-lookup")]
        public String? LookupName { get; set; }

        [HtmlAttributeName("mvc-lookup-for")]
        public ModelExpression? Lookup { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }

        private String? For { get; set; }
        private IHtmlGenerator Html { get; }
        private Func<ViewContext?, IUrlHelper> UrlFactory { get; }

        public LookupTagHelper(IHtmlGenerator html, IUrlHelperFactory factory)
        {
            Html = html;
            UrlFactory = factory.GetUrlHelper;
        }

        public override void Process(TagHelperContext? context, TagHelperOutput output)
        {
            Url = Url?.StartsWith("~") == true ? UrlFactory(ViewContext).Content(Url) : Url;
            For = LookupName ?? Lookup?.Name;
            Value ??= Lookup?.Model;

            WriteAttributes(output);
            WriteValues(output);
            WriteControl(output);

            if (Browser != false)
                WriteBrowser(output);
        }

        private void WriteValues(TagHelperOutput output)
        {
            IDictionary<String, Object> attributes = new Dictionary<String, Object>
            {
                ["class"] = "mvc-lookup-value",
                ["autocomplete"] = "off"
            };

            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("mvc-lookup-values");
            container.Attributes["data-for"] = For;

            if (Multi == true)
            {
                foreach (Object val in (Value as IEnumerable)?.Cast<Object>() ?? new Object[0])
                {
                    TagBuilder input = new TagBuilder("input");
                    input.Attributes["value"] = Html.FormatValue(val, null);
                    input.TagRenderMode = TagRenderMode.SelfClosing;
                    input.Attributes["type"] = "hidden";
                    input.MergeAttributes(attributes);
                    input.Attributes["name"] = For;

                    container.InnerHtml.AppendHtml(input);
                }
            }
            else
            {
                container.InnerHtml.AppendHtml(Html.GenerateHidden(ViewContext, Lookup?.ModelExplorer, For, Value, Lookup?.ModelExplorer == null && Value == null, attributes));
            }

            output.Content.AppendHtml(container);
        }
        private void WriteControl(TagHelperOutput output)
        {
            TagBuilder search = new TagBuilder("input") { TagRenderMode = TagRenderMode.SelfClosing };
            Dictionary<String, Object> attributes = new Dictionary<String, Object>();
            TagBuilder control = new TagBuilder("div");
            TagBuilder loader = new TagBuilder("div");
            TagBuilder error = new TagBuilder("div");

            attributes["class"] = "mvc-lookup-input";
            attributes["autocomplete"] = "off";

            if (Placeholder != null)
                attributes["placeholder"] = Placeholder;
            if (Readonly == true)
                attributes["readonly"] = "readonly";
            if (Name != null)
                attributes["name"] = Name;

            loader.AddCssClass("mvc-lookup-control-loader");
            error.AddCssClass("mvc-lookup-control-error");
            control.AddCssClass("mvc-lookup-control");
            control.Attributes["data-for"] = For;
            search.MergeAttributes(attributes);
            error.InnerHtml.Append("!");

            control.InnerHtml.AppendHtml(Name == null ? search : Html.GenerateTextBox(ViewContext, null, Name, null, null, attributes));
            control.InnerHtml.AppendHtml(loader);
            control.InnerHtml.AppendHtml(error);

            output.Content.AppendHtml(control);
        }
        private void WriteBrowser(TagHelperOutput output)
        {
            TagBuilder browser = new TagBuilder("button");
            browser.AddCssClass("mvc-lookup-browser");
            browser.Attributes["type"] = "button";
            browser.Attributes["data-for"] = For;

            TagBuilder icon = new TagBuilder("span");
            icon.AddCssClass("mvc-lookup-icon");

            browser.InnerHtml.AppendHtml(icon);

            output.Content.AppendHtml(browser);
        }
        private void WriteAttributes(TagHelperOutput output)
        {
            String classes = "mvc-lookup";

            if (Readonly == true)
                classes += " mvc-lookup-readonly";

            if (Browser == false)
                classes += " mvc-lookup-browseless";

            WriteAttribute(output, "data-for", For);
            WriteAttribute(output, "data-url", Url);
            WriteAttribute(output, "data-rows", Rows);
            WriteAttribute(output, "data-sort", Sort);
            WriteAttribute(output, "data-multi", Multi);
            WriteAttribute(output, "data-order", Order);
            WriteAttribute(output, "data-title", Title);
            WriteAttribute(output, "data-dialog", Dialog);
            WriteAttribute(output, "data-search", Search);
            WriteAttribute(output, "data-filters", Filters);
            WriteAttribute(output, "data-readonly", Readonly);
            WriteAttribute(output, "class", (classes + " " + output.Attributes["class"]?.Value).Trim());
        }
        private void WriteAttribute(TagHelperOutput output, String key, Object? value)
        {
            if (value != null)
                output.Attributes.SetAttribute(key, value);
        }
    }
}
