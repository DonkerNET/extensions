using System;
using System.Text;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Replaces sequences of all types of whitespace in the <see cref="string"/> with a single space character.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to normalize.</param>
        /// <returns>The <paramref name="text"/> as a new <see cref="string"/> where the whitespace sequences have been reduced to a single space character.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is <value>null</value>.</exception>
        public static string NormalizeWhiteSpace(this string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (text.Length == 0)
                return text;

            StringBuilder resultBuilder = new StringBuilder();

            bool prevWasWs = false;

            foreach (char c in text)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!prevWasWs)
                    {
                        resultBuilder.Append(' ');
                        prevWasWs = true;
                    }
                }
                else
                {
                    resultBuilder.Append(c);
                    prevWasWs = false;
                }
            }

            return resultBuilder.ToString();
        }
    }
}
