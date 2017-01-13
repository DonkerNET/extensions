using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IDictionaryExtensions
    {
        /// <summary>
        /// Adds a range of key-values to the dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to add the range to.</param>
        /// <param name="range">The range to add.</param>
        /// <exception cref="ArgumentNullException">The dictionary is null.</exception>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> range)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary", "The dictionary cannot be null.");
            
            if (range == null)
                return;

            foreach (KeyValuePair<TKey, TValue> keyValuePair in range)
                dictionary.Add(keyValuePair);
        }
    }
}
