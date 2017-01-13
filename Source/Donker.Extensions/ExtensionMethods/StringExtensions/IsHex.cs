using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Checks if the string is a valid hexadecimal value, i.e.: 0x1aF.
        /// </summary>
        /// <param name="text">The text to check.</param>
        /// <returns><c>true</c> if hex; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">The text is null.</exception>
        public static bool IsHex(this string text)
        {
            if (text == null)
                throw new ArgumentNullException("text", "The text cannot be null.");

            int textLength = text.Length;

            if (textLength == 0)
                return false;

            if (!text.StartsWith("0x"))
                return false;

            for (int i = 2; i < textLength; ++i)
            {
                char character = text[i];

                if ((character >= '0' && character <= '9')
                    || (character >= 'a' && character <= 'f')
                    || (character >= 'A' && character <= 'F'))
                    continue;

                return false;
            }

            return true;
        }
    }
}