namespace CSProject
{
    interface IStaff
    {

        string FirstName { get; }
        string LastName { get; }
        int HoursWorked { get; set; }
        double BasicPay { get; }
        double TotalPay { get; }

        void CalculatePay();

        string ToString();

    }
}
