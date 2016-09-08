using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Teacher : Employee
    {
        private string faculty;
        public string Faculty { get; set; }

        private string degree;
        public string Degree { get; set; }

        private double nUnits;
        public double NUnits { get; set; }

        public Teacher(string name, double coefficientsPay, string faculty, string degree, double nUnits)
        {
            this.Name = name;
            this.CoefficientsPay = coefficientsPay;
            this.Faculty = faculty;
            this.Degree = degree;
            this.NUnits = nUnits;
            this.calculateAllowance(degree);
            this.calculateSalary();
            this.KindOfEmployee = "teacher";
        }

        public override void calculateSalary()
        {
            this.Salary = this.CoefficientsPay * 730 + this.Allowance + this.nUnits * 45;
        }

        public override string getDetailInformation()
        {
            return "Name: " + Name
                + "   Allowance: " + Allowance
                + "   Coefficients Pay: " + CoefficientsPay
                + "   Faculty: " + Faculty
                + "   Degree: " + Degree
                + "   Period class number: " + NUnits
                + "   Salary: " + Salary;
        }
    }
}
