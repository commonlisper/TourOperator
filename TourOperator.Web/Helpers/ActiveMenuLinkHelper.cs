using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TourOperator.Web.Helpers
{
    public static class ActiveMenuLinkHelper
    {
        public static string MenuActive(
            this HtmlHelper htmlHelper,
            string actionName,
            string controllerName)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            const string className = "active";

            if (actionName == currentAction && controllerName == currentController)
            {
                return className;
            }

            return null;
        }
    }
}