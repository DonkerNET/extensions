using System;

namespace Donker.Extensions.Helpers
{
    public static partial class EnumHelper
    {
        /// <summary>
        /// Parses a value to an enum and returns it casted to the specified type.
        /// </summary>
        /// <typeparam name="TEnum">The type to cast the parsed value to.</typeparam>
        /// <param name="value">The value to parse.</param>
        /// <returns>The <paramref name="value"/> parsed and casted to the type of <typeparamref name="TEnum"/>.</returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not a valid enumeration type. </exception>
        /// <exception cref="OverflowException"><paramref name="value"/> is outside the range of the underlying type of <typeparamref name="TEnum"/>.</exception>
        public static TEnum Parse<TEnum>(string value)
            where TEnum : struct, IConvertible
        {
            Type enumType = typeof(TEnum);

            if (!enumType.IsEnum)
                throw new ArgumentException("'TEnum' is not a valid enumeration type.");
            
            object parsedEnum = Enum.Parse(enumType, value);
            return (TEnum)parsedEnum;
        }
    }
}