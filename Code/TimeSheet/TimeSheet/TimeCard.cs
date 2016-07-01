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

        public float CalcOvertime(int weekNumber)
        {
            float TotalReghours = 0;
            float OverTime = 0;
            if (weekNumber == 1)
            {
                for (int i = 0; i < NumDays / 2; i++)
                {
                    TotalReghours += _PayPeriod[i].Hours[(int)Day.TimeCodes.REGULAR];
                }
                OverTime = TotalReghours - 40;
                return OverTime;
            }
            if (weekNumber == 2)
            {
                for (int i = NumDays/2; i < NumDays; i++)
                {
                    TotalReghours += _PayPeriod[i].Hours[(int)Day.TimeCodes.REGULAR];
                }
                OverTime = TotalReghours - 40;
                return OverTime;
            }
            return 0;
        }

        public string HoursByCategory()
        {
            float RegHours=0,SickHours=0,VacHours=0;
            for (int i = 0; i < NumDays; ++i)
                {
                    RegHours += _PayPeriod[i].Hours[(int)Day.TimeCodes.REGULAR];
                }
            for (int i = 0; i < NumDays; ++i)
                {
                    SickHours += _PayPeriod[i].Hours[(int)Day.TimeCodes.SICK];
                }
            for (int i = 0; i < NumDays; ++i)
                {
                    VacHours += _PayPeriod[i].Hours[(int)Day.TimeCodes.VACATION];
                }
            return "Regular hours: " + RegHours + ".\nSick hours: " + SickHours + ".\nVacation hours: " + VacHours + ".\n";
        }
    }
}
