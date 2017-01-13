using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Splits the collection into batches of the specified size.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="source">The collection to split.</param>
        /// <param name="batchSize">The maximum number of items in a batch.</param>
        /// <returns>A collection of batches.</returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int batchSize)
        {
            if (source == null)
                throw new ArgumentNullException("source", "The source cannot be null.");
            if (batchSize < 0)
                throw new ArgumentException("The batch size cannot be negative.", "batchSize");

            if (batchSize == 0)
                yield break;

            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return TakeBatch(enumerator, batchSize);
                }
            }
        }

        private static IEnumerable<T> TakeBatch<T>(IEnumerator<T> enumerator, int count)
        {
            int counter = 0;

            do
            {
                yield return enumerator.Current;
            }
            while (++counter < count && enumerator.MoveNext());
        }
    }
}
