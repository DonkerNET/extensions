namespace Donker.Extensions.ExtensionMethods
{
    public static partial class CharExtensions
    {
        /// <summary>
        /// Checks if a character also represents a hexadecimal character (0-9, a-f or A-F).
        /// </summary>
        /// <param name="character">The character to check.</param>
        /// <returns><c>true</c> if hexadecimal; otherwise, <c>false</c>.</returns>
        public static bool IsHex(this char character)
        {
            return (character >= '0' && character <= '9')
                || (character >= 'a' && character <= 'f')
                || (character >= 'A' && character <= 'F');
        }
    }
}
