using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_Overload
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee() { FirstName = "Sample", LastName = "Student" };
            employee.SayName();

            IQuitabble iQuit = new Employee();

            iQuit.Quit();

            Employee peter = new Employee();
            peter.FirstName = "Peter";
            peter.LastName = "Pan";
            peter.Id = 12345;

            Employee wendy = new Employee();
            wendy.FirstName = "Wendy";
            wendy.LastName = "Darling";
            wendy.Id = 12345;

            if (peter == wendy)
            {
                Console.WriteLine("Employee Id is the same");
            }
            else
            {
                Console.WriteLine("Employee Id is not the same");
            }

            Console.ReadLine();
        }
    }
}
