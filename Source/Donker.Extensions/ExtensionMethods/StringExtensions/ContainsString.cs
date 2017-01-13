using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Checks if a value is present in the string by using the specified string comparison.
        /// </summary>
        /// <param name="text">The string to find the value in.</param>
        /// <param name="value">The value to find in the string.</param>
        /// <param name="comparisonType">The type of comparison to use when searching for the value.</param>
        /// <returns><value>true</value> if the value is present in the string; otherwise, <value>false</value>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> or <paramref name="value"/> is <value>null</value>.</exception>
        public static bool ContainsString(this string text, string value, StringComparison comparisonType)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (value == null)
                throw new ArgumentNullException("value");

            return text.IndexOf(value, comparisonType) >= 0;
        }

        /// <summary>
        /// Checks if a value is present in the string by using current culture comparison.
        /// </summary>
        /// <param name="text">The string to find the value in.</param>
        /// <param name="value">The value to find in the string.</param>
        /// <returns><value>true</value> if the value is present in the string; otherwise, <value>false</value>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> or <paramref name="value"/> is <value>null</value>.</exception>
        public static bool ContainsString(this string text, string value)
        {
            return ContainsString(text, value, StringComparison.CurrentCulture);
        }
    }
}
