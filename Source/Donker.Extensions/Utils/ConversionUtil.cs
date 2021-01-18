using System;
using System.Collections.Generic;
using System.Net;

namespace Donker.Extensions.Utils
{
    /// <summary>
    /// Utility class for extended type conversion.
    /// </summary>
    public static class ConversionUtil
    {
        // Converter methods for types that cannot be converted with System.Convert.ChangeType
        private static readonly IDictionary<Type, Func<object, IFormatProvider, object>> Converters;

        static ConversionUtil()
        {
            Converters = new Dictionary<Type, Func<object, IFormatProvider, object>>
            {
                { typeof(Guid), (obj, fp) => ToGuid(obj) },
                { typeof(TimeSpan), (obj, fp) => ToTimeSpan(obj, fp) },
                { typeof(Uri), (obj, fp) => ToUri(obj) },
                { typeof(IPAddress), (obj, fp) => ToIpAddress(obj) }
            };
        }

        public static Guid ToGuid(object input)
        {
            if (input is Guid)
                return (Guid)input;

            byte[] inputBytes = input as byte[];
            if (inputBytes != null)
                return new Guid(inputBytes);

            string inputString = input as string;
            if (inputString != null)
                return Guid.Parse(inputString);

            throw new ArgumentException($"Input type {input?.GetType() ?? typeof(object)} is not convertible to {typeof(Guid)}.", nameof(input));
        }

        public static TimeSpan ToTimeSpan(object input, IFormatProvider formatProvider)
        {
            if (input is TimeSpan)
                return (TimeSpan)input;

            if (input is long)
                return new TimeSpan((long)input);

            string inputString = input as string;
            if (inputString != null)
            {
                return formatProvider != null
                    ? TimeSpan.Parse(inputString, formatProvider)
                    : TimeSpan.Parse(inputString);
            }

            throw new ArgumentException($"Input type {input?.GetType() ?? typeof(object)} is not convertible to {typeof(TimeSpan)}.", nameof(input));
        }

        public static TimeSpan ToTimeSpan(object input)
        {
            return ToTimeSpan(input, null);
        }

        public static Uri ToUri(object input)
        {
            if (input is Uri)
                return (Uri)input;

            string inputString = input as string;
            if (inputString != null)
                return new Uri(input.ToString());

            throw new ArgumentException($"Input type {input?.GetType() ?? typeof(object)} is not convertible to {typeof(Uri)}.", nameof(input));
        }

        public static IPAddress ToIpAddress(object input)
        {
            if (input is IPAddress)
                return (IPAddress)input;

            byte[] inputBytes = input as byte[];
            if (inputBytes != null)
                return new IPAddress(inputBytes);

            if (input is long)
                return new IPAddress((long)input);

            string inputString = input as string;
            if (inputString != null)
                return IPAddress.Parse(inputString);

            throw new ArgumentException($"Input type {input?.GetType() ?? typeof(object)} is not convertible to {typeof(IPAddress)}.", nameof(input));
        }

        public static object ChangeType(object input, Type newType, IFormatProvider formatProvider)
        {
            if (input == null || newType == null)
                return null;

            if (newType.IsEnum)
            {
                string inputStr = input as string;

                if (inputStr != null)
                    return Enum.Parse(newType, inputStr);

                newType = newType.GetEnumUnderlyingType();
            }

            Func<object, IFormatProvider, object> converter;

            if (Converters.TryGetValue(newType, out converter))
                return converter.Invoke(input, formatProvider);

            return Convert.ChangeType(input, newType);
        }

        public static object ChangeType(object input, Type newType)
        {
            return ChangeType(input, newType, null);
        }

        public static T ChangeType<T>(object input, IFormatProvider formatProvider)
        {
            return (T)ChangeType(input, typeof(T), formatProvider);
        }

        public static T ChangeType<T>(object input)
        {
            return ChangeType<T>(input, null);
        }

        public static bool TryChangeType(object input, Type newType, IFormatProvider formatProvider, out object result, out Exception exception)
        {
            if (input == null || newType == null)
            {
                result = null;
                exception = null;
                return false;
            }

            try
            {
                if (newType.IsEnum)
                {
                    string inputStr = input as string;

                    if (inputStr != null)
                    {
                        result = Enum.Parse(newType, inputStr);
                        exception = null;
                        return true;
                    }

                    newType = newType.GetEnumUnderlyingType();
                }

                Func<object, IFormatProvider, object> converter;

                result = Converters.TryGetValue(newType, out converter)
                    ? converter.Invoke(input, formatProvider)
                    : Convert.ChangeType(input, newType);

                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                result = null;
                exception = ex;
                return false;
            }
        }

        public static bool TryChangeType(object input, Type newType, IFormatProvider formatProvider, out object result)
        {
            Exception exception;
            return TryChangeType(input, newType, formatProvider, out result, out exception);
        }

        public static bool TryChangeType<T>(object input, IFormatProvider formatProvider, out T result, out Exception exception)
        {
            object resultObj;
            if (TryChangeType(input, typeof (T), formatProvider, out resultObj, out exception))
            {
                result = (T)resultObj;
                return true;
            }

            result = default(T);
            return false;
        }

        public static bool TryChangeType<T>(object input, IFormatProvider formatProvider, out T result)
        {
            Exception exception;
            return TryChangeType<T>(input, formatProvider, out result, out exception);
        }

        public static bool TryChangeType(object input, Type newType, out object result, out Exception exception)
        {
            return TryChangeType(input, newType, null, out result, out exception);
        }

        public static bool TryChangeType(object input, Type newType, out object result)
        {
            return TryChangeType(input, newType, null, out result);
        }

        public static bool TryChangeType<T>(object input, out T result, out Exception exception)
        {
            return TryChangeType<T>(input, null, out result, out exception);
        }

        public static bool TryChangeType<T>(object input, out T result)
        {
            return TryChangeType<T>(input, null, out result);
        }
    }
}