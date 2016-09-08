using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    abstract class Employee
    {
        private string name;
        public string Name { get; set; }

        private int allowance;
        public int Allowance {get; set; }

        private double coefficientsPay;
        public double CoefficientsPay { get; set; }

        private double salary;
        public double Salary { get; set; }

        private string kindOfEmployee = "";
        public string KindOfEmployee { get; set; }

        protected void calculateAllowance(string level)
        {
            switch (level)
            {
                case "cu nhan":
                    this.Allowance = 300;
                    break;
                case "thac si":
                case "nhan vien":
                    this.Allowance = 500;
                    break;
                case "tien si":
                case "pho phong":
                    this.Allowance = 1000;
                    break;
                case "truong phong":
                    this.Allowance = 2000;
                    break;
            }
        }

        public abstract void calculateSalary();
        public virtual string getDetailInformation()
        {
            return "Name: " + Name
                + "   Allowance: " + Allowance
                + "   Coefficients Pay: " + CoefficientsPay
                + "   Salary: " + Salary;
        }
    }
}
