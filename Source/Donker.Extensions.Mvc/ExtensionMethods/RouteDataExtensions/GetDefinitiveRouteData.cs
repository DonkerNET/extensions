using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace Donker.Extensions.Mvc.ExtensionMethods.RouteDataExtensions
{
    public static partial class RouteDataExtensions
    {
        /// <summary>
        /// Checks if the route data contains attribute routes and returns these; otherwise the normal route data is returned.
        /// </summary>
        /// <param name="routeData">The route data to check.</param>
        /// <returns>The attribute route data as a <see cref="RouteData"/> object.</returns>
        /// <exception cref="ArgumentNullException">The route data is null.</exception>
        /// <remarks>
        /// <para>For attribute routing, the route values are stored in a nested route key named MS_DirectRouteMatches.</para>
        /// <para>See: http://stackoverflow.com/questions/29080707/requestcontext-routedata-does-not-contain-action/29083492</para>
        /// </remarks>
        public static RouteData GetDefinitiveRouteData(this RouteData routeData)
        {
            if (routeData == null)
                throw new ArgumentNullException("routeData", "The route data cannot be null.");

            object msDirectRouteMatchesObj;

            if (routeData.Values.TryGetValue("MS_DirectRouteMatches", out msDirectRouteMatchesObj))
            {
                IEnumerable<RouteData> msDirectRouteMatches = msDirectRouteMatchesObj as IEnumerable<RouteData>;
                if (msDirectRouteMatches != null)
                {
                    RouteData definitiveRouteData = msDirectRouteMatches.FirstOrDefault();
                    if (definitiveRouteData != null)
                        return definitiveRouteData;
                }
            }

            return routeData;
        }
    }
}