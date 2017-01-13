using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IListExtensions
    {
        /// <summary>
        /// Switches the positions of two items in the list.
        /// </summary>
        /// <typeparam name="T">The type of the items in the list.</typeparam>
        /// <param name="list">The list containing the items to switch.</param>
        /// <param name="firstIndex">The index of the first item.</param>
        /// <param name="secondIndex">The index of the second item.</param>
        /// <exception cref="ArgumentNullException">The list is null.</exception>
        /// <exception cref="ArgumentException">The first or second index is negative.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The first or second index is out of the list's range.</exception>
        public static void SwitchItem<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            if (list == null)
                throw new ArgumentNullException("list", "The list cannot be null.");
            if (firstIndex < 0)
                throw new ArgumentException("The first index cannot be negative.", "firstIndex");
            if (secondIndex < 0)
                throw new ArgumentException("The second index cannot be negative.", "secondIndex");

            int listSize = list.Count;

            if (firstIndex >= listSize)
                throw new ArgumentOutOfRangeException("firstIndex", "The first index is out of the list's range.");
            if (secondIndex >= listSize)
                throw new ArgumentOutOfRangeException("secondIndex", "The second index is out of the list's range.");

            if (firstIndex == secondIndex)
                return;

            T firstItem = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = firstItem;
        }
    }
}
