using System;
using System.Linq;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Removes all whitespace from the <see cref="string"/>.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to remove the whitespace from.</param>
        /// <returns>The <paramref name="text"/> as a new <see cref="string"/> where the whitespace has been removed.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is <value>null</value>.</exception>
        public static string RemoveWhiteSpace(this string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (text.Length == 0)
                return text;
            
            char[] chars = text
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray();

            return new string(chars);
        }
    }
}
