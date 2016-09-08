using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace Assignment05
{
    static class EmployeeManagement
    {
        private static SqlConnection myConnection;
        private static void openDatabaseConnectTion(string server, string database, string userId, string password)
        {
            myConnection = new SqlConnection("user id="+ userId +";" +
                                       "password=" + password + ";server=" + server + ";" +
                                       "Trusted_Connection=yes;" +
                                       "database=" + database +"; " +
                                       "connection timeout=30");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void closeDatabaseConnection()
        {
            try
            {
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void showAllEmployeesInformation()
        {
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from employees", myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine("Id: "+ myReader["id"].ToString()
                        + "  Full name: " + myReader["full_name"].ToString()
                        + "  Birthday: " + myReader["birthday"].ToString()
                        + "  Address: " + myReader["address"].ToString()
                        + "  Salary: " + myReader["salary"].ToString()
                        );
                }
                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void showHusbandAndWife()
        {
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("HusbandAndWife", myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine("Husband: " + myReader["full_name"].ToString()
                        + "  Wife: " + myReader["wife"].ToString()
                        );
                }
                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void addNewEmployee(string full_name, DateTime birthday, string address, double salary)
        {
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "INSERT INTO employees (full_name, birthday, address, salary) VALUES('"
            //    + full_name +"', '" + birthday + "', '" + address + "', " + salary + "); ";
            //cmd.CommandType = CommandType.Text;
            //cmd.Connection = myConnection;
            //cmd.Parameters.AddWithValue("@full_name", SqlDbType.Text);
            //cmd.Parameters.AddWithValue("@birthday", SqlDbType.Date);
            //cmd.Parameters.AddWithValue("@address", SqlDbType.Text);
            //cmd.Parameters.AddWithValue("@salary", SqlDbType.Text);
            //cmd.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand("AllEmployee", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@full_name", full_name);
            cmd.Parameters.AddWithValue("@birthday", birthday);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.ExecuteNonQuery();

        }

        private static void testDataSet()
        {
            DataSet dbEmployee = new DataSet();
            DataSet dbEmployee2 = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter("select * from employees", myConnection);
            adapter.Fill(dbEmployee, "employees");
            adapter.Fill(dbEmployee2, "employees");

            SqlDataAdapter adapter2 = new SqlDataAdapter("select * from wifes", myConnection);
            adapter2.Fill(dbEmployee, "wifes");
            adapter2.Fill(dbEmployee2, "wifes");

            Console.WriteLine(dbEmployee.Tables["employees"].Rows[2][3]);
            Console.WriteLine(dbEmployee.Tables["wifes"].Rows[3][1]);

            Console.WriteLine(dbEmployee.Tables["employees"].Rows[2][3]);
            Console.WriteLine(dbEmployee2.Tables["wifes"].Rows[2][1]);

        }
        public static void run()
        {
            openDatabaseConnectTion("localhost", "SmartOSC", "sa", "longlitlacmong");
            bool isFinish = false;
            while (!isFinish)
            {
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("Press 1 to add employee infomation\nPress 2 to show all employee's infomation");
                Console.WriteLine("Press 3 to testDataSet");
                Console.WriteLine("Press others to quit");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Write("Enter full name: ");
                    string full_name = Console.ReadLine();
                    Console.Write("Enter birday (yyyy-mm-dd): ");
                    string birthdayString = Console.ReadLine();
                    DateTime birthday;
                    while(!DateTime.TryParse(birthdayString, out birthday))
                    {
                        Console.Write("Invalid input! Re-enter: ");
                        birthdayString = Console.ReadLine();
                    }
                    birthday = DateTime.Parse(birthdayString);
                    Console.Write("Enter address: ");
                    string address = Console.ReadLine();
                    Console.Write("Enter salary: ");
                    string salaryString = Console.ReadLine();
                    double salary;
                    while (!double.TryParse(salaryString, out salary))
                    {
                        Console.Write("Invalid input! Re-enter: ");
                        salaryString = Console.ReadLine();
                    }
                    salary = Double.Parse(salaryString);
                    addNewEmployee(full_name, birthday, address, salary);
                }
                else if (choice == "2")
                {
                    //showAllEmployeesInformation();
                    showHusbandAndWife();
                }
                else if (choice == "3")
                {
                    testDataSet();
                }
                else
                {
                    isFinish = true;
                    closeDatabaseConnection();
                }
            }

        }
    }
}
