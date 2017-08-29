using System.Text;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Removes all non-alphanumeric characters, converts the starting characters of each word to uppercase and converts the rest of the characters to lowercase.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to convert.</param>
        /// <returns>The <paramref name="text"/> converted to a new PascalCase <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is <value>null</value>.</exception>
        public static string ToPascalCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            StringBuilder resultBuilder = new StringBuilder();

            bool prevWasLd = false;

            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    resultBuilder.Append(prevWasLd ? char.ToLowerInvariant(c) : char.ToUpperInvariant(c));
                    prevWasLd = true;
                }
                else
                {
                    prevWasLd = false;
                }
            }

            return resultBuilder.ToString();
        }
    }
}
