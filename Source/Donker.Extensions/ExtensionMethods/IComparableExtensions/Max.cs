using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IComparableExtensions
    {
        /// <summary>
        /// Restricts a value from being higher than the maximum value.
        /// </summary>
        /// <typeparam name="T">The type of the value to restrict.</typeparam>
        /// <param name="value">The value to restrict.</param>
        /// <param name="max">If <paramref name="value"/> is higher than this, <paramref name="max"/> will be returned.</param>
        /// <returns><paramref name="max"/> if the <paramref name="value"/> is higher than <paramref name="max"/>, otherwise the <paramref name="value"/> itself.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <value>null</value>.</exception>
        public static T Max<T>(this T value, T max)
            where T : IComparable<T>
        {
            if (Equals(value, null))
                throw new ArgumentNullException("value", "The value cannot be null.");

            if (value.CompareTo(max) > 0) return max;
            return value;
        }

        /// <summary>
        /// Restricts a value from being higher than the maximum value.
        /// </summary>
        /// <param name="value">The value to restrict.</param>
        /// <param name="max">If <paramref name="value"/> is higher than this, <paramref name="max"/> will be returned.</param>
        /// <returns><paramref name="max"/> if the <paramref name="value"/> is higher than <paramref name="max"/>, otherwise the <paramref name="value"/> itself.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <value>null</value>.</exception>
        public static IComparable Max(this IComparable value, IComparable max)
        {
            if (Equals(value, null))
                throw new ArgumentNullException("value", "The value cannot be null.");

            if (value.CompareTo(max) > 0) return max;
            return value;
        }
    }
}
