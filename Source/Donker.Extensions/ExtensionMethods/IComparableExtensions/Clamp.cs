using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class IComparableExtensions
    {
        /// <summary>
        /// Restricts a value to be withing a specified range.
        /// </summary>
        /// <typeparam name="T">The type of the value to restrict.</typeparam>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">If <paramref name="value"/> is less than this, <paramref name="min"/> will be returned.</param>
        /// <param name="max">If <paramref name="value"/> is more than this, <paramref name="max"/> will be returned.</param>
        /// <returns><paramref name="min"/> if the <paramref name="value"/> is less than <paramref name="min"/>, <paramref name="max"/> if it is more than <paramref name="max"/>, or the <paramref name="value"/> itself if it is withing the specified range.</returns>
        /// <exception cref="ArgumentException"><paramref name="min"/> is greater than <paramref name="max"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <value>null</value>.</exception>
        public static T Clamp<T>(this T value, T min, T max)
            where T : IComparable<T>
        {
            if (Equals(value, null))
                throw new ArgumentNullException("value", "The value cannot be null.");
            if (min.CompareTo(max) > 0)
                throw new ArgumentException("The minimum value cannot be greater than the maximum value.", "min");
            
            if (value.CompareTo(min) < 0) return min;
            if (value.CompareTo(max) > 0) return max;
            return value;
        }

        /// <summary>
        /// Restricts a value to be withing a specified range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">If <paramref name="value"/> is less than this, <paramref name="min"/> will be returned.</param>
        /// <param name="max">If <paramref name="value"/> is more than this, <paramref name="max"/> will be returned.</param>
        /// <returns><paramref name="min"/> if the <paramref name="value"/> is less than <paramref name="min"/>, <paramref name="max"/> if it is more than <paramref name="max"/>, or the <paramref name="value"/> itself if it is withing the specified range.</returns>
        /// <exception cref="ArgumentException"><paramref name="min"/> is greater than <paramref name="max"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <value>null</value>.</exception>
        public static IComparable Clamp(this IComparable value, IComparable min, IComparable max)
        {
            if (Equals(value, null))
                throw new ArgumentNullException("value", "The value cannot be null.");
            if (min.CompareTo(max) > 0)
                throw new ArgumentException("The minimum value cannot be greater than the maximum value.", "min");
            
            if (value.CompareTo(min) < 0) return min;
            if (value.CompareTo(max) > 0) return max;
            return value;
        }
    }
}
