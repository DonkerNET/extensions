using System;
using System.Collections.Generic;
using System.Text;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Creates a single <see cref="string"/> from the items in the <paramref name="collection"/>, separated by the specified <paramref name="separator"/>, using the specified <paramref name="stringFunc"/>..
        /// </summary>
        /// <typeparam name="T">The type of the items in the <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The collection to create the <see cref="string"/> from.</param>
        /// <param name="separator">The value that will separate each item in the final <see cref="string"/>.</param>
        /// <param name="stringFunc">Method used to create a <see cref="string"/> from an item.</param>
        /// <returns>All the items in the <paramref name="collection"/> as one <see cref="string"/>, separated by the <paramref name="separator"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/>, <paramref name="separator"/> or <paramref name="stringFunc"/> is <value>null</value>.</exception>
        public static string CreateString<T>(this IEnumerable<T> collection, string separator, Func<T, string> stringFunc)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            if (separator == null)
                throw new ArgumentNullException("separator");

            if (stringFunc == null)
                throw new ArgumentNullException("stringFunc");

            StringBuilder resultBuilder = new StringBuilder();

            int separatorLength = separator.Length;

            if (separatorLength == 0)
                foreach (T item in collection)
                    resultBuilder.Append(stringFunc(item));
            else
                foreach (T item in collection)
                    resultBuilder.Append(stringFunc(item) + separator);
            
            int resultLength = resultBuilder.Length;
            
            if (resultLength == 0)
                return string.Empty;

            return resultBuilder.ToString(0, resultLength - separatorLength);
        }

        /// <summary>
        /// Creates a single <see cref="string"/> from the items in the <paramref name="collection"/>, separated by the specified <paramref name="separator"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items in the <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The collection to create the <see cref="string"/> from.</param>
        /// <param name="separator">The value that will separate each item in the final <see cref="string"/>.</param>
        /// <returns>All the items in the <paramref name="collection"/> as one <see cref="string"/>, separated by the <paramref name="separator"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="separator"/> is <value>null</value>.</exception>
        public static string CreateString<T>(this IEnumerable<T> collection, string separator)
        {
            return CreateString(collection, separator, item => item.ToString());
        }

        /// <summary>
        /// Creates a single <see cref="string"/> from the items in the <paramref name="collection"/>, using the specified <paramref name="stringFunc"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items in the <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The collection to create the <see cref="string"/> from.</param>
        /// <param name="stringFunc">Method used to create a <see cref="string"/> from an item.</param>
        /// <returns>All the items in the <paramref name="collection"/> as one <see cref="string"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="collection"/> or <paramref name="stringFunc"/> is <value>null</value>.</exception>
        public static string CreateString<T>(this IEnumerable<T> collection, Func<T, string> stringFunc)
        {
            return CreateString(collection, string.Empty, stringFunc);
        }

        /// <summary>
        /// Creates a single <see cref="string"/> from the items in the <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T">The type of the items in the <paramref name="collection"/>.</typeparam>
        /// <param name="collection">The collection to create the <see cref="string"/> from.</param>
        /// <returns>All the items in the <paramref name="collection"/> as one <see cref="string"/>.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is <value>null</value>.</exception>
        public static string CreateString<T>(this IEnumerable<T> collection)
        {
            return CreateString(collection, string.Empty, item => item.ToString());
        }
    }
}
