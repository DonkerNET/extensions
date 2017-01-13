namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Checks if the <see cref="string"/> ends with the specified character.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to check.</param>
        /// <param name="value">The character the <paramref name="text"/> should end with.</param>
        /// <returns><value>true</value> if <paramref name="text"/> ends with <paramref name="value"/>; otherwise, <value>false</value>.</returns>
        public static bool EndsWithChar(this string text, char value)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            return text[text.Length - 1] == value;
        }

        /// <summary>
        /// Checks if the last character in the <see cref="string"/> falls withing a certain range.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to check.</param>
        /// <param name="min">The lowest character the <paramref name="text"/> may end with.</param>
        /// <param name="max">The highest character the <paramref name="text"/> may end with.</param>
        /// <returns><value>true</value> if the last char of <paramref name="text"/> falls withing the specified range; otherwise, <value>false</value>.</returns>
        public static bool EndsWithChar(this string text, char min, char max)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            char lastChar = text[text.Length - 1];

            return lastChar >= min && lastChar <= max;
        }
    }
}
