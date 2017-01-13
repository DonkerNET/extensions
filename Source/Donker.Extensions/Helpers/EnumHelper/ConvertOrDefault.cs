using System;

namespace Donker.Extensions.Helpers
{
    public static partial class EnumHelper
    {
        /// <summary>
        /// Tries to convert a <see cref="string"/> value to an enum and returns a default value if it fails.
        /// </summary>
        /// <typeparam name="TEnum">The type of enum to convert the value to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="ignoreCase">If <c>true</c>, the value will be parsed using case-insensitivity.</param>
        /// <param name="defaultValue">The default value to return in case the conversion failed.</param>
        /// <param name="success">If the output is <c>true</c>, the conversion was successful.</param>
        /// <returns>The converted or default enum value of the <typeparamref name="TEnum"/> type.</returns>
        public static TEnum ConvertOrDefault<TEnum>(string value, bool ignoreCase, TEnum defaultValue, out bool success)
           where TEnum : struct, IConvertible
        {
            Type enumType = typeof(TEnum);

            if (!enumType.IsEnum)
                throw new ArgumentException("'TEnum' is not a valid enumeration type.");

            if (value != null)
            {
                TEnum result;
                if (Enum.TryParse(value, ignoreCase, out result))
                {
                    success = true;
                    return result;
                }
            }

            success = false;
            return defaultValue;
        }

        /// <summary>
        /// Tries to convert a <see cref="string"/> value to an enum and returns a default value if it fails.
        /// </summary>
        /// <typeparam name="TEnum">The type of enum to convert the value to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="ignoreCase">If <c>true</c>, the value will be parsed using case-insensitivity.</param>
        /// <param name="success">If the output is <c>true</c>, the conversion was successful.</param>
        /// <returns>The converted or default enum value of the <typeparamref name="TEnum"/> type.</returns>
        public static TEnum ConvertOrDefault<TEnum>(string value, bool ignoreCase, out bool success)
           where TEnum : struct, IConvertible
        {
            return ConvertOrDefault(value, ignoreCase, default(TEnum), out success);
        }

        /// <summary>
        /// Tries to convert a <see cref="string"/> value to an enum and returns a default value if it fails.
        /// </summary>
        /// <typeparam name="TEnum">The type of enum to convert the value to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="ignoreCase">If <c>true</c>, the value will be parsed using case-insensitivity.</param>
        /// <param name="defaultValue">The default value to return in case the conversion failed.</param>
        /// <returns>The converted or default enum value of the <typeparamref name="TEnum"/> type.</returns>
        public static TEnum ConvertOrDefault<TEnum>(string value, bool ignoreCase, TEnum defaultValue)
           where TEnum : struct, IConvertible
        {
            bool success;
            return ConvertOrDefault(value, ignoreCase, defaultValue, out success);
        }

        /// <summary>
        /// Tries to convert a <see cref="string"/> value to an enum and returns a default value if it fails.
        /// </summary>
        /// <typeparam name="TEnum">The type of enum to convert the value to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="ignoreCase">If <c>true</c>, the value will be parsed using case-insensitivity.</param>
        /// <returns>The converted or default enum value of the <typeparamref name="TEnum"/> type.</returns>
        public static TEnum ConvertOrDefault<TEnum>(string value, bool ignoreCase)
           where TEnum : struct, IConvertible
        {
            bool success;
            return ConvertOrDefault(value, ignoreCase, default(TEnum), out success);
        }
    }
}