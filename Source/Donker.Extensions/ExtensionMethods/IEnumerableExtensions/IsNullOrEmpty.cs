using System.Collections.Generic;
using System.Linq;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        /// Checks if a collection is null or does not contain any items.
        /// </summary>
        /// <typeparam name="T">The type of the items in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <returns><c>true</c> if null or empty; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                return true;
            
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return true;
            }

            return false;
        }
    }
}
