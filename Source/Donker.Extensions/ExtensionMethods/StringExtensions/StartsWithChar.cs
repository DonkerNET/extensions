namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Checks if the <see cref="string"/> starts with the specified character.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to check.</param>
        /// <param name="value">The character the <paramref name="text"/> should start with.</param>
        /// <returns><value>true</value> if <paramref name="text"/> starts with <paramref name="value"/>; otherwise, <value>false</value>.</returns>
        public static bool StartsWithChar(this string text, char value)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            return text[0] == value;
        }

        /// <summary>
        /// Checks if the first character in the <see cref="string"/> falls withing a certain range.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to check.</param>
        /// <param name="rangeMin">The lowest character the <paramref name="text"/> may start with.</param>
        /// <param name="rangeMax">The highest character the <paramref name="text"/> may start with.</param>
        /// <returns><value>true</value> if the first char of <paramref name="text"/> falls withing the specified range; otherwise, <value>false</value>.</returns>
        public static bool StartsWithCharInRange(this string text, char rangeMin, char rangeMax)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            char first = text[0];

            return first >= rangeMin && first <= rangeMax;
        }
    }
}
