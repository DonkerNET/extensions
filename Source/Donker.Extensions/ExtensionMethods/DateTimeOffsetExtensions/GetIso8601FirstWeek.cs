using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Calculates the first week number for the year of the specified date according to the ISO 8601 standard.
        /// </summary>
        /// <param name="date">The date with the year to get the first week number for.</param>
        /// <returns>The first week number of the year.</returns>
        public static int GetIso8601FirstWeek(this DateTimeOffset date)
        {
            DateTimeOffset firstDayOfYear = new DateTimeOffset(date.Year, 1, 1, 0, 0, 0, date.Offset);

            switch (firstDayOfYear.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    return 53;
                case DayOfWeek.Saturday:
                    return DateTime.IsLeapYear(date.Year - 1) ? 53 : 52;
                case DayOfWeek.Sunday:
                    return 52;
                default:
                    return 1;
            }
        }
    }
}
