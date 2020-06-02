using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NonFactors.Mvc.Lookup
{
    public static class LookupExtensions
    {
        public static TagBuilder AutoComplete<TModel>(this IHtmlHelper<TModel> html,
            String name, MvcLookup model, Object? value = null, Object? htmlAttributes = null)
        {
            TagBuilder lookup = CreateLookup(model, name, htmlAttributes);
            lookup.AddCssClass("mvc-lookup-browseless");

            lookup.InnerHtml.AppendHtml(CreateLookupValues(html, model, name, value));
            lookup.InnerHtml.AppendHtml(CreateLookupControl(html, model, name));

            return lookup;
        }
        public static TagBuilder AutoCompleteFor<TModel, TProperty>(this IHtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression, MvcLookup model, Object? htmlAttributes = null)
        {
            String name = LookupExpressionMetadata.GetName(expression);
            TagBuilder lookup = CreateLookup(model, name, htmlAttributes);
            lookup.AddCssClass("mvc-lookup-browseless");

            lookup.InnerHtml.AppendHtml(CreateLookupValues(html, model, expression));
            lookup.InnerHtml.AppendHtml(CreateLookupControl(html, model, name));

            return lookup;
        }

        public static TagBuilder Lookup<TModel>(this IHtmlHelper<TModel> html,
            String name, MvcLookup model, Object? value = null, Object? htmlAttributes = null)
        {
            TagBuilder lookup = CreateLookup(model, name, htmlAttributes);

            lookup.InnerHtml.AppendHtml(CreateLookupValues(html, model, name, value));
            lookup.InnerHtml.AppendHtml(CreateLookupControl(html, model, name));
            lookup.InnerHtml.AppendHtml(CreateLookupBrowser(name));

            return lookup;
        }
        public static TagBuilder LookupFor<TModel, TProperty>(this IHtmlHelper<TModel> html,
            Expression<Func<TModel, TProperty>> expression, MvcLookup model, Object? htmlAttributes = null)
        {
            String name = LookupExpressionMetadata.GetName(expression);
            TagBuilder lookup = CreateLookup(model, name, htmlAttributes);

            lookup.InnerHtml.AppendHtml(CreateLookupValues(html, model, expression));
            lookup.InnerHtml.AppendHtml(CreateLookupControl(html, model, name));
            lookup.InnerHtml.AppendHtml(CreateLookupBrowser(name));

            return lookup;
        }

        private static TagBuilder CreateLookup(MvcLookup lookup, String name, Object? htmlAttributes)
        {
            IDictionary<String, Object?> attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            attributes["data-filters"] = String.Join(",", lookup.AdditionalFilters);
            attributes["data-search"] = lookup.Filter.Search;
            attributes["data-offset"] = lookup.Filter.Offset;
            attributes["data-order"] = lookup.Filter.Order;
            attributes["data-readonly"] = lookup.ReadOnly;
            attributes["data-sort"] = lookup.Filter.Sort;
            attributes["data-rows"] = lookup.Filter.Rows;
            attributes["data-dialog"] = lookup.Dialog;
            attributes["data-title"] = lookup.Title;
            attributes["data-multi"] = lookup.Multi;
            attributes["data-url"] = lookup.Url;
            attributes["data-for"] = name;

            TagBuilder group = new TagBuilder("div");
            group.MergeAttributes(attributes);
            group.AddCssClass("mvc-lookup");

            if (lookup.ReadOnly)
                group.AddCssClass("mvc-lookup-readonly");

            return group;
        }

        private static IHtmlContent CreateLookupValues<TModel, TProperty>(IHtmlHelper<TModel> html, MvcLookup lookup, Expression<Func<TModel, TProperty>> expression)
        {
            Object value = LookupExpressionMetadata.GetValue(html, expression).Model;
            String name = LookupExpressionMetadata.GetName(expression);

            if (lookup.Multi)
                return CreateLookupValues(html, lookup, name, value);

            IDictionary<String, Object> attributes = new Dictionary<String, Object>
            {
                ["class"] = "mvc-lookup-value",
                ["autocomplete"] = "off"
            };

            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("mvc-lookup-values");
            container.Attributes["data-for"] = name;

            container.InnerHtml.AppendHtml(html.HiddenFor(expression, attributes));

            return container;
        }
        private static IHtmlContent CreateLookupValues(IHtmlHelper html, MvcLookup lookup, String name, Object? value)
        {
            IDictionary<String, Object> attributes = new Dictionary<String, Object>
            {
                ["class"] = "mvc-lookup-value",
                ["autocomplete"] = "off"
            };

            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("mvc-lookup-values");
            container.Attributes["data-for"] = name;

            if (lookup.Multi)
            {
                IEnumerable<Object>? values = (value as IEnumerable)?.Cast<Object>();
                if (values == null)
                    return container;

                IHtmlContentBuilder inputs = new HtmlContentBuilder();
                foreach (Object val in values)
                {
                    TagBuilder input = new TagBuilder("input");
                    input.Attributes["value"] = html.FormatValue(val, null);
                    input.TagRenderMode = TagRenderMode.SelfClosing;
                    input.Attributes["type"] = "hidden";
                    input.MergeAttributes(attributes);
                    input.Attributes["name"] = name;

                    inputs.AppendHtml(input);
                }

                container.InnerHtml.AppendHtml(inputs);
            }
            else
            {
                container.InnerHtml.AppendHtml(html.Hidden(name, value, attributes));
            }

            return container;
        }
        private static IHtmlContent CreateLookupControl(IHtmlHelper html, MvcLookup lookup, String name)
        {
            TagBuilder search = new TagBuilder("input") { TagRenderMode = TagRenderMode.SelfClosing };
            TagBuilder control = new TagBuilder("div");
            TagBuilder loader = new TagBuilder("div");
            TagBuilder error = new TagBuilder("div");

            Dictionary<String, Object> attributes = new Dictionary<String, Object>
            {
                ["class"] = "mvc-lookup-input",
                ["autocomplete"] = "off"
            };

            if (lookup.Placeholder != null)
                attributes["placeholder"] = lookup.Placeholder;
            if (lookup.Name != null)
                attributes["id"] = html.Id(lookup.Name);
            if (lookup.Name != null)
                attributes["name"] = lookup.Name;
            if (lookup.ReadOnly)
                attributes["readonly"] = "readonly";

            loader.AddCssClass("mvc-lookup-control-loader");
            error.AddCssClass("mvc-lookup-control-error");
            control.AddCssClass("mvc-lookup-control");
            control.Attributes["data-for"] = name;
            search.MergeAttributes(attributes);
            error.InnerHtml.Append("!");

            control.InnerHtml.AppendHtml(lookup.Name == null ? search : html.TextBox(lookup.Name, null, attributes));
            control.InnerHtml.AppendHtml(loader);
            control.InnerHtml.AppendHtml(error);

            return control;
        }
        private static IHtmlContent CreateLookupBrowser(String name)
        {
            TagBuilder browser = new TagBuilder("button");
            browser.AddCssClass("mvc-lookup-browser");
            browser.Attributes["data-for"] = name;
            browser.Attributes["type"] = "button";

            TagBuilder icon = new TagBuilder("span");
            icon.AddCssClass("mvc-lookup-icon");

            browser.InnerHtml.AppendHtml(icon);

            return browser;
        }
    }
}
