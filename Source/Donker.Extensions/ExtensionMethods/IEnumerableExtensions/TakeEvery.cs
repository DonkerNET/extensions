using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Counts and returns items that are selected each time the counter hits the specified amount.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="source">The collection to take the items from.</param>
        /// <param name="count">The amount that the counter should match in order to return an item.</param>
        /// <returns>The items as an <see cref="IEnumerable{T}"/> collection.</returns>
        public static IEnumerable<T> TakeEvery<T>(this IEnumerable<T> source, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source", "The source cannot be null.");
            if (count < 0)
                throw new ArgumentException("The count cannot be negative.", "count");

            if (count == 0)
                yield break;

            int counter = 1;

            foreach (T item in source)
            {
                if (counter == count)
                {
                    yield return item;
                    counter = 1;
                }
                else
                {
                    ++counter;
                }
            }
        }
    }
}
