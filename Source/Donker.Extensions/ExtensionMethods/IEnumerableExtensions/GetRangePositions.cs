using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Returns the indexes of items withing the collection that match a predicate.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="predicate">The predicate to use.</param>
        /// <returns>A collection of keyvalue pairs where the key is the index and value the number of items untill the next index or the end of the collection.</returns>
        public static IEnumerable<KeyValuePair<int, int>> GetRangePositions<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                int currentIndex = 0;

                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                    {
                        int count = 1;

                        while (enumerator.MoveNext() && predicate(enumerator.Current))
                            count++;

                        yield return new KeyValuePair<int, int>(currentIndex, count);
                        currentIndex += count;
                    }
                    currentIndex++;
                }
            }
        }
    }
}
