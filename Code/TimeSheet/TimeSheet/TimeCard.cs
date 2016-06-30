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
        private Day[] _PayPeriod = new Day[NumDays];

        public Day[] PayPeriod
        {
            get { return _PayPeriod; }
            set { _PayPeriod = value; }
        }


        public bool HasOvertime()
        {
            float TotalHours = 0;
            for (int i = 0; i < NumDays; ++i)
            {
                TotalHours += _PayPeriod[i].Hours[(int)Day.TimeCodes.REGULAR]; 
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
