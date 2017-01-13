using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Calculates the last week number for the year of the specified date according to the ISO 8601 standard.
        /// </summary>
        /// <param name="date">The date with the year to get the last week number for.</param>
        /// <returns>The last week number of the year.</returns>
        public static int GetIso8601LastWeek(this DateTimeOffset date)
        {
            DateTimeOffset lastDayOfYear = new DateTimeOffset(date.Year, 12, 31, 0, 0, 0, date.Offset);

            switch (lastDayOfYear.DayOfWeek)
            {
                case DayOfWeek.Thursday:
                    return 53;
                case DayOfWeek.Friday:
                    return DateTime.IsLeapYear(date.Year) ? 53 : 52;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return 52;
                default:
                    return 1;
            }
        }
    }
}
