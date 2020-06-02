using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewTagHelper.TagHelpers
{
    /// <summary>
    /// Renders a partial view.
    /// </summary>
    [HtmlTargetElement("partialView", Attributes = "name", TagStructure = TagStructure.WithoutEndTag)]
    public class PartialViewTagHelper : TagHelper
    {
        private readonly IHtmlHelper _htmlHelper;

        public PartialViewTagHelper(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        /// <summary>
        /// Name of the partial view 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Model passed to partial view.
        /// </summary>
        public object Model { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            ((IViewContextAware)_htmlHelper).Contextualize(ViewContext);

            output.TagName = null;

            var content = await (Model == null ? _htmlHelper.PartialAsync(Name) : _htmlHelper.PartialAsync(Name, Model));
            output.Content.SetHtmlContent(content);
        }
    }
}
