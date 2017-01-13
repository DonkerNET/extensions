using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Executes an action for each item in the collection.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="source">The collection containing the items to execute the action for.</param>
        /// <param name="action">The action to execute for each item.</param>
        /// <exception cref="ArgumentNullException"><see cref="source"/> or <see cref="action"/> is null.</exception>
        public static void Action<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
                throw new ArgumentNullException("source", "The source cannot be null.");
            if (action == null)
                throw new ArgumentNullException("action", "The action cannot be null.");

            foreach (T item in source)
            {
                action.Invoke(item);
            }
        }
    }
}
