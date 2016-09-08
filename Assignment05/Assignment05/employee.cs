using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment05
{
    class Employee
    {
        private string fullName;
        public string FullName { get; set; }

        private int birthday;
        public int Birthday { get; set; }

        private double address;
        public double Address { get; set; }

        private double salary;
        public double Salary { get; set; }

        public string getDetailInformation()
        {
            return "Name: " + FullName
                + "   Birthday: " + Birthday
                + "   Address: " + Address
                + "   Salary: " + Salary;
        }
    }
}
