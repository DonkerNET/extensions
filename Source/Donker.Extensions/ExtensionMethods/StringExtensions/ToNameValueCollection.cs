using System;
using System.Collections.Specialized;
using System.Linq;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Creates a <see cref="NameValueCollection"/> from the <see cref="string"/>.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to create the <see cref="NameValueCollection"/> for.</param>
        /// <param name="itemDelimiters">Used to split the <paramref name="text"/> into separate items.</param>
        /// <param name="keyValueDelimiters">Used to split the items created by the <paramref name="itemDelimiters"/> into a key and value.</param>
        /// <param name="allowDuplicates">If <value>true</value>, allows multiple items with the same key into the <see cref="NameValueCollection"/>; otherwise, only adds the first of the duplicate items.</param>
        /// <param name="trimWhiteSpace">If <value>true</value>, removes leading and trailing whitespace from both the key and value.</param>
        /// <returns>The <see cref="System.Collections.Generic.KeyValuePair{T,T}"/> created from the <paramref name="text"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/>, <paramref name="itemDelimiters"/> or <paramref name="keyValueDelimiters"/> is <value>null</value>.</exception>
        public static NameValueCollection ToNameValueCollection(this string text, string[] itemDelimiters, string[] keyValueDelimiters, bool allowDuplicates, bool trimWhiteSpace)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (itemDelimiters == null)
                throw new ArgumentNullException("itemDelimiters");

            if (keyValueDelimiters == null)
                throw new ArgumentNullException("keyValueDelimiters");

            NameValueCollection result = new NameValueCollection();

            if (text.Length == 0)
                return result;

            string[] items = text.Split(itemDelimiters, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in items)
            {
                string[] keyValue = item.Split(keyValueDelimiters, 2, StringSplitOptions.None);
                
                if (keyValue.Length == 0)
                    continue;

                string key = keyValue[0];

                if (string.IsNullOrEmpty(key)
                    || (trimWhiteSpace && key.Any(char.IsWhiteSpace)))
                    continue;

                string value = keyValue.Length > 1 ? keyValue[1] : string.Empty;

                if (!allowDuplicates && result.AllKeys.Contains(key))
                    continue;

                if (trimWhiteSpace)
                    result.Add(key.Trim(), value.Trim());
                else
                    result.Add(key, value);
            }

            return result;
        }

        /// <summary>
        /// Creates a <see cref="NameValueCollection"/> from the <see cref="string"/> and trims the whitespace from both the key and value.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to create the <see cref="NameValueCollection"/> for.</param>
        /// <param name="itemDelimiters">Used to split the <paramref name="text"/> into separate items.</param>
        /// <param name="keyValueDelimiters">Used to split the items created by the <paramref name="itemDelimiters"/> into a key and value.</param>
        /// <param name="allowDuplicates">If <value>true</value>, allows multiple items with the same key into the <see cref="NameValueCollection"/>; otherwise, only adds the first of the duplicate items.</param>
        /// <returns>The <see cref="System.Collections.Generic.KeyValuePair{T,T}"/> created from the <paramref name="text"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/>, <paramref name="itemDelimiters"/> or <paramref name="keyValueDelimiters"/> is <value>null</value>.</exception>
        public static NameValueCollection ToNameValueCollection(this string text, string[] itemDelimiters, string[] keyValueDelimiters, bool allowDuplicates)
        {
            return ToNameValueCollection(text, itemDelimiters, keyValueDelimiters, allowDuplicates, true);
        }

        /// <summary>
        /// Creates a <see cref="NameValueCollection"/> from the <see cref="string"/>, allowing duplicate keys and trimming whitespace from both the key and value.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to create the <see cref="NameValueCollection"/> for.</param>
        /// <param name="itemDelimiters">Used to split the <paramref name="text"/> into separate items.</param>
        /// <param name="keyValueDelimiters">Used to split the items created by the <paramref name="itemDelimiters"/> into a key and value.</param>
        /// <returns>The <see cref="System.Collections.Generic.KeyValuePair{T,T}"/> created from the <paramref name="text"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/>, <paramref name="itemDelimiters"/> or <paramref name="keyValueDelimiters"/> is <value>null</value>.</exception>
        public static NameValueCollection ToNameValueCollection(this string text, string[] itemDelimiters, string[] keyValueDelimiters)
        {
            return ToNameValueCollection(text, itemDelimiters, keyValueDelimiters, true, true);
        }
    }
}
