using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Veam.Taghelpers
{
    [HtmlTargetElement("DatePicker")]
    //<DatePicker>
    //   <input asp-for="TryDate" value="@DateTime.Now" class="form-control pull-right datepicker" type="text" />
    //   <input asp-for="TryDate"  class="form-control pull-right datepicker" type="text" />
    //</DatePicker>
    public class DatePickerTagHelper : TagHelper
    { 
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("DatePicker");
            output.PreContent.SetHtmlContent(@"<div class=""input-group date"">");
            output.PreContent.AppendHtml(@"<div class=""input-group-addon"">");
            output.PreContent.AppendHtml(@"<i class=""fa fa-calendar""></i>"); 
            output.PreContent.AppendHtml($@"</div>");
            // here InputField Rendered
            output.PostContent.SetHtmlContent("</div>");
            output.Attributes.Clear();
        }
    }
}
