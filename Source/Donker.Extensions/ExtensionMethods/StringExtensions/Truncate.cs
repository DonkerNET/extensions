using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Shortens a string when it is longer than the specified maximum length, starting from the specified start index.
        /// </summary>
        /// <param name="text">The text to truncate.</param>
        /// <param name="startIndex">The index of the text where to start truncating.</param>
        /// <param name="maxLength">The maximum length the text can have.</param>
        /// <returns>The truncated text as a <see cref="string"/>.</returns>
        public static string Truncate(this string text, int startIndex, int maxLength)
        {
            if (text == null)
                throw new ArgumentNullException("text", "The text cannot be null.");

            int textLength = text.Length;

            if (startIndex < 0)
                throw new ArgumentException("The start index must be a positive value.");

            if (maxLength < 0)
                throw new ArgumentException("The max length must be a positive value.", "maxLength");

            if (startIndex > textLength)
                throw new ArgumentOutOfRangeException("startIndex", "The start index exceeds the length of the text.");

            if (startIndex == textLength)
                return text;

            int newLength = textLength - startIndex;

            return text.Substring(startIndex, newLength < maxLength ? newLength : maxLength);
        }

        /// <summary>
        /// Shortens a string when it is longer than the specified maximum length.
        /// </summary>
        /// <param name="text">The text to truncate.</param>
        /// <param name="maxLength">The maximum length the text can have.</param>
        /// <returns>The truncated text as a <see cref="string"/>.</returns>
        public static string Truncate(this string text, int maxLength)
        {
            return Truncate(text, 0, maxLength);
        }
    }
}