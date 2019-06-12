using System;
using System.Linq;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Removes zero-width space characters from a string, if present.
        /// </summary>
        /// <param name="text">The string to remove the zero-width space characters from.</param>
        /// <returns>The string without with the zero-width space characters removed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is <value>null</value>.</exception>
        public static string RemoveZwsp(this string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (text.Length == 0)
                return text;

            char[] chars = text
                .Where(c =>
                {
                    switch (c)
                    {
                        case '\u180e': // MONGOLIAN VOWEL SEPARATOR
                        case '\u200b': // ZERO WIDTH SPACE
                        case '\ufeff': // ZERO WIDTH NO-BREAK SPACE
                            return false;
                    }

                    return true;
                })
                .ToArray();

            return new string(chars);
        }
    }
}
