using System;
using System.Collections.Generic;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Finds all occurences of the specified <paramref name="value"/> in the <paramref name="text"/>.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to find the occurences in.</param>
        /// <param name="value">The value to find the occurences for.</param>
        /// <param name="comparison">The type of comparison to perform while searching for indexes.</param>
        /// <returns>All occurences of the specified <paramref name="value"/> as an <see cref="int"/> collection.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> or <paramref name="value"/> is <value>null</value>.</exception>
        public static IEnumerable<int> IndicesOf(this string text, string value, StringComparison comparison)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (value == null)
                throw new ArgumentNullException("value");

            int prevStartPos;
            int newStartPos = 0;
            int textLength = text.Length;
            int valueLength = value.Length;

            do
            {
                prevStartPos = newStartPos;

                int foundIndex = text.IndexOf(value, newStartPos, comparison);
                if (foundIndex >= 0)
                {
                    yield return foundIndex;
                    newStartPos += valueLength;
                }
            }
            while (newStartPos < textLength && newStartPos > prevStartPos);
        }

        /// <summary>
        /// Finds all occurences of the specified <paramref name="value"/> in the <paramref name="text"/> using current culture comparison.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to find the occurences in.</param>
        /// <param name="value">The value to find the occurences for.</param>
        /// <returns>All occurences of the specified <paramref name="value"/> as an <see cref="int"/> collection.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> or <paramref name="value"/> is <value>null</value>.</exception>
        public static IEnumerable<int> IndicesOf(this string text, string value)
        {
            return IndicesOf(text, value, StringComparison.CurrentCulture);
        }
    }
}
