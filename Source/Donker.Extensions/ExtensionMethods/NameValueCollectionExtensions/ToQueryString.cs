using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class NameValueCollectionExtensions
    {
        /// <summary>
        /// Builds a query string from a <see cref="NameValueCollection"/>.
        /// </summary>
        /// <param name="collection">The <see cref="NameValueCollection"/> object to build the query string from.</param>
        /// <param name="useUrlEncoding">If <value>true</value>, encodes the keys and values from the <paramref name="collection"/>.</param>
        /// <returns>The <paramref name="collection"/> as a query string.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <value>null</value>.</exception>
        public static string ToQueryString(this NameValueCollection collection, bool useUrlEncoding)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            int collectionCount = collection.Count;

            if (collectionCount == 0)
                return string.Empty;
            
            StringBuilder resultBuilder = new StringBuilder();
            const string format = "{0}={1}&";

            if (useUrlEncoding)
            {
                for (int i = 0; i < collectionCount; i++)
                    resultBuilder.AppendFormat(format,
                        HttpUtility.UrlEncode(collection.AllKeys[i]),
                        HttpUtility.UrlEncode(collection[i]));
            }
            else
            {
                for (int i = 0; i < collectionCount; i++)
                    resultBuilder.AppendFormat(format,
                        collection.AllKeys[i],
                        collection[i]);
            }

            return resultBuilder.ToString(0, resultBuilder.Length - 1);
        }

        /// <summary>
        /// Builds a query string from a <see cref="NameValueCollection"/> and appends it to the <paramref name="baseUrl"/>.
        /// </summary>
        /// <param name="collection">The <see cref="NameValueCollection"/> object to build the query string from.</param>
        /// <param name="baseUrl">The base URL to append the query string to.</param>
        /// <param name="useUrlEncoding">If <value>true</value>, encodes the keys and values from the <paramref name="collection"/>.</param>
        /// <returns>The <paramref name="collection"/> as a query string.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="baseUrl"/> is <value>null</value>.</exception>
        public static string ToQueryString(this NameValueCollection collection, string baseUrl, bool useUrlEncoding)
        {
            if (baseUrl == null)
                throw new ArgumentNullException("baseUrl");

            return string.Format("{0}?{1}", baseUrl.TrimEnd('\\', '/'), ToQueryString(collection, useUrlEncoding));
        }
    }
}
