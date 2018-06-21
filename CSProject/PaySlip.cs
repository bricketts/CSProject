using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1, FEB = 2, MAR = 3,
            APR = 4, MAY = 5, JUNE = 6,
            JUL = 7, AUG = 8, SEPT = 9,
            OCT = 10, NOV = 11, DEC = 12
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff staff in myStaff)
            {
                path = staff.LastName + ".txt";

                using (var writer = new StreamWriter(path))
                {
                    writer.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                    writer.WriteLine("===================================");
                    writer.WriteLine("Name of Staff: {0} {1}", staff.FirstName, staff.LastName);
                    writer.WriteLine("Hours Worked: {0}", staff.HoursWorked);
                    writer.WriteLine("");
                    writer.WriteLine("Basic Pay: {0}", staff.BasicPay);

                    if (staff.GetType() == typeof(Manager))
                        writer.WriteLine("Allowance {0:C}", ((Manager)staff).Allowance);
                    else if (staff.GetType() == typeof(Admin))
                        writer.WriteLine("Overtime {0:C}", ((Admin)staff).Overtime);

                    writer.WriteLine("");
                    writer.WriteLine("===================================");
                    writer.WriteLine("Total Pay: {0:C}", staff.TotalPay);

                    writer.Close();
                }
            }
        }

        public void GenerateSummery(List<Staff> myStaff)
        {

            var fullTimeStaff = myStaff.Where(s => s.HoursWorked > 80);
            var partTimeStaff = myStaff.Where(p => p.HoursWorked < 80);
                        
            string path = "summary.txt";

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine("Fulltime staff: ");
                writer.WriteLine("");

                foreach (var member in fullTimeStaff)
                {
                    writer.WriteLine("Name: {1}, {0}. Hours Worked: {2}", member.FirstName,
                                                                         member.LastName,
                                                                         member.HoursWorked);
                }

                writer.WriteLine("");
                writer.WriteLine("Parttime Staff: ");
                writer.WriteLine("");

                foreach (var member in partTimeStaff)
                    writer.WriteLine("Name: {1}, {0}. Hours Worked: {2}", member.FirstName, 
                                                                         member.LastName, 
                                                                         member.HoursWorked);

                writer.Close();
            }
        }

        public override string ToString()
        {
            return "Month = " + month +
                   " Year = " + year;
        }

    }
}
