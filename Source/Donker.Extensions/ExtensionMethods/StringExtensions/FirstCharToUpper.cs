using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Converts the first character of the <see cref="string"/> to upper-case.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to convert the first character for.</param>
        /// <returns>The <paramref name="text"/> as a new <see cref="string"/> where the first character has been converted to upper-case.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is <value>null</value>.</exception>
        public static string FirstCharToUpper(this string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (text.Length == 0)
                return text;

            char firstChar = text[0];

            if (char.IsWhiteSpace(firstChar) || char.IsUpper(firstChar))
                return text;

            return char.ToUpper(firstChar) + text.Substring(1);
        }
    }
}
