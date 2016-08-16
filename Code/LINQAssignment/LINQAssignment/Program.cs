using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAssignment
{
    class Program
    {
        public static List<Student> students = new List<Student>
        {
           new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
           new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
           new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
           new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
           new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
           new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
           new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
           new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
           new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
           new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
           new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
           new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} }
        };

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            Console.WriteLine("Students with last name Garcia:");
            Query1();
            Console.WriteLine("\nStudents with first name stating with H:");
            Query2();
            Console.WriteLine("\nStudents ordered by first name:");
            Query3();
            Console.WriteLine("\nFirstOrDefault query:");
            Query4();
            Console.WriteLine("\nGrouping query:");
            Query5();
            Console.WriteLine("\nAverage test score per student:");
            Query6();
            Console.WriteLine("\nAverage score per test:");
            Query7();
        }

        //Q02
        public void Query1()
        {
            var filteredStudents = students.Where(s => s.Last.Equals("Garcia"));
            filteredStudents.ToList().PrintListOfStudents();
        }

        //Q03
        public void Query2()
        {
            var filterStudents = from Student in students where Student.First.StartsWith("H") select Student;
            filterStudents.ToList().PrintListOfStudents();
        }

        //Q04
        public void Query3()
        {
            var filteredStudents = from Student in students orderby Student.First select Student;
            filteredStudents.ToList().PrintListOfStudents();
        }


        //Q06
        public void Query4()
        {
            var filteredStudents = from Student in students orderby Student.First select Student;
            Console.WriteLine(filteredStudents.FirstOrDefault().ToString());
        }

        //Q08/Q10
        public void Query5()
        {
            var filteredStudents = from Student in students group Student by Student.First[0];
            foreach (var studentGroup in filteredStudents)
            {
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }

        //Q12
        public void Query6()
        {
            var studentScores = new List<Student>();
            foreach (var student in students)
            {
                int sum = 0;
                int count = 0;
                foreach (var score in student.Scores)
                {
                    sum += score;
                    count++;
                }
                double avg = sum/count;
                studentScores.Add(new Student {First = student.First, Last= student.Last, ID = student.ID, averageTestScore = avg });
            }
            foreach (var student in studentScores)
            {
                Console.WriteLine(student.ToString() + $", average score: { student.averageTestScore}");
            }
        }

        //Q13
        public void Query7()
        {
            const int numTests = 4;
            double[] avgTestScores = new double[numTests];
            int[] sum = new int[numTests];
            int[] count = new int[numTests];
            foreach (var student in students)
            {
                for (int i = 0; i < student.Scores.Capacity; i++)
                {
                    sum[i] += student.Scores[i];
                    count[i] += 1;
                }
            }
            for (int i = 0; i < numTests; i++)
            {
                avgTestScores[i] = sum[i] / count[i];
                Console.WriteLine($"Test 1 average: {avgTestScores[i]}");
            }
        }
    }
}
