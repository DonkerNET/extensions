using System;
using System.Collections.Generic;
using System.Linq;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IEnumerableKeyValuePairExtensions
    {
        /// <summary>
        /// Creates a dictionary from the <see cref="IEnumerable{KeyValuePair}"/> collection using the specified equality comparer.
        /// </summary>
        /// <typeparam name="TKey">The type of the dictionary's keys.</typeparam>
        /// <typeparam name="TValue">The type of the dictionary's values.</typeparam>
        /// <param name="source">The source collection to convert.</param>
        /// <param name="comparer">The key comparer the dictionary should use.</param>
        /// <returns>The keys and values in a new <see cref="Dictionary{TKey,TValue}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source", "The source cannot be null.");

            return source.ToDictionary(item => item.Key, item => item.Value, comparer);
        }

        /// <summary>
        /// Creates a dictionary from the <see cref="IEnumerable{KeyValuePair}"/> collection using the default equality comparer.
        /// </summary>
        /// <typeparam name="TKey">The type of the dictionary's keys.</typeparam>
        /// <typeparam name="TValue">The type of the dictionary's values.</typeparam>
        /// <param name="source">The source collection to convert.</param>
        /// <returns>The keys and values in a new <see cref="Dictionary{TKey,TValue}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            return ToDictionary(source, EqualityComparer<TKey>.Default);
        }
    }
}
