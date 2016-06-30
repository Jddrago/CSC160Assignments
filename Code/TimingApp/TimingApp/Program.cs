using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            Stopwatch timer = new Stopwatch();
            const int numLines = 100000000;

            string[] data = new string[numLines];
            for (int i = 0; i < numLines; i++)
            {
                try
                {
                    if (i % 1000 == 0) { Console.WriteLine(i); }

                    //overwrites the file
                    //Create and write to the file, 100 file writes
                    //File.WriteAllText(@"c:\temp\mydata.txt", Guid.NewGuid().ToString());

                    //use a different method to append to the file, 100 file writes
                    // File.AppendAllText(@"c:\temp\mydata.txt", String.Concat(Guid.NewGuid().ToString(), Environment.NewLine));

                    data[i] = Guid.NewGuid().ToString();

                    // File.WriteAllText(@"c:\temp\LotsOfGuids\" + (i + 1) + ".txt", Guid.NewGuid().ToString());
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine(i);
                }
                
            }
            timer.Start();
            File.AppendAllLines(@"c:\temp\mydatawrittenonce.txt", data);
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);

            //Console.WriteLine("Done.  Hit any key to continue.");
            Console.ReadKey();

        }
    }
}
