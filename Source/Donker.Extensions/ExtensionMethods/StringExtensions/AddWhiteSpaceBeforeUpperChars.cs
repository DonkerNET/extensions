using System;
using System.Text;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Inserts a single space character before each uppercase character that occurs in the string.
        /// </summary>
        /// <param name="value">The string to insert the space characters for.</param>
        /// <returns>The value with inserted space characters as a <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">The value is null.</exception>
        public static string AddWhiteSpaceBeforeUpperChars(this string value)
        {
            if (value == null)
                throw new ArgumentNullException("value", "The value cannot be null.");

            if (value.Length == 0)
                return value;

            StringBuilder stringBuilder = new StringBuilder();

            bool canAddWhiteSpace = false;

            foreach (char c in value)
            {
                if (char.IsUpper(c))
                {
                    if (canAddWhiteSpace)
                        stringBuilder.Append(' ');
                    else
                        canAddWhiteSpace = true;
                }
                else
                {
                    canAddWhiteSpace = !char.IsWhiteSpace(c);
                }

                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
    }
}