using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssignment
{
    public static class ExtensionMethod
    {
        //Q01
        public static void PrintListOfStudents(this List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
