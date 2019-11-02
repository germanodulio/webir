using Common;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

namespace BL.Tests
{
    [TestClass()]
    public class UtilsTests
    {
        [TestMethod()]
        public void GetLastDaysTest()
        {
            List<DateTime> days = Utils.GetLastDays(DateTime.Today, 7);

            Assert.AreEqual(7, days.Count);

            foreach (DateTime day in days)
            {
                Assert.IsTrue(day.DayOfWeek != DayOfWeek.Sunday && day.DayOfWeek != DayOfWeek.Saturday);
            }
        }
    }
}