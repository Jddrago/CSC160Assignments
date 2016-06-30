using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    public class Day
    {
        public enum TimeCodes {REGULAR, SICK, VACATION }
        public int NumHours { get; set; }
        private const int MaxHours = 24;
        private float RegularHours = 0;
        private float SickHours = 0;
        private float VacationHours = 0;
        private DateTime dateTime;

        public Day(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public float HoursWorked { get; set; }


        public void Add(TimeCodes timeType, float hours)
        {
            if (hours > 0)
            {
                HoursWorked += hours;
                if (timeType == TimeCodes.REGULAR)
                {
                    RegularHours += hours;
                }
                else if (timeType == TimeCodes.SICK)
                {
                    SickHours += hours;
                }
                else if (timeType == TimeCodes.VACATION)
                {
                    VacationHours += hours;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("hours","Hours must be > 0.");
            }
        }

        public bool Validate()
        {
            if (HoursWorked <= 24 && HoursWorked>0)
            {
                return true;
            }
            return false;
        }

        public void Subtract(float hours)
        {
            if (hours < 0)
            {
                HoursWorked -= hours;
            }
            else
            {
                throw new ArgumentOutOfRangeException("hours","Hours must be < 0");
            }
        }
    }
}
