using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IDictionaryExtensions
    {
        /// <summary>
        /// Retrieves a value from the dictionary if it exists; otherwise it returns a default value.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to get the value from.</param>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <param name="defaultValue">The default value to return when an existing one was not found.</param>
        /// <exception cref="ArgumentNullException">The dictionary is null.</exception>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary", "The dictionary cannot be null.");

            TValue value;
            if (dictionary.TryGetValue(key, out value))
                return value;
            return defaultValue;
        }

        /// <summary>
        /// Retrieves a value from the dictionary if it exists; otherwise it returns a default value.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to get the value from.</param>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <exception cref="ArgumentNullException">The dictionary is null.</exception>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return GetOrDefault(dictionary, key, default(TValue));
        }
    }
}
