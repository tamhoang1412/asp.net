using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public static class EmployeeManagement
    {
        private static List<Employee> employees = new List<Employee>();
        
        private static void addTeacher()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter coefficients pay: ");
            string coefficientsPayString = Console.ReadLine();
            double coefficientsPay;

            while (!double.TryParse(coefficientsPayString, out coefficientsPay))
            {
                Console.Write("Invalid input! Re-enter: ");
                coefficientsPayString = Console.ReadLine();
            }
            coefficientsPay = double.Parse(coefficientsPayString);
            Console.Write("Enter faculty: ");
            string faculty = Console.ReadLine();
            Console.Write("Enter degree (\"cu nhan\", \"thac si\" or \"tien si\"): ");
            string degree = Console.ReadLine();
            while (!degree.Equals("cu nhan") && !degree.Equals("thac si") && !degree.Equals("tien si"))
            {
                Console.Write("Invalid input! Re-enter: ");
                degree = Console.ReadLine();
            }
            Console.Write("Enter period class number: ");
            string nUnitsString = Console.ReadLine();
            double nUnits;
            while (!double.TryParse(nUnitsString, out nUnits))
            {
                Console.Write("Invalid input! Re-enter: ");
                nUnitsString = Console.ReadLine();
            }
            nUnits = double.Parse(nUnitsString);
            employees.Add(new Teacher(name, coefficientsPay, faculty, degree, nUnits));
        }

        private static void addAdministrativeStaff()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter coefficients pay: ");
            string coefficientsPayString = Console.ReadLine();
            double coefficientsPay;
            while (!double.TryParse(coefficientsPayString, out coefficientsPay))
            {
                Console.Write("Invalid input! Re-enter: ");
                coefficientsPayString = Console.ReadLine();
            }
            coefficientsPay = double.Parse(coefficientsPayString);
            Console.Write("Enter department: ");
            string department = Console.ReadLine();
            Console.Write("Enter position: ");
            string position = Console.ReadLine();
            while (!position.Equals("truong phong") && !position.Equals("pho phong") && !position.Equals("nhan vien"))
            {
                Console.Write("Invalid input! Re-enter: ");
                position = Console.ReadLine();
            }
            Console.Write("Enter period class number: ");
            string nUnitsString = Console.ReadLine();
            double nUnits;
            while (!double.TryParse(nUnitsString, out nUnits))
            {
                Console.Write("Invalid input! Re-enter: ");
                nUnitsString = Console.ReadLine();
            }
            nUnits = double.Parse(nUnitsString);
            employees.Add(new AdministrativeStaff(name, coefficientsPay, department, position, nUnits));
        }

        private static List<AdministrativeStaff> search(String name, String department)
        {
            var admins = from Employee admin in employees
                         where admin.KindOfEmployee.Equals("administrative staff")
                         select admin;
            var searchResult = from AdministrativeStaff admin in admins
                               where ((admin.Name == name) && (admin.Department == department))
                               select admin;
            List<AdministrativeStaff> finalResult = new List<AdministrativeStaff>();
            foreach (AdministrativeStaff admin in searchResult)
            {
                finalResult.Add(admin);
            }
            return finalResult;
        }

        private static void showAllInformationOrderBySalaryAndName()
        {
            var result = from Employee e in employees
                         orderby e.Salary descending, e.Name
                         select e;
            foreach (Employee e in result)
            {
                Console.WriteLine(e.getDetailInformation());
            }
        }

        public static void run()
        {
            bool isFinish = false;
            employees.Add(new AdministrativeStaff("Nam", 1.3, "phong nhan su", "nhan vien", 50));
            employees.Add(new AdministrativeStaff("Lan", 1.3, "phong nhan su", "pho phong", 50));
            employees.Add(new AdministrativeStaff("Quan", 1.3, "phong nhan su", "pho phong", 50));
            employees.Add(new AdministrativeStaff("Bich", 1.3, "phong nhan su", "truong phong", 50));
            employees.Add(new Teacher("Tam", 1.6, "CNTT", "thac si", 100));
            while (!isFinish)
            {
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("Press 1 to add employee infomation\nPress 2 to search an administrative staff (by name and department)");
                Console.WriteLine("Press 3 to show all employees's infomation\nPress others to quit");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("What kind of employee do you want to add?");
                    Console.WriteLine("Press 1 to add teacher\nPress 2 to add administrative staff");
                    string kindOfEmployee = Console.ReadLine();
                    if (kindOfEmployee == "1")
                    {
                        addTeacher();
                    }
                    else if (kindOfEmployee == "2")
                    {
                        addAdministrativeStaff();
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter department: ");
                    string department = Console.ReadLine();
                    List<AdministrativeStaff> admins = search(name, department);
                    if (admins == null)
                    {
                        Console.WriteLine("Not found!");
                    }
                    else
                    {
                        foreach (AdministrativeStaff admin in admins)
                        {
                            Console.WriteLine(admin.getDetailInformation());
                        }
                    }
                }
                else if (choice == "3")
                {
                    showAllInformationOrderBySalaryAndName();
                }
                else
                {
                    isFinish = true;
                }
            }
        }
    }
}
