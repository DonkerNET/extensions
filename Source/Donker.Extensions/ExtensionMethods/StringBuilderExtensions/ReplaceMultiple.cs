using System;
using System.Text;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Replaces multiple string values within the string builder with a single new string value, for the specified character range.
        /// </summary>
        /// <param name="stringBuilder">The string builder to replace the values in.</param>
        /// <param name="newValue">The new value to replace the old values with.</param>
        /// <param name="startIndex">Where the replacing should start.</param>
        /// <param name="count">The number of characters to include in the replace search, starting from the specified start index.</param>
        /// <param name="oldValues">The old values to replace.</param>
        /// <exception cref="ArgumentNullException">The string builder is null.</exception>
        public static void ReplaceMultiple(this StringBuilder stringBuilder, string newValue, int startIndex, int count, params string[] oldValues)
        {
            if (stringBuilder == null)
                throw new ArgumentNullException("stringBuilder", "The StringBuilder cannot be null.");

            if (oldValues == null || oldValues.Length == 0)
                return;

            foreach (string oldValue in oldValues)
                stringBuilder.Replace(oldValue, newValue, startIndex, count);
        }

        /// <summary>
        /// Replaces multiple string values within the string builder with a single new string value.
        /// </summary>
        /// <param name="stringBuilder">The string builder to replace the values in.</param>
        /// <param name="newValue">The new value to replace the old values with.</param>
        /// <param name="oldValues">The old values to replace.</param>
        /// <exception cref="ArgumentNullException">The string builder is null.</exception>
        public static void ReplaceMultiple(this StringBuilder stringBuilder, string newValue, params string[] oldValues)
        {
            ReplaceMultiple(stringBuilder, newValue, 0, stringBuilder.Length, oldValues);
        }

        /// <summary>
        /// Replaces multiple characters within the string builder with a single new character value, for the specified character range.
        /// </summary>
        /// <param name="stringBuilder">The string builder to replace the values in.</param>
        /// <param name="newValue">The new value to replace the old values with.</param>
        /// <param name="startIndex">Where the replacing should start.</param>
        /// <param name="count">The number of characters to include in the replace search, starting from the specified start index.</param>
        /// <param name="oldValues">The old values to replace.</param>
        /// <exception cref="ArgumentNullException">The string builder is null.</exception>
        public static void ReplaceMultiple(this StringBuilder stringBuilder, char newValue, int startIndex, int count, params char[] oldValues)
        {
            if (stringBuilder == null)
                throw new ArgumentNullException("stringBuilder", "The StringBuilder cannot be null.");
            
            if (oldValues == null || oldValues.Length == 0)
                return;

            foreach (char oldValue in oldValues)
                stringBuilder.Replace(oldValue, newValue, startIndex, count);
        }

        /// <summary>
        /// Replaces multiple characters within the string builder with a single new character value.
        /// </summary>
        /// <param name="stringBuilder">The string builder to replace the values in.</param>
        /// <param name="newValue">The new value to replace the old values with.</param>
        /// <param name="oldValues">The old values to replace.</param>
        /// <exception cref="ArgumentNullException">The string builder is null.</exception>
        public static void ReplaceMultiple(this StringBuilder stringBuilder, char newValue, params char[] oldValues)
        {
            ReplaceMultiple(stringBuilder, newValue, 0, stringBuilder.Length, oldValues);
        }
    }
}
