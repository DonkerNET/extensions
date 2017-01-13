using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Calculates the age between this <see cref="DateTimeOffset"/> and another one.
        /// </summary>
        /// <param name="from">The from value for which to calculate the age.</param>
        /// <param name="to">The to value for which to calculate the age.</param>
        /// <returns>The age as an <see cref="int"/>.</returns>
        public static int CalculateAge(this DateTimeOffset from, DateTimeOffset to)
        {
            DateTime fromUtc = from.UtcDateTime;
            DateTime toUtc = to.UtcDateTime;

            int age = toUtc.Year - fromUtc.Year;

            if (fromUtc > toUtc.AddYears(-age))
                --age;

            return age;
        }

        /// <summary>
        /// Calculates the age between this <see cref="DateTimeOffset"/> and the current time.
        /// </summary>
        /// <param name="from">The value for which to calculate the age.</param>
        /// <returns>The age as an <see cref="int"/>.</returns>
        public static int CalculateAge(this DateTimeOffset from)
        {
            return CalculateAge(from, DateTimeOffset.Now);
        }
    }
}
