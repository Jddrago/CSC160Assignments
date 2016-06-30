using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    public class Day
    {
        public enum TimeCodes {REGULAR, SICK, VACATION, LASTTIMEENUM }
        private float[] _Hours = new float[(int)TimeCodes.LASTTIMEENUM];

        public float[] Hours
        {
            get { return _Hours; }
            set { _Hours = value; }
        }

        private DateTime dateTime;

        public Day(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public Day()
        {
        }

        public float HoursWorked { get; set; }


        public void Add(TimeCodes timeType, float hours)
        {
            if (hours > 0)
            {
                _Hours[(int)timeType] += hours;
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

        public void Subtract(TimeCodes timeType, float hours)
        {
            if (hours < 0)
            {
                _Hours[(int)timeType] -= hours;
            }
            else
            {
                throw new ArgumentOutOfRangeException("hours","Hours must be < 0");
            }
        }
    }
}
