﻿/*
 * Copyright (c) 2016 Billy Wolfington
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * https://github.com/Bwolfing/Bootstrap.AspNetCore.Mvc.TagHelpers
 *
 */

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Bootstrap.AspNetCore.Mvc.TagHelpers
{
    public abstract class BootstrapTagHelperBase : TagHelper, IBootstrapTagHelper
    {
        #region Properties
        #region Public properties
        [HtmlAttributeNotBound]
        public abstract string CssClass { get; }

        [HtmlAttributeName(OUTPUT_TAG_ATTRIBUTE_NAME)]
        public virtual string OutputTag { get; set; } = "div";

        string IBootstrapTagHelper.CssClass
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region Protected properties
        protected const string OUTPUT_TAG_ATTRIBUTE_NAME = Global.PREFIX + "output-tag";
        #endregion
        #endregion

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = OutputTag;
            AppendDefaultCssClass(output);
            return Task.CompletedTask;
        }

        protected void AppendDefaultCssClass(TagHelperOutput output)
        {
            if (string.IsNullOrWhiteSpace(CssClass))
            {
                return;
            }
            string cssClass = CssClass;
            if (output.Attributes.ContainsName("class"))
            {
                cssClass += " " + output.Attributes["class"].Value.ToString();
            }
            output.Attributes.SetAttribute("class", cssClass);
        }

        void IBootstrapTagHelper.AppendDefaultCssClass(TagHelperOutput output)
        {
            throw new NotImplementedException();
        }
    }
}
