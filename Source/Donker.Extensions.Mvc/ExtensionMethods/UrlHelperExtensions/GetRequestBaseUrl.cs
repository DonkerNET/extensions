using System;
using System.Web.Mvc;

namespace Donker.Extensions.Mvc.ExtensionMethods.UrlHelperExtensions
{
    public static partial class UrlHelperExtensions
    {
        /// <summary>
        /// Gets the authority part of the request URL.
        /// </summary>
        /// <param name="urlHelper">The instance of the URL helper to get the authority part from.</param>
        /// <returns>The authority part as a <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">The URL helper is null.</exception>
        public static string GetRequestBaseUrl(this UrlHelper urlHelper)
        {
            if (urlHelper == null)
                throw new ArgumentNullException("urlHelper", "The URL helper cannot be null.");
            
            Uri currentUrl = urlHelper.RequestContext.HttpContext.Request.Url;
            
            if (currentUrl == null)
                return string.Empty;
            
            return currentUrl.GetLeftPart(UriPartial.Authority);
        }
    }
}
