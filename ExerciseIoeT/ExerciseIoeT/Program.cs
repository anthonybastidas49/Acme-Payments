using AL_Ioet.Model;
using BL_Ioet.Catalogue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseIoeT
{
    class Program
    {
        private static readonly PaymentCalculation payment = new PaymentCalculation();
        static void Main(string[] args)
        {
            try
            {
                string pathEmployees = @"../../../AL_Ioet/Files/Employees.txt";
                string pathSchedule = @"../../../AL_Ioet/Files/Schedule.txt";
                List<Employee> payments = payment.calculatePaymentEmployee(pathEmployees, pathSchedule);
                foreach (Employee employee in payments)
                {
                    Console.WriteLine(employee.paymentPrint());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred in the program.");
                Console.WriteLine("Description: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}
