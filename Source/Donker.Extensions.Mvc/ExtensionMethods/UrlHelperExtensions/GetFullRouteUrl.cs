using System;
using System.Web.Mvc;

namespace Donker.Extensions.Mvc.ExtensionMethods.UrlHelperExtensions
{
    public static partial class UrlHelperExtensions
    {
        /// <summary>
        /// Gets the full URL for a specific route and route values.
        /// </summary>
        /// <param name="urlHelper">The instance of the URL helper to get the URL from.</param>
        /// <param name="routeName">The name of the route to get the full URL for.</param>
        /// <param name="routeValues">The route values to include when getting the full URL.</param>
        /// <returns>The full URL as a <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">The URL helper is null.</exception>
        public static string GetFullRouteUrl(this UrlHelper urlHelper, string routeName, object routeValues = null)
        {
            if (urlHelper == null)
                throw new ArgumentNullException("urlHelper", "The URL helper cannot be null.");

            string relativeRoute = urlHelper.RouteUrl(routeName, routeValues);
            
            Uri currentUrl = urlHelper.RequestContext.HttpContext.Request.Url;

            if (currentUrl == null)
                return relativeRoute;

            return currentUrl.GetLeftPart(UriPartial.Authority) + relativeRoute;
        }
    }
}
