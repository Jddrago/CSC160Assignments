using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClockWithEvents;
using System.Windows.Threading;

namespace WPFClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Clock ticker;

        private delegate void NoArg();

        public MainWindow()
        {
            
            InitializeComponent();

            ticker = new Clock();

            /*
             * We could also use the Action type instead of NoArg and save some code.  
             * But then we'd need to understand Generics...
             * so I'll stick with NoArg for now.
            */
            NoArg start = ticker.Start;


            /*
             *  .NET prevents us from updating UI elements from another thread.
             *  Our clock uses Thread.Sleep which would make our app look like it crashed.
             *  We'll use a separate thread for the clock.Start method, then use the Dispatcher
             *  to update the UI in its own sweet time on its own sweet thread.  Think of 
             *  queueing up a message that is then processed by the UI thread when it's able.
             *  
             *  Importantly, we don't have to change the Clock class to take advantage of threading.
             *  All the Dispatch/BeginInvoke magic happens here in the client code.
             * 
             */
            ticker.SecondsChanged += Ticker_SecondsChangedOnDifferentThread;
            ticker.MinutesChanged += Ticker_MinutesChangedOnDifferentThread;
            ticker.DaysChanged += Ticker_DaysChangedOnDifferentThread;
            ticker.MilliSecondsChanged += Ticker_MilliSecondsChangedOnDifferentThread;
            ticker.HoursChanged += Ticker_HoursChangedOnDifferentThread;
            start.BeginInvoke(null, null);
            
        }

        
        private void Ticker_SecondChangedUIThread(int currentTime)
        {
            /*
             * This method is executed by the UI thread, and so can modify the label directly.
             */
             if(currentTime >= 10)
            {
                currentTime %= 10;
            }
             if(currentTime < 10)
            {
                SecondsLabel.Content = currentTime.ToString().PadLeft(2,'0');
            }
            else
            {
                SecondsLabel.Content = currentTime;
            }
                    
        }

        private void Ticker_SecondsChangedOnDifferentThread(int currentTime)
        {
            /*
             * Here's where the Clock's thread will put a message on the UI thread's queue of work,
             * again, through the use of a delegate
             */
            SecondsLabel.Dispatcher.BeginInvoke(new Action<int>(Ticker_SecondChangedUIThread), currentTime);
        }
        private void Ticker_DayChangedUIThread(int currentTime)
        {
            /*
             * This method is executed by the UI thread, and so can modify the label directly.
             */
                DaysLabel.Content = currentTime;
        }

        private void Ticker_DaysChangedOnDifferentThread(int currentTime)
        {
            /*
             * Here's where the Clock's thread will put a message on the UI thread's queue of work,
             * again, through the use of a delegate
             */
            DaysLabel.Dispatcher.BeginInvoke(new Action<int>(Ticker_DayChangedUIThread), currentTime);
        }

        private void Ticker_MinuteChangedUIThread(int currentTime)
        {
            /*
             * This method is executed by the UI thread, and so can modify the label directly.
             */
            if (currentTime >= 3)
            {
                currentTime %= 3;
            }
            if (currentTime < 10)
            {
                MinutesLabel.Content = currentTime.ToString().PadLeft(2, '0');
            }
            else
            {
                MinutesLabel.Content = currentTime;
            }
        }

        private void Ticker_MinutesChangedOnDifferentThread(int currentTime)
        {
            /*
             * Here's where the Clock's thread will put a message on the UI thread's queue of work,
             * again, through the use of a delegate
             */
            MinutesLabel.Dispatcher.BeginInvoke(new Action<int>(Ticker_MinuteChangedUIThread), currentTime);
        }

        private void Ticker_HourChangedUIThread(int currentTime)
        {
            /*
             * This method is executed by the UI thread, and so can modify the label directly.
             */
            if (currentTime >= 3)
            {
                currentTime %= 3;
            }
            if (currentTime < 10)
            {
                HoursLabel.Content = currentTime.ToString().PadLeft(2, '0');
            }
            else
            {
                HoursLabel.Content = currentTime;
            }
        }

        private void Ticker_HoursChangedOnDifferentThread(int currentTime)
        {
            /*
             * Here's where the Clock's thread will put a message on the UI thread's queue of work,
             * again, through the use of a delegate
             */
            HoursLabel.Dispatcher.BeginInvoke(new Action<int>(Ticker_HourChangedUIThread), currentTime);
        }

        private void Ticker_MilliSecondChangedUIThread(int currentTime)
        {
            /*
             * This method is executed by the UI thread, and so can modify the label directly.
             */
            if (currentTime >= 1000)
            {
                MilliSecondsLabel.Content = currentTime.ToString().Remove(0, currentTime.ToString().Length - 3);
            }
            else
            {
                MilliSecondsLabel.Content = currentTime;
            }
        }

        private void Ticker_MilliSecondsChangedOnDifferentThread(int currentTime)
        {
            /*
             * Here's where the Clock's thread will put a message on the UI thread's queue of work,
             * again, through the use of a delegate
             */
            MilliSecondsLabel.Dispatcher.BeginInvoke(new Action<int>(Ticker_MilliSecondChangedUIThread), currentTime);
        }

        private void DayBox_Checked(object sender, RoutedEventArgs e)
        {
            try {
                ticker.DaysChanged += Ticker_DaysChangedOnDifferentThread;
            }
            catch (NullReferenceException)
            {}
             
        }

        private void DayBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ticker.DaysChanged -= Ticker_DaysChangedOnDifferentThread;
        }

        private void HourBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ticker.HoursChanged += Ticker_HoursChangedOnDifferentThread;
            }
            catch (NullReferenceException) {}
        }

        private void HourBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ticker.HoursChanged -= Ticker_HoursChangedOnDifferentThread;
        }

        private void MinuteBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ticker.MinutesChanged += Ticker_MinutesChangedOnDifferentThread;
            }
            catch (NullReferenceException) {}
        }
        
        private void MinuteBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ticker.MinutesChanged -= Ticker_MinutesChangedOnDifferentThread;
        }

        private void SecondBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ticker.SecondsChanged += Ticker_SecondsChangedOnDifferentThread;
            }
            catch (NullReferenceException) { }
        }

        private void SecondBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ticker.SecondsChanged -= Ticker_SecondsChangedOnDifferentThread;
        }

        private void MilliSecondBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ticker.MilliSecondsChanged += Ticker_MilliSecondsChangedOnDifferentThread;
            } catch (NullReferenceException) { }
        }

        private void MilliSecondBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ticker.MilliSecondsChanged -= Ticker_MilliSecondsChangedOnDifferentThread;
        }


    }
}
