using System;

namespace Donker.Extensions.Helpers.ComparisonHelper
{
    public static partial class ComparisonHelper
    {
        public static T GetMinValue<T>(params T[] values)
           where T : IComparable<T>
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values), "The value collection cannot be null.");
            if (values.Length == 0)
                throw new ArgumentException("The value collection cannot be empty.", nameof(values));

            T min = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                T next = values[i];

                if (next.CompareTo(next) < 0)
                    min = next;
            }

            return min;
        }
    }
}