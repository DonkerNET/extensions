using System;
using System.Text;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string, using the specified form of comparison.
        /// </summary>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of <paramref name="oldValue"/> are replaced with <paramref name="newValue"/>.
        /// </returns>
        /// <param name="text">The string to replace the values in.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all occurrences of <paramref name="oldValue"/>.</param>
        /// <param name="comparisonType">The type of comparison to use when checking if a value should be replaced.</param>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> or <paramref name="oldValue"/> is null. </exception>
        /// <exception cref="ArgumentException"><paramref name="text"/> or <paramref name="oldValue"/> is empty. </exception>
        public static string ReplaceByComparison(this string text, string oldValue, string newValue, StringComparison comparisonType)
        {
            if (text == null)
                throw new ArgumentNullException("text", "The text cannot be null.");
            if (text.Length == 0)
                throw new ArgumentException("The text cannot be empty.", "text");
            if (oldValue == null)
                throw new ArgumentNullException("oldValue", "The old value cannot be null.");

            int oldValueLength = oldValue.Length;

            if (oldValueLength == 0)
                throw new ArgumentException("The old value cannot be empty.", "oldValue");

            int oldValueIndex = text.IndexOf(oldValue, comparisonType);

            if (oldValueIndex < 0)
                return text;

            StringBuilder stringBuilder = new StringBuilder();
            int currentPos = 0;

            do
            {
                stringBuilder.Append(text.Substring(currentPos, oldValueIndex));
                stringBuilder.Append(newValue);

                currentPos = oldValueIndex + oldValueLength;
                oldValueIndex = text.IndexOf(oldValue, currentPos, comparisonType);
            }
            while (oldValueIndex >= 0);

            if (currentPos < text.Length)
                stringBuilder.Append(text.Substring(currentPos));

            return stringBuilder.ToString();
        }
    }
}