using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    public class TimeCard
    {
        private const int NumDays = 14;
        public Day[] PayPeriod = new Day[NumDays];

        public bool HasOvertime()
        {
            float TotalHours = 0;
            for (int i = 0; i < NumDays; ++i)
            {
                TotalHours += PayPeriod[i].HoursWorked; 
            }
            if (TotalHours > 40)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
