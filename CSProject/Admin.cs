namespace CSProject
{
    public class Admin : Staff
    {
        
        private const double adminHourlyrate = 30f;
        private const double overtimeRate = adminHourlyrate * 1.5f;

        public double Overtime { get; private set; }

        public Admin(string firstName, string lastName) : base(firstName, lastName, adminHourlyrate)
        {

        }

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
            {                
                Overtime = overtimeRate * (HoursWorked - 160);
            }                

            TotalPay += Overtime; 
            
        }

        public override string ToString()
        {
            return "Name: " + FirstName + " " + LastName +
                   "\nRate: " + adminHourlyrate +
                   "\nHours Worked: " + HoursWorked +
                   "\nBasic Pay: " + BasicPay +
                   "\nOvertime: " + Overtime +
                   "\nTotal Pay: " + TotalPay;
        }
    }
}
