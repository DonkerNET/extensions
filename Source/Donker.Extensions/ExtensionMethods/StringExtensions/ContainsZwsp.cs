using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Checks if the string contains zero-width space characters.
        /// </summary>
        /// <param name="text">The string to check for zero-width space characters.</param>
        /// <returns><value>true</value> if the string contains one or more zero-width space characters; otherwise, <value>false</value>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is <value>null</value>.</exception>
        public static bool ContainsZwsp(this string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (text.Length == 0)
                return false;

            foreach (char c in text)
            {
                switch (c)
                {
                    case '\u180e': // MONGOLIAN VOWEL SEPARATOR
                    case '\u200b': // ZERO WIDTH SPACE
                    case '\ufeff': // ZERO WIDTH NO-BREAK SPACE
                        return true;
                }
            }

            return false;
        }
    }
}
