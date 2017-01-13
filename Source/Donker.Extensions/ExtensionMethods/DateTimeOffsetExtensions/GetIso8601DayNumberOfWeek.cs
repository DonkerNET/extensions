using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Gets a number that represents the day of the week for the specified date (1 being the first day),
        /// according to the ISO 8601 standard where Monday is the first day in a week.
        /// </summary>
        /// <param name="date">The date to get the weekday number for.</param>
        /// <returns>The number of the day of the week.</returns>
        public static int GetIso8601DayNumberOfWeek(this DateTimeOffset date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)date.DayOfWeek;
        }   
    }
}