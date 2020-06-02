using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Veam.Taghelpers
{
    [HtmlTargetElement("BoxTools")]
    //<DatePicker>
    //   <input asp-for="TryDate" value="@DateTime.Now" class="form-control pull-right datepicker" type="text" />
    //   <input asp-for="TryDate"  class="form-control pull-right datepicker" type="text" />
    //</DatePicker>
    public class BoxToolsTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("BoxTools");
            output.PreContent.SetHtmlContent(@"<div class=""box-tools pull-right"">");
            output.PreContent.AppendHtml(@" <button type = ""button"" class=""btn btn-box-tool"" data-widget=""collapse"" data-toggle=""tooltip"" title=""Collapse"">  <i class=""fa fa-minus""></i>  </button>");
            output.PreContent.AppendHtml(@" <button type = ""button"" class=""btn btn-box-tool"" data-widget=""remove"" data-toggle=""tooltip"" title=""Remove"">  <i class=""fa fa-times""></i>  </button>");
             
           // output.PreContent.AppendHtml($@"</div>");
            // here InputField Rendered
            output.PostContent.SetHtmlContent("</div>");
            output.Attributes.Clear(); 
            
        }
    }
}

           