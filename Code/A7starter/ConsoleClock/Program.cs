using ClockWithEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClock
{
    class Program
    {
        Clock ticker;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }



        private void Run()
        {
            //This line no longer works because we changed the publicly exposed delegate to an event
            //c.secondsChanged = MyClockSecondsHaveChanged;

            //These lines are equivalent, they just point to different methods
            ticker.SecondsChanged += new Clock.TimeChangedDelegate(SecondsChangedHandler);
            ticker.MinutesChanged += MinutesChangedHandler;
            ticker.HoursChanged += HoursChangedHandler;
            ticker.DaysChanged += DaysChangedHandler;
            ticker.MilliSecondsChanged += MilliSecondsChangedHandler;
            Console.Write("00:00:00:000");
            ticker.Start();
        }

        public Program()
        {
            ticker = new Clock();            
        }

        void DaysChangedHandler(int days)
        {
            if (days < 10)
            {
                Console.Write(days.ToString().PadLeft(2, '0'), Console.CursorLeft = days.ToString().Length - 1);
            }
            else
            {
                Console.Write(days.ToString(), Console.CursorLeft = days.ToString().Length - 1);
            }
        }

        void HoursChangedHandler(int hours)
        {
            if (hours > 3)
            {
                hours -= 3;
            }
                if (hours < 10)
            {
                Console.Write(hours.ToString().PadLeft(2, '0'), Console.CursorLeft = hours.ToString().Length - 1);
            }
            else
            {
                Console.Write(hours.ToString(), Console.CursorLeft = hours.ToString().Length - 1);
            }
        }

        private void MinutesChangedHandler(int minutes)
        {
            if (minutes > 3)
            {
                minutes -= 3;
            }
            if (minutes < 10)
            {
                Console.Write(minutes.ToString().PadLeft(2, '0'), Console.CursorLeft = (minutes.ToString().Length - 1)+3);
            }
            else
            {
                Console.Write(minutes.ToString(), Console.CursorLeft = (minutes.ToString().Length - 2)+3);
            }
        }


        void SecondsChangedHandler(int seconds)
        {
            if (seconds >= 10)
            {
                seconds -= 10;
            }
            if (seconds < 10)
            {
                Console.Write(seconds.ToString().PadLeft(2, '0'), Console.CursorLeft = (seconds.ToString().Length - 1)+6);
            }
            else
            {
                Console.Write(seconds.ToString(), Console.CursorLeft = (seconds.ToString().Length-2)+6);
            }
        }

        void MilliSecondsChangedHandler(int milliseconds)
        {
            if (milliseconds >= 1000)
            {
                milliseconds -= 1000;
            }
            if (milliseconds < 1000)
            {
                //Console.Write(milliseconds.ToString(), Console.CursorLeft = (milliseconds.ToString().Length - 1) + 9);
                Console.Write(milliseconds.ToString(), Console.CursorLeft = 9);
            }
            else
            {
                Console.Write(milliseconds.ToString().Remove(0, milliseconds.ToString().Length-3), Console.CursorLeft = 9);
            }
        }


    }
}
