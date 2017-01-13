using System;
using System.Text;

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
        public static string RemoveAllWhiteSpace(this string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (text.Length == 0)
                return text;

            StringBuilder resultBuilder = new StringBuilder();

            foreach (char c in text)
                if (!char.IsWhiteSpace(c))
                    resultBuilder.Append(c);

            return resultBuilder.ToString();
        }
    }
}
