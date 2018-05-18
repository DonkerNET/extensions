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
        private static readonly IDictionary<Type, Func<object, object>> Converters;

        static ConversionUtil()
        {
            Converters = new Dictionary<Type, Func<object, object>>
            {
                { typeof(Guid), obj => Guid.Parse(obj.ToString()) },
                { typeof(TimeSpan), obj => TimeSpan.Parse(obj.ToString()) },
                { typeof(Uri), obj => new Uri(obj.ToString()) },
                { typeof(IPAddress), obj => IPAddress.Parse(obj.ToString()) }
                // Place additional conversion methods here
            };
        }

        public static object ChangeType(object input, Type newType)
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

            Func<object, object> converter;

            if (Converters.TryGetValue(newType, out converter))
                return converter.Invoke(input);

            return Convert.ChangeType(input, newType);
        }

        public static T ChangeType<T>(object input)
        {
            return (T)ChangeType(input, typeof(T));
        }

        public static bool TryChangeType(object input, Type newType, out object result, out Exception exception)
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

                Func<object, object> converter;

                result = Converters.TryGetValue(newType, out converter)
                    ? converter.Invoke(input)
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

        public static bool TryChangeType(object input, Type newType, out object result)
        {
            Exception exception;
            return TryChangeType(input, newType, out result, out exception);
        }

        public static bool TryChangeType<T>(object input, out T result, out Exception exception)
        {
            object resultObj;
            if (TryChangeType(input, typeof (T), out resultObj, out exception))
            {
                result = (T)resultObj;
                return true;
            }

            result = default(T);
            return false;
        }

        public static bool TryChangeType<T>(object input, out T result)
        {
            Exception exception;
            return TryChangeType<T>(input, out result, out exception);
        }
    }
}