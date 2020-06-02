using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Veam.Taghelpers
{ 
    [HtmlTargetElement("myfield")]
    //To Use :-  <myfield label-content="description" validation-content="description" asp-for="description"></myfield>
    public class MyFieldTagHelper : TagHelper
    {
        private IHtmlGenerator _htmlGenerator;
        public MyFieldTagHelper(IHtmlGenerator htmlGenerator)
        {
            _htmlGenerator = htmlGenerator;
        }

        public string LabelContent { get; set; }
        public string ValidationContent { get; set; }

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var labelContext = CrateTagHelperContext();
            var labelOutput = CrateTagHelperOutput("label");

            labelOutput.Content.Append(LabelContent);

            if (For != null)
            {
                labelOutput.Attributes.Add("for", For.Name);
            }

            var label = new LabelTagHelper(_htmlGenerator)
            {
                ViewContext = ViewContext
            };

            label.Process(labelContext, labelOutput);


            var inputContext = CrateTagHelperContext();
            var inputOutput = CrateTagHelperOutput("input");

            inputOutput.Attributes.Add("class", "form-control");

            var input = new InputTagHelper(_htmlGenerator)
            {
                For = For,
                ViewContext = ViewContext
            };

            input.Process(inputContext, inputOutput);

            var validationContext = CrateTagHelperContext();
            var validationOutput = CrateTagHelperOutput("span");

            validationOutput.Content.Append(ValidationContent);

            validationOutput.Attributes.Add("class", "text-danger");

            var validation = new ValidationMessageTagHelper(_htmlGenerator)
            {
                For = For,
                ViewContext = ViewContext
            };

            validation.Process(validationContext, validationOutput);

            output.TagName = "";
            output.Content.AppendHtml(labelOutput);
            output.Content.AppendHtml(inputOutput);
            output.Content.AppendHtml(validationOutput);
        }

        private static TagHelperContext CrateTagHelperContext()
        {
            return new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                Guid.NewGuid().ToString("N"));
        }

        private static TagHelperOutput CrateTagHelperOutput(string tagName)
        {
            return new TagHelperOutput(
                tagName,
                new TagHelperAttributeList(),
                (a, b) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetContent(string.Empty);
                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                });
        }
    }

    //[HtmlTargetElement("helplink")]
    //public class RazorTagHelper : TagHelper
    //{
    //    private readonly IHtmlGenerator _htmlGenerator;

    //    public RazorTagHelper(IHtmlGenerator htmlGenerator)
    //    {
    //        _htmlGenerator = htmlGenerator;
    //    }

    //    [ViewContext]
    //    public ViewContext ViewContext { set; get; }
    //    public string field { get; set; }

    //    public override void Process(TagHelperContext context, TagHelperOutput output)
    //    {
    //        //output.TagName = "div";
    //        //output.TagMode = TagMode.StartTagAndEndTag;
    //        var actionAnchor = _htmlGenerator..GenerateActionLink(
    //            ViewContext,
    //            linkText: field,
    //            actionName: null,
    //            controllerName: null,
    //            fragment: null,
    //            hostname: null,
    //            htmlAttributes: null,
    //            protocol: null,
    //            routeValues: null

    //            );
    //        var builder = new HtmlContentBuilder();
    //        //builder.AppendHtml("Here's the link: ");
    //        //builder.AppendHtml(actionAnchor);
    //        //output.Content.SetHtmlContent(builder);
    //        //< label asp -for= "UserName" class="control-label"></label>
    //        //                    <input asp-for="UserName" class="form-control" />
    //        //                    <span asp-validation-for="UserName" class="text-danger"></span>
    //        output.PreContent.SetHtmlContent(@"<div class=""form-group"">");
    //        output.Content.AppendHtml($@"<label class=""control-label"" for='{field}'>{field}</label>");
    //        output.Content.AppendHtml($@"< input class=""form-control"" type=""text"" data-val=""true"" data-val-length=""The field { field }"" value="">");
    //        output.Content.AppendHtml($@" <span class=""text - danger field - validation - valid"" data-valmsg-for={field} data-valmsg-replace=""true""></span>");
    //        output.PostContent.SetHtmlContent("</div>");
    //        output.Attributes.Clear();

    //    }
    //}
}
