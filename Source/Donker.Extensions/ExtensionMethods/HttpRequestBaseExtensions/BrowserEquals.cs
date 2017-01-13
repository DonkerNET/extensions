using System;
using System.Web;

namespace Donker.Extensions.ExtensionMethods.HttpRequestBaseExtensions
{
    public static partial class HttpRequestBaseExtensions
    {
        /// <summary>
        /// Checks if the client browser equals the one that is specified.
        /// </summary>
        /// <param name="request">The request containing the browser information.</param>
        /// <param name="browserName">The name of the browser to check.</param>
        /// <param name="majorVersion">The browser major version should equal this major version, if specified.</param>
        /// <param name="minorVersion">The browser minor version should equal this minor version, if specified.</param>
        /// <returns><c>1</c> if equal; <c>0</c> if not equal; <c>-1</c> if unknown.</returns>
        /// <exception cref="ArgumentNullException"><see cref="browserName"/> is null.</exception>
        /// <exception cref="ArgumentException"><see cref="browserName"/> is empty.</exception>
        public static int BrowserEquals(this HttpRequestBase request, string browserName, int? majorVersion, double? minorVersion)
        {
            if (browserName == null)
                throw new ArgumentNullException("browserName", "The browser name cannot be null.");
            if (browserName.Length == 0)
                throw new ArgumentException("The browser name cannot be empty.", "browserName");

            string actualBrowserName = request.Browser.Browser;

            if (string.IsNullOrEmpty(actualBrowserName))
                return -1;

            if (!string.Equals(actualBrowserName, browserName, StringComparison.OrdinalIgnoreCase))
                return 0;

            if (!majorVersion.HasValue && !minorVersion.HasValue)
                return 1;

            if (string.IsNullOrEmpty(request.Browser.Version))
                return -1;

            bool isMajorVersionOk = !majorVersion.HasValue || request.Browser.MajorVersion == majorVersion;
            bool isMinorVersionOk = !minorVersion.HasValue || request.Browser.MinorVersion == minorVersion;

            return isMajorVersionOk && isMinorVersionOk ? 1 : 0;
        }

        /// <summary>
        /// Checks if the client browser equals the one that is specified.
        /// </summary>
        /// <param name="request">The request containing the browser information.</param>
        /// <param name="browserName">The name of the browser to check.</param>
        /// <param name="majorVersion">The browser major version should equal this major version, if specified.</param>
        /// <returns><c>1</c> if equal; <c>0</c> if not equal; <c>-1</c> if unknown.</returns>
        /// <exception cref="ArgumentNullException"><see cref="browserName"/> is null.</exception>
        /// <exception cref="ArgumentException"><see cref="browserName"/> is empty.</exception>
        public static int BrowserEquals(this HttpRequestBase request, string browserName, int? majorVersion)
        {
            return BrowserEquals(request, browserName, majorVersion, null);
        }

        /// <summary>
        /// Checks if the client browser equals the one that is specified.
        /// </summary>
        /// <param name="request">The request containing the browser information.</param>
        /// <param name="browserName">The name of the browser to check.</param>
        /// <returns><c>1</c> if equal; <c>0</c> if not equal; <c>-1</c> if unknown.</returns>
        /// <exception cref="ArgumentNullException"><see cref="browserName"/> is null.</exception>
        /// <exception cref="ArgumentException"><see cref="browserName"/> is empty.</exception>
        public static int BrowserEquals(this HttpRequestBase request, string browserName)
        {
            return BrowserEquals(request, browserName, null, null);
        }
    }
}