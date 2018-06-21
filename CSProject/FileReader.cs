using System;
using System.Collections.Generic;
using System.IO;

namespace CSProject
{
    public class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[3];
            string path = "staff.txt";
            string[] seperator = {", "};

            if (File.Exists(path))
            {
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        result = reader.ReadLine().Split(seperator, StringSplitOptions.RemoveEmptyEntries);
                        if (result[2] == "Manager")
                            myStaff.Add(new Manager(result[0], result[1]));
                        else if (result[2] == "Admin")
                            myStaff.Add(new Admin(result[0], result[1]));
                    }
                    reader.Close();
                }
            }
            else
                Console.WriteLine("Error: File Does not exist");

            return myStaff;
        }
    }
}
