using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class GenericExtensions
    {
        /// <summary>
        /// Tries to convert this value to a different type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="newType">The type to convert the value to.</param>
        /// <param name="result">When successful, this will contain the converted value.</param>
        /// <param name="formatProvider">The format provider to use for conversion.</param>
        /// <returns>The converted value as an <see cref="object"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="newType"/> is null.</exception>
        public static bool TryConvert(this object value, Type newType, out object result, IFormatProvider formatProvider)
        {
            if (newType == null)
                throw new ArgumentNullException("newType", "The new type cannot be null.");

            if (value != null && !System.Convert.IsDBNull(value))
            {
                Type valueType = value.GetType();

                if (valueType == newType)
                {
                    result = value;
                    return true;
                }

                Type underlyingValueType = Nullable.GetUnderlyingType(valueType);

                if (underlyingValueType != null && underlyingValueType == newType)
                {
                    result = value;
                    return true;
                }

                IConvertible convertible = value as IConvertible;

                if (convertible != null)
                {
                    try
                    {
                        object convertedValue = formatProvider == null
                            ? System.Convert.ChangeType(convertible, newType)
                            : System.Convert.ChangeType(convertible, newType, formatProvider);
                        result = convertedValue;
                        return true;
                    }
                    catch (InvalidCastException)
                    {
                    }
                }
            }

            result = null;
            return false;
        }

        /// <summary>
        /// Tries to convert this value to a different type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="newType">The type to convert the value to.</param>
        /// <param name="result">When successful, this will contain the converted value.</param>
        /// <returns>The converted value as an <see cref="object"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="newType"/> is null.</exception>
        public static bool TryConvert(this object value, Type newType, out object result)
        {
            return TryConvert(value, newType, out result, null);
        }

        /// <summary>
        /// Tries to convert this value to a different type.
        /// </summary>
        /// <typeparam name="T">The type to convert the value to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="result">When successful, this will contain the converted value.</param>
        /// <param name="formatProvider">The format provider to use for conversion.</param>
        /// <returns>The converted value as <see cref="T"/>.</returns>
        public static bool TryConvert<T>(this object value, out T result, IFormatProvider formatProvider)
        {
            object convertedValue;
            bool success = TryConvert(value, typeof(T), out convertedValue, formatProvider);

            result = success ? (T)convertedValue : default(T);
            return success;
        }

        /// <summary>
        /// Tries to convert this value to a different type.
        /// </summary>
        /// <typeparam name="T">The type to convert the value to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="result">When successful, this will contain the converted value.</param>
        /// <returns>The converted value as <see cref="T"/>.</returns>
        public static bool TryConvert<T>(this object value, out T result)
        {
            return TryConvert(value, out result, null);
        }

        /// <summary>
        /// Tries to convert this value to a different type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="newType">The type to convert the value to.</param>
        /// <param name="formatProvider">The format provider to use for conversion.</param>
        /// <returns>The converted value as an <see cref="object"/>.</returns>
        /// <exception cref="InvalidCastException">This conversion is not supported.</exception>
        /// <exception cref="FormatException"><paramref name="value"/> is not in a format for <paramref name="newType"/> recognized by <paramref name="formatProvider"/>.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> represents a number that is out of the range of <paramref name="newType"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="newType"/> is null.</exception>
        public static object Convert(this object value, Type newType, IFormatProvider formatProvider)
        {
            object convertedValue;
            bool success = TryConvert(value, newType, out convertedValue, formatProvider);

            if (!success)
                throw new InvalidCastException(string.Format("Could not convert the value to {0}.", newType));

            return convertedValue;
        }

        /// <summary>
        /// Tries to convert this value to a different type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="newType">The type to convert the value to.</param>
        /// <returns>The converted value as an <see cref="object"/>.</returns>
        /// <exception cref="InvalidCastException">This conversion is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> represents a number that is out of the range of <paramref name="newType"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="newType"/> is null.</exception>
        public static object Convert(this object value, Type newType)
        {
            return Convert(value, newType, null);
        }

        /// <summary>
        /// Tries to convert this value to a different type.
        /// </summary>
        /// <typeparam name="T">The type to convert the value to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="formatProvider">The format provider to use for conversion.</param>
        /// <returns>The converted value as <see cref="T"/>.</returns>
        /// <exception cref="InvalidCastException">This conversion is not supported.</exception>
        /// <exception cref="FormatException"><paramref name="value"/> is not in a format for <typeparamref name="T"/> recognized by <paramref name="formatProvider"/>.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> represents a number that is out of the range of <typeparamref name="T"/>.</exception>
        public static T Convert<T>(this object value, IFormatProvider formatProvider)
        {
            return (T)Convert(value, typeof(T), formatProvider);
        }

        /// <summary>
        /// Tries to convert this value to a different type.
        /// </summary>
        /// <typeparam name="T">The type to convert the value to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value as <see cref="T"/>.</returns>
        /// <exception cref="InvalidCastException">This conversion is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value"/> represents a number that is out of the range of <typeparamref name="T"/>.</exception>
        public static T Convert<T>(this object value)
        {
            return Convert<T>(value, null);
        }
    }
}