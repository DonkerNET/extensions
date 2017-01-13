using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringExtensions
    {
        // Base method for string trimming
        public static string TrimStringBase(string text, StringComparison comparison, bool trimStart, bool trimEnd, params string[] values)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            if (values == null)
                throw new ArgumentNullException("values");

            if (!trimStart && !trimEnd)
                return text;

            int textLength = text.Length;

            if (textLength == 0 || values.Length == 0)
                return text;

            int newStartPos = 0;
            int newEndPos = textLength;

            if (trimStart)
            {
                int prevStartPos;

                do
                {
                    prevStartPos = newStartPos;

                    foreach (string value in values)
                    {
                        int index = text.IndexOf(value, newStartPos, comparison);
                        if (index == newStartPos)
                            newStartPos += value.Length;
                    }
                }
                while (newStartPos < textLength && newStartPos > prevStartPos);
            }

            if (trimEnd)
            {
                int prevEndPos;

                do
                {
                    prevEndPos = newEndPos;

                    foreach (string value in values)
                    {
                        int valueLength = value.Length;
                        int lastIndex = text.LastIndexOf(value, newEndPos, comparison);
                        if (lastIndex == newEndPos - valueLength)
                            newEndPos -= valueLength;
                    }
                }
                while (newEndPos >= 0 && newEndPos < prevEndPos);
            }

            if (newStartPos >= newEndPos)
                return string.Empty;

            return text.Substring(newStartPos, newEndPos - newStartPos);
        }

        /// <summary>
        /// Removes all leading occurrences of a set of <see cref="string"/> values specified in an array from the current <see cref="string"/> object.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to remove the values from.</param>
        /// <param name="comparison">The type of comparison to perform while searching for the values.</param>
        /// <param name="values">The <see cref="string"/> values to remove from the <paramref name="text"/>.</param>
        /// <returns>The <see cref="string"/> that remains after removing the values.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> or <paramref name="values"/> is <value>null</value>.</exception>
        public static string TrimStringStart(this string text, StringComparison comparison, params string[] values)
        {
            return TrimStringBase(text, comparison, true, false, values);
        }

        /// <summary>
        /// Removes all trailing occurrences of a set of <see cref="string"/> values specified in an array from the current <see cref="string"/> object.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to remove the values from.</param>
        /// <param name="comparison">The type of comparison to perform while searching for the values.</param>
        /// <param name="values">The <see cref="string"/> values to remove from the <paramref name="text"/>.</param>
        /// <returns>The <see cref="string"/> that remains after removing the values.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> or <paramref name="values"/> is <value>null</value>.</exception>
        public static string TrimStringEnd(this string text, StringComparison comparison, params string[] values)
        {
            return TrimStringBase(text, comparison, false, true, values);
        }

        /// <summary>
        /// Removes all leading and trailing occurrences of a set of <see cref="string"/> values specified in an array from the current <see cref="string"/> object.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to remove the values from.</param>
        /// <param name="comparison">The type of comparison to perform while searching for the values.</param>
        /// <param name="values">The <see cref="string"/> values to remove from the <paramref name="text"/>.</param>
        /// <returns>The <see cref="string"/> that remains after removing the values.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> or <paramref name="values"/> is <value>null</value>.</exception>
        public static string TrimString(this string text, StringComparison comparison, params string[] values)
        {
            return TrimStringBase(text, comparison, true, true, values);
        }
    }
}
