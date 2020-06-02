using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Veam.Taghelpers
{
    [HtmlTargetElement("Seperator")]
    //  <Seperator id="Genral" name="General Data"> Content Fields </Seperator>
    public class SeperatorTagHelper : TagHelper
    {
         
        public string id { get; set; }
        public string Name { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        { 
            output.Attributes.RemoveAll("Seperator");
            output.PreContent.SetHtmlContent(@"<div class=""separator text-bold"">");
            output.PreContent.AppendHtml($@"<a  data-toggle=""collapse"" data-parent=""#accordion"" href=""#{id}"" class="" text-red"">{Name}</a>");
            output.PreContent.AppendHtml($@"</div>");
            output.PreContent.AppendHtml($@" <div id=""{id}"" class=""panel-collapse collapse in""> ");
            output.PreContent.AppendHtml("<br>");
            ///Here Goes Content Renedered
            output.PostContent.SetHtmlContent("</div> <br><br>");


            output.Attributes.Clear();  
        }
    }
 
}
