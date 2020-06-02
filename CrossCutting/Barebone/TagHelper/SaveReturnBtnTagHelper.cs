using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Veam.Taghelpers
{
    [HtmlTargetElement("SaveReturnBtn")]
    public class SaveReturnBtnTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("SaveReturnBtn");
            output.PreContent.SetHtmlContent(@"<div class=""box-footer"">");
            output.PreContent.AppendHtml(@" <button type = ""submit"" class=""btn btn-primary pull-right"" ><i class=""fa fa-save""></i>  Save</button>");
            output.PreContent.AppendHtml(@" <button type = ""button"" class=""btn btn-default pull-left"" data-dismiss=""modal""  > Cancel</button>");

            // output.PreContent.AppendHtml($@"</div>");
            // here InputField Rendered
            output.PostContent.SetHtmlContent("</div>");
            output.Attributes.Clear();

        }
    }
}

           