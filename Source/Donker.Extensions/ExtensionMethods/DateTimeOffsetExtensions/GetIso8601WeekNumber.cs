using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Calculates the week number for the specified date according to the ISO 8601 standard.
        /// </summary>
        /// <param name="date">The date to get the week number for.</param>
        /// <returns>The number of the week.</returns>
        public static int GetIso8601WeekNumber(this DateTimeOffset date)
        {
            int ordinalDate = date.DayOfYear;
            int weekDay = date.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)date.DayOfWeek;

            int weekNumber = (ordinalDate - weekDay + 10) / 7;

            if (weekNumber >= 1 && weekNumber <= 52)
                return weekNumber;

            int baseYear = weekNumber < 1
                ? date.Year - 1
                : date.Year;

            DateTimeOffset lastDayOfYear = new DateTimeOffset(baseYear, 12, 31, 0, 0, 0, TimeSpan.Zero);

            switch (lastDayOfYear.DayOfWeek)
            {
                case DayOfWeek.Thursday:
                    return 53;
                case DayOfWeek.Friday:
                    return DateTime.IsLeapYear(baseYear) ? 53 : 52;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return 52;
                default:
                    return 1;
            }
        }
    }
}
