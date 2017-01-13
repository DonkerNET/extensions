using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Splits the collection in batches on each item that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="source">The collection to split.</param>
        /// <param name="predicate">The predicate the item to split on should match.</param>
        /// <param name="removeItemMatch">Whether items that match should be removed from the resulting collection.</param>
        /// <param name="alterItemFunc">A function to execute for each item in order to transform it.</param>
        /// <returns>A collection of batches.</returns>
        public static IEnumerable<ICollection<T>> SplitOn<T>(this IEnumerable<T> source, Predicate<T> predicate, bool removeItemMatch, Func<T, T> alterItemFunc)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            IEnumerator<T> enumerator = source.GetEnumerator();

            bool endReached;

            do
            {
                ICollection<T> batch = TakeBatchOn(enumerator, predicate, removeItemMatch, alterItemFunc, out endReached);
                if (batch != null && batch.Count > 0)
                    yield return batch;
            }
            while (!endReached);
        }

        private static ICollection<T> TakeBatchOn<T>(IEnumerator<T> enumerator, Predicate<T> predicate, bool removeItemMatch, Func<T, T> alterItemFunc, out bool endReached)
        {
            ICollection<T> collection = null;

            if (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current))
                {
                    endReached = false;

                    if (removeItemMatch)
                        return null;

                    collection = new List<T> { alterItemFunc != null ? alterItemFunc(enumerator.Current) : enumerator.Current };
                    return collection;
                }

                collection = new List<T> { enumerator.Current };

                while (enumerator.MoveNext())
                {
                    T current = enumerator.Current;

                    if (predicate(current))
                    {
                        if (!removeItemMatch)
                        {
                            collection.Add(alterItemFunc != null ? alterItemFunc(enumerator.Current) : enumerator.Current);
                        }

                        endReached = false;
                        return collection;
                    }

                    collection.Add(current);
                }
            }

            endReached = true;
            return collection;
        }
    }
}
