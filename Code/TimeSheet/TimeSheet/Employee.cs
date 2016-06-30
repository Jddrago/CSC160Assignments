using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    public class Employee
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int SomeMethod()
        {
            return 5;
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

    }
}
