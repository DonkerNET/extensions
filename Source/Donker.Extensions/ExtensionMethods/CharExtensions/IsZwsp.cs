namespace Donker.Extensions.ExtensionMethods
{
    public static partial class CharExtensions
    {
        /// <summary>
        /// Checks if a character is a zero-width space character.
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns><c>true</c> if it's a zero-width space character; otherwise, <c>false</c>.</returns>
        public static bool IsZwsp(this char character)
        {
            switch (character)
            {
                case '\u180e': // MONGOLIAN VOWEL SEPARATOR
                case '\u200b': // ZERO WIDTH SPACE
                case '\ufeff': // ZERO WIDTH NO-BREAK SPACE
                    return true;
            }

            return false;
        }
    }
}
