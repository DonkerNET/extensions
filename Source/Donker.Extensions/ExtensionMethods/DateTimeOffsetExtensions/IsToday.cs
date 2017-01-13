using System;

namespace Donker.Extensions.ExtensionMethods
{
    public static partial class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Check whether this <see cref="DateTimeOffset"/> is on the current day.
        /// </summary>
        /// <param name="dateTimeOffset">The value to check.</param>
        /// <returns><c>true</c> if on the current day; otherwise, <c>false</c>.</returns>
        public static bool IsToday(this DateTimeOffset dateTimeOffset)
        {
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            return utcNow.Date == dateTimeOffset.UtcDateTime.Date;
        }
    }
}
