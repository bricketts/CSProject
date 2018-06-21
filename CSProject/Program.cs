using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fileReader = new FileReader();
            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.WriteLine("\nPlease Enter the Year");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Invalid entry, try again.");
                }
            }

            while (month == 0)
            {
                Console.WriteLine("Please Enter the Month");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Month must be between 1 and 12, try again.");
                        month = 0;
                    }
                        
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "Invalid entry, try again.");
                }
            }

            myStaff = fileReader.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.Write("Enter Hours worked for {0} {1}: ", myStaff[i].FirstName, myStaff[i].LastName);
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip paySlip = new PaySlip(month, year);
            paySlip.GeneratePaySlip(myStaff);
            paySlip.GenerateSummery(myStaff);

            Console.WriteLine("Operation Complete");
            Console.Read();

        }
    }
}
