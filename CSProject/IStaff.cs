using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
