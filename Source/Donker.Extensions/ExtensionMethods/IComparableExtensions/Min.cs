using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IComparableExtensions
    {
        /// <summary>
        /// Restricts a value from being lower than the minimum value.
        /// </summary>
        /// <typeparam name="T">The type of the value to restrict.</typeparam>
        /// <param name="value">The value to restrict.</param>
        /// <param name="min">If <paramref name="value"/> is less than this, <paramref name="min"/> will be returned.</param>
        /// <returns><paramref name="min"/> if the <paramref name="value"/> is less than <paramref name="min"/>, otherwise the <paramref name="value"/> itself.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <value>null</value>.</exception>
        public static T Min<T>(this T value, T min)
            where T : IComparable<T>
        {
            if (Equals(value, null))
                throw new ArgumentNullException("value", "The value cannot be null.");

            if (value.CompareTo(min) < 0) return min;
            return value;
        }

        /// <summary>
        /// Restricts a value from being lower than the minimum value.
        /// </summary>
        /// <param name="value">The value to restrict.</param>
        /// <param name="min">If <paramref name="value"/> is less than this, <paramref name="min"/> will be returned.</param>
        /// <returns><paramref name="min"/> if the <paramref name="value"/> is less than <paramref name="min"/>, otherwise the <paramref name="value"/> itself.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <value>null</value>.</exception>
        public static IComparable Min(this IComparable value, IComparable min)
        {
            if (Equals(value, null))
                throw new ArgumentNullException("value", "The value cannot be null.");

            if (value.CompareTo(min) < 0) return min;
            return value;
        }
    }
}
