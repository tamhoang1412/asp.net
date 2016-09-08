using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class AdministrativeStaff : Employee
    {
        private string department;
        public string Department { get; set; }

        private string position;
        public string Position { get; set; }

        private double nUnits;
        public double NUnits { get; set; }

        public AdministrativeStaff(string name, double coefficientsPay, string department, string position, double nUnits)
        {
            this.Name = name;
            this.CoefficientsPay = coefficientsPay;
            this.Department = department;
            this.Position = position;
            this.NUnits = nUnits;
            this.calculateAllowance(position);
            this.calculateSalary();
            this.KindOfEmployee = "administrative staff";
        }

        public override void calculateSalary()
        {
            this.Salary = this.CoefficientsPay * 730 + this.Allowance + this.nUnits * 30;
        }

        public override string getDetailInformation()
        {
            return "Name: " + Name
                + "   Allowance: " + Allowance
                + "   Coefficients Pay: " + CoefficientsPay
                + "   Department: " + Department
                + "   Position: " + Position
                + "   Work days: " + NUnits
                + "   Salary: " + Salary;
        }
    }
}
