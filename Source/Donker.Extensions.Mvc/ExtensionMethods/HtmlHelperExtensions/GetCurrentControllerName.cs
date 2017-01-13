using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Donker.Extensions.Mvc.ExtensionMethods.HtmlHelperExtensions
{
    public static partial class HtmlHelperExtensions
    {
        /// <summary>
        /// Gets the current controller name if possible.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper to get the controller name from.</param>
        /// <returns>The name of the current controller as a <see cref="string"/> if found; otherwise, <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="htmlHelper"/> is null.</exception>
        public static string GetCurrentControllerName(this HtmlHelper htmlHelper)
        {
            if (htmlHelper == null)
                throw new ArgumentNullException("htmlHelper", "The HTML helper cannot be null.");

            RouteData routeData = htmlHelper.ViewContext.RouteData;

            // For attribute routing, the route values are stored in a nested route key named MS_DirectRouteMatches.
            // See: http://stackoverflow.com/questions/29080707/requestcontext-routedata-does-not-contain-action/29083492

            object msDirectRouteMatchesObj;
            if (routeData.Values.TryGetValue("MS_DirectRouteMatches", out msDirectRouteMatchesObj))
            {
                IEnumerable<RouteData> msDirectRouteMatches = msDirectRouteMatchesObj as IEnumerable<RouteData>;
                if (msDirectRouteMatches != null)
                    routeData = msDirectRouteMatches.FirstOrDefault() ?? htmlHelper.ViewContext.RouteData;
            }

            string controllerName = routeData.Values["controller"] as string;
            return controllerName ?? string.Empty;
        }
    }
}
