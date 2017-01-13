using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IDictionaryExtensions
    {
        /// <summary>
        /// Retrieves a value from the dictionary if it exists; otherwise it creates and adds a new one.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to get the value from.</param>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <param name="constructor">The method to call when a new value should be created if an existing one was not found.</param>
        /// <exception cref="ArgumentNullException">The dictionary or constructor is null.</exception>
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> constructor)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary", "The dictionary cannot be null.");
            if (constructor == null)
                throw new ArgumentNullException("constructor", "The constructor cannot be null.");

            TValue value;
            if (dictionary.TryGetValue(key, out value))
                return value;

            value = constructor.Invoke();
            dictionary.Add(key, value);
            return value;
        }

        /// <summary>
        /// Retrieves a value from the dictionary if it exists; otherwise it creates and adds a new one.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to get the value from.</param>
        /// <param name="key">The key of the value to retrieve.</param>
        /// <exception cref="ArgumentNullException">The dictionary or constructor is null.</exception>
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
            where TValue : new()
        {
            return GetOrCreate(dictionary, key, () => new TValue());
        }
    }
}