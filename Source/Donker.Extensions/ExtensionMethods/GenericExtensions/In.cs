using System;
using System.Collections.Generic;
using System.Linq;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class GenericExtensions
    {
        /// <summary>
        /// Determines whether the specified object equals any of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the object and values to compare.</typeparam>
        /// <param name="obj">The object to compare.</param>
        /// <param name="values">The values to compare <paramref name="obj"/> to.</param>
        /// <param name="comparer">The comparer to use.</param>
        /// <returns><value>true</value> if <paramref name="obj"/> equals any of the specified values; otherwise, <value>false</value>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <value>null</value>.</exception>
        public static bool In<T>(this T obj, IEnumerable<T> values, IEqualityComparer<T> comparer)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            if (comparer == null)
                comparer = EqualityComparer<T>.Default;

            return values.Any(item => comparer.Equals(item, obj));
        }

        /// <summary>
        /// Determines whether the specified object equals any of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the object and values to compare.</typeparam>
        /// <param name="obj">The object to compare.</param>
        /// <param name="values">The values to compare <paramref name="obj"/> to.</param>
        /// <returns><value>true</value> if <paramref name="obj"/> equals any of the specified values; otherwise, <value>false</value>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <value>null</value>.</exception>
        public static bool In<T>(this T obj, IEnumerable<T> values)
        {
            return In(obj, values, null);
        }

        /// <summary>
        /// Determines whether the specified object equals any of the specified values.
        /// </summary>
        /// <typeparam name="T">The type of the object and values to compare.</typeparam>
        /// <param name="obj">The object to compare.</param>
        /// <param name="values">The values to compare <paramref name="obj"/> to.</param>
        /// <returns><value>true</value> if <paramref name="obj"/> equals any of the specified values; otherwise, <value>false</value>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <value>null</value>.</exception>
        public static bool In<T>(this T obj, params T[] values)
        {
            return In(obj, (IEnumerable<T>)values);
        }
    }
}
