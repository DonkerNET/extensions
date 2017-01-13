using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class GenericExtensions
    {
        /// <summary>
        /// Checks the type to see if it's a numeric data type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><value>true</value> if <paramref name="type"/> is a numeric data type; otherwise, <value>false</value>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        public static bool IsOfNumberType(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type", "The specified type cannot be null.");
            
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