using System;
using System.Linq;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Indicates whether the string consists only of white-space characters.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to test.</param>
        /// <returns><value>true</value> if <paramref name="text"/> consists exclusively of white-space characters.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> cannot be null.</exception>
        public static bool IsWhiteSpace(this string text)
        {
            if (text == null)
                throw new ArgumentNullException("text", "The text cannot be null.");

            return text.All(char.IsWhiteSpace);
        }
    }
}
