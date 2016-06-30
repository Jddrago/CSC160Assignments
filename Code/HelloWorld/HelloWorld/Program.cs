using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            string[] data = new string[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                if (i % 1000 == 0) { Console.WriteLine(i); }

                //overwrites the file
                //Create and write to the file, 100 file writes
                //File.WriteAllText(@"c:\temp\mydata.txt", Guid.NewGuid().ToString());

                //use a different method to append to the file, 100 file writes
                File.AppendAllText(@"c:\temp\mydata.txt", String.Concat(Guid.NewGuid().ToString(), Environment.NewLine));

                data[i] = Guid.NewGuid().ToString();

                File.WriteAllText(@"c:\temp\LotsOfGuids\" + (i + 1) + ".txt", Guid.NewGuid().ToString());

            }

            File.AppendAllLines(@"c:\temp\mydatawrittenonce.txt", data);

            Console.WriteLine("Done.  Hit any key to continue.");
            Console.ReadKey();

        }
    }
}
