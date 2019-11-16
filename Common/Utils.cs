using System;
using System.Collections.Generic;

using static Common.Enums;

namespace Common
{
    public static class Utils
    {
        public static List<DateTime> GetLastDays(CoinCode coinCode, DateTime lastDay, int daysCount)
        {
            List<DateTime> result = new List<DateTime>();
            while (daysCount > 0)
            {
                if (IsValidDay(lastDay, coinCode))
                {
                    result.Add(lastDay);
                    daysCount--;
                }
                lastDay = lastDay.AddDays(-1);
            }
            result.Reverse();
            return result;
        }

        private static bool IsValidDay(DateTime day, CoinCode coinCode)
        {
            if (day.Date == DateTime.Today)
            {
                switch (coinCode)
                {
                    case CoinCode.DolarArg:
                    case CoinCode.DolarArgBlue:
                        return DateTime.Now >= day.AddHours(22);
                    case CoinCode.DolarUy:
                    case CoinCode.PesoArgUy:
                        return DateTime.Now >= day.AddHours(17);
                    default:
                        return IsValidDay(day);
                }
            }
            return IsValidDay(day);
        }

        public static List<DateTime> GetLastDays(DateTime lastDay, int daysCount)
        {
            List<DateTime> result = new List<DateTime>();
            while (daysCount > 0)
            {
                if (IsValidDay(lastDay))
                {
                    result.Add(lastDay);
                    daysCount--;
                }
                lastDay = lastDay.AddDays(-1);
            }
            result.Reverse();
            return result;
        }

        /// <summary>
        /// Returns true if it is not saturday or sunday
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static bool IsValidDay(DateTime day)
        {
            return day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday;
        }

        public static List<DateTime> GetValidDays(DateTime start, DateTime end)
        {
            if (start > end)
            {
                throw new Exception("Las fecha de inicio no puede ser menor a la de fin.");
            }
            if (end > DateTime.Today.Date)
            {
                throw new Exception("La fecha de fin no puede ser mayor a la fecha de hoy.");
            }
            List<DateTime> result = new List<DateTime>();
            DateTime current = start;
            while (current <= end)
            {
                if (IsValidDay(current))
                {
                    result.Add(current);
                }
                current = current.AddDays(1);
            }
            return result;
        }
    }
}
