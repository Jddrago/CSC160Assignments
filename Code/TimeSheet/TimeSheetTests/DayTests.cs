using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Tests
{
    [TestClass()]
    public class DayTests
    {
        [TestMethod()]
        public void ValidateTest()
        {
            Day t = new Day();
            t.Add(Day.TimeCodes.REGULAR, 16);
            t.Add(Day.TimeCodes.SICK, 4);
            t.Add(Day.TimeCodes.VACATION, 5);

            Assert.IsFalse(t.Validate());
        }
    }
}