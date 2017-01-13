using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IListExtensions
    {
        /// <summary>
        /// Moves an item in the list from the old index to the new.
        /// </summary>
        /// <typeparam name="T">The type of the items in the list.</typeparam>
        /// <param name="list">The list containing the item to move.</param>
        /// <param name="oldIndex">The item's old index.</param>
        /// <param name="newIndex">The index where the item should be moved to.</param>
        /// <exception cref="ArgumentNullException">The list is null.</exception>
        /// <exception cref="ArgumentException">The old or new index is negative.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The old or new index is out of the list's range.</exception>
        public static void MoveItem<T>(this IList<T> list, int oldIndex, int newIndex)
        {
            if (list == null)
                throw new ArgumentNullException("list", "The list cannot be null.");
            if (oldIndex < 0)
                throw new ArgumentException("The old index cannot be negative.", "oldIndex");
            if (newIndex < 0)
                throw new ArgumentException("The new index cannot be negative.", "newIndex");

            int listSize = list.Count;

            if (oldIndex >= listSize)
                throw new ArgumentOutOfRangeException("oldIndex", "The old index is out of the list's range.");
            if (newIndex > listSize)
                throw new ArgumentOutOfRangeException("newIndex", "The new index cannot be higher than the number of items in the list.");

            if (oldIndex == newIndex)
                return;

            T item = list[oldIndex];
            list.RemoveAt(oldIndex);
            list.Insert(newIndex, item);
        }
    }
}
