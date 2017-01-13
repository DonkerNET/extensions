using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class GenericExtensions
    {
        /// <summary>
        /// Checks this object's type to see if it's of a numeric data type.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <returns><value>true</value> if <paramref name="obj"/> is of a numeric data type; otherwise, <value>false</value>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> is null.</exception>
        public static bool IsNumber<T>(this T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj", "The object cannot be null.");

            Type type = obj.GetType();

            return type == typeof(sbyte)
                || type == typeof(byte)
                || type == typeof(short)
                || type == typeof(ushort)
                || type == typeof(int)
                || type == typeof(uint)
                || type == typeof(long)
                || type == typeof(ulong)
                || type == typeof(float)
                || type == typeof(double)
                || type == typeof(decimal);
        }
    }
}
