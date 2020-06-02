﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veam
{
    public static class HtmlHelpers
    {

        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];
            
            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            bool result = (controller == currentController && action == currentAction);



            return result ?
                cssClass : String.Empty;
        }

        public static string IsSelected(this IHtmlHelper html, string actions = null)
        {
            var cssClass = "active";


           string currentAction = (string)html.ViewContext.RouteData.Values["action"];
           string[] actionarr = !String.IsNullOrEmpty(actions) ? actions.Split(',') : new string[] { };


            bool result = (actionarr.Contains<string>(currentAction));



            return result ?
                cssClass : String.Empty;
        }

        public static string PageClass(this IHtmlHelper htmlHelper)
        {
            string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

    }
}
