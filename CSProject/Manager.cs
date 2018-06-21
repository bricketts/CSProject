namespace CSProject
{
    public class Manager : Staff
    {
        private const double managerHourlyRate  = 50;

        public int Allowance { get; private set; }

        public Manager(string firstName, string lastName) : base(firstName, lastName, managerHourlyRate)
        {

        }

        public override void CalculatePay()
        {            
            base.CalculatePay();

            Allowance = 1000;

            if (HoursWorked > 160)
            {
                TotalPay = BasicPay + Allowance; 
            }            
        }

        public override string ToString()
        {
            return "Name: " + FirstName + " " + LastName +
                   "\nRate: " + managerHourlyRate +
                   "\nHours Worked: " + HoursWorked +
                   "\nBasic Pay: " + BasicPay +
                   "\nAllowance: " + Allowance +
                   "\nTotal Pay: " + TotalPay;
                   
        }
    }
}
