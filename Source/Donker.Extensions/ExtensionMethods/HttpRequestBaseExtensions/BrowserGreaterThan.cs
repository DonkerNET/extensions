using System;
using System.Web;

namespace Donker.Extensions.ExtensionMethods.HttpRequestBaseExtensions
{
    public static partial class HttpRequestBaseExtensions
    {
        /// <summary>
        /// Checks if the client browser version is higher than the specified version.
        /// </summary>
        /// <param name="request">The request containing the browser information.</param>
        /// <param name="browserName">The name of the browser to check the version for.</param>
        /// <param name="majorVersion">The browser major version should be higher than this major version, if a minor version is not specified.</param>
        /// <param name="minorVersion">The browser minor version should be higher than this minor version, if specified.</param>
        /// <returns><c>1</c> if greater; <c>0</c> if equal, lesser or different browser; <c>-1</c> if unknown.</returns>
        /// <exception cref="ArgumentNullException"><see cref="browserName"/> is null.</exception>
        /// <exception cref="ArgumentException"><see cref="browserName"/> is empty.</exception>
        public static int BrowserGreaterThan(this HttpRequestBase request, string browserName, int majorVersion, double? minorVersion)
        {
            if (browserName == null)
                throw new ArgumentNullException("browserName", "The browser name cannot be null.");
            if (browserName.Length == 0)
                throw new ArgumentException("The browser name cannot be empty.", "browserName");

            string actualBrowserName = request.Browser.Browser;

            if (string.IsNullOrEmpty(actualBrowserName) || string.IsNullOrEmpty(request.Browser.Version))
                return -1;

            int actualMajorVersion = request.Browser.MajorVersion;

            if (!string.Equals(actualBrowserName, browserName, StringComparison.OrdinalIgnoreCase) || actualMajorVersion < majorVersion)
                return 0;

            if (actualMajorVersion > majorVersion)
                return 1;

            return minorVersion.HasValue && request.Browser.MinorVersion > minorVersion
                ? 1
                : 0;
        }

        /// <summary>
        /// Checks if the client browser version is higher than the specified version.
        /// </summary>
        /// <param name="request">The request containing the browser information.</param>
        /// <param name="browserName">The name of the browser to check the version for.</param>
        /// <param name="majorVersion">The browser major version should be higher than this major version.</param>
        /// <returns><c>1</c> if greater; <c>0</c> if equal, lesser or different browser; <c>-1</c> if unknown.</returns>
        /// <exception cref="ArgumentNullException"><see cref="browserName"/> is null.</exception>
        /// <exception cref="ArgumentException"><see cref="browserName"/> is empty.</exception>
        public static int BrowserGreaterThan(this HttpRequestBase request, string browserName, int majorVersion)
        {
            return BrowserGreaterThan(request, browserName, majorVersion, null);
        }
    }
}