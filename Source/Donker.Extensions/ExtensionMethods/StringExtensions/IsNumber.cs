using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Checks if the string is a valid number value, i.e.: 123.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <returns><c>true</c> if number; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">The text is null.</exception>
        public static bool IsNumber(this string text)
        {
            if (text == null)
                throw new ArgumentNullException("text", "The text cannot be null.");

            int textLength = text.Length;

            if (textLength == 0)
                return false;

            for (int i = 0; i < textLength; ++i)
            {
                char character = text[i];
                if (character < '0' || character > '9')
                    return false;
            }

            return true;
        }
    }
}