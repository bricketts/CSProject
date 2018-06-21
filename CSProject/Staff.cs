using System;

namespace CSProject
{
    public class Staff : IStaff
    {
        private double hourlyRate;
        private int hoursWorked;
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double BasicPay { get; protected set; }
        public double TotalPay { get; protected set; }        

        public int HoursWorked
        {
            get
            {
                return hoursWorked;
            }
            set
            {
                if (value > 0) hoursWorked = value; else hoursWorked = 0;
            }
        }

        public Staff(string firstName, string lastName, double rate)
        {
            FirstName = firstName;
            LastName = lastName;
            hourlyRate = rate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");

            if (hoursWorked > 160)
            {
                BasicPay = 160 * hourlyRate;
            }
            else
            {
                BasicPay = hoursWorked * hourlyRate;
            }

            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "Name: " + FirstName + " " + LastName +
                   "\nRate: " + hourlyRate +
                   "\nHours Worked: " + HoursWorked + 
                   "\nBasic Pay: " + BasicPay + 
                   "\nTotal Pay: " + TotalPay;
        }
    }
}
