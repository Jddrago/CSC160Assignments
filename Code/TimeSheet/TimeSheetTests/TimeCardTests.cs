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
    public class TimeCardTests
    {
        [TestMethod()]
        public void HoursByCategoryTest()
        {
            TimeCard t = new TimeCard();
            
            for(int i = 0; i<14; i++)
            {
                t.PayPeriod[i] = new Day();
                t.PayPeriod[i].Add(Day.TimeCodes.REGULAR, 8.25f);
            }
            
            Console.WriteLine(t.HoursByCategory());
            Console.WriteLine("Overtime week 1: "+t.CalcOvertime(1));
            Console.WriteLine("Overtime week 2: "+t.CalcOvertime(2));
        }
    }
}