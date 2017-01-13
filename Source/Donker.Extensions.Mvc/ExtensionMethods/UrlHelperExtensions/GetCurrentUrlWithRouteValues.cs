using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Donker.Extensions.Mvc.ExtensionMethods.UrlHelperExtensions
{
    public static partial class UrlHelperExtensions
    {
        /// <summary>
        /// Returns the current URL, merged with the specified route values.
        /// </summary>
        /// <param name="urlHelper">The URL helper used for creating the new URL.</param>
        /// <param name="routeValues">The route values to merge.</param>
        /// <returns>The new URL as a <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">The URL helper is null.</exception>
        public static string GetCurrentUrlWithRouteValues(this UrlHelper urlHelper, object routeValues)
        {
            if (urlHelper == null)
                throw new ArgumentNullException("urlHelper", "The URL helper cannot be null.");

            RouteData routeData = urlHelper.RequestContext.RouteData;

            // For attribute routing, the route values are stored in a nested route key named MS_DirectRouteMatches.
            // See: http://stackoverflow.com/questions/29080707/requestcontext-routedata-does-not-contain-action/29083492

            object msDirectRouteMatchesObj;
            if (routeData.Values.TryGetValue("MS_DirectRouteMatches", out msDirectRouteMatchesObj))
            {
                IEnumerable<RouteData> msDirectRouteMatches = msDirectRouteMatchesObj as IEnumerable<RouteData>;
                if (msDirectRouteMatches != null)
                    routeData = msDirectRouteMatches.FirstOrDefault() ?? urlHelper.RequestContext.RouteData;
            }

            RouteValueDictionary currentRouteValues = new RouteValueDictionary(routeData.Values);
            NameValueCollection queryString = urlHelper.RequestContext.HttpContext.Request.QueryString;

            foreach (string key in queryString.Keys)
            {
                string[] values = queryString.GetValues(key);
                currentRouteValues[key] = values != null
                    ? string.Join(",", values)
                    : string.Empty;
            }

            foreach (KeyValuePair<string, object> routeValue in new RouteValueDictionary(routeValues))
                currentRouteValues[routeValue.Key] = routeValue.Value;

            return urlHelper.RouteUrl(currentRouteValues);
        }
    }
}