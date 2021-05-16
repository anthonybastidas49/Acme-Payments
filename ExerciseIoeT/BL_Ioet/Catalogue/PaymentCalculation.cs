using AL_Ioet.Controller;
using AL_Ioet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Ioet.Catalogue
{
    public class PaymentCalculation
    {
        private static  Dictionary<string, float> dictionary;
        private readonly Payment daoEmployee = new Payment();
        /// <summary>
        /// In charge of calculating the payment of employees along with their hours through a schedule
        /// </summary>
        /// <param name="pathEmployees">Employees along with the list of their hours</param>
        /// <param name="pathSchedule">Schedule list</param>
        /// <returns>List of employees with their respective payments</returns>
        public List<Employee> calculatePaymentEmployee(string pathEmployees, string pathSchedule)
        {
            try
            {
                List<Employee> employees = daoEmployee.getAllEmployees(pathEmployees);
                List<string> schedule = daoEmployee.getAllSchedule(pathSchedule);
                dictionary = daoEmployee.getDictionary(pathSchedule);
                foreach (Employee employee in employees)
                {

                    foreach (Schedule scheduleItem in employee.hoursWorked)
                    {
                        foreach (string item in schedule)
                        {
                            employee.payment += paymentByHours(scheduleItem.startDay, scheduleItem.endDay, item, scheduleItem.day);
                        }
                    }
                }
                return employees;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Calculate the payment at a specific time
        /// </summary>
        /// <param name="start">employee start time</param>
        /// <param name="end">employee end time</param>
        /// <param name="schedule">schedule</param>
        /// <param name="day">Workday</param>
        /// <returns></returns>
        public static float paymentByHours(TimeSpan start, TimeSpan end, string schedule, string day)
        {
            float cost = 0;
            int bonusWeekend = 5;
            int hoursWorked = (end - start).Hours;
            try
            {
                string[] data3 = schedule.Split('-');
                TimeSpan startS = TimeSpan.Parse(data3[0]);
                TimeSpan endS = TimeSpan.Parse(data3[1]);
                if (start.Hours >= startS.Hours && end.Hours <= endS.Hours)
                {
                    cost = dictionary[schedule];
                    return day.Contains('S') ? hoursWorked * (cost + bonusWeekend) : hoursWorked * cost;
                }
                else
                {
                    if (start.Hours >= startS.Hours && start.Hours < endS.Hours)
                    {
                        cost = dictionary[schedule];
                        hoursWorked = (endS - start).Hours;
                        String finTRecurrencia = endS.Hours + 9 >= 24 ? "23:59:59" : endS.Hours + 9 + ":00";
                        String inicioRecurrencia = endS.Hours >= 10 ? endS.Hours + ":01" : "0" + endS.Hours + ":01";
                        string scheduleRecurrence = inicioRecurrencia + "-" + finTRecurrencia;
                        return day.Contains('S') ? (hoursWorked * (cost + bonusWeekend)) + paymentByHours(endS, end, scheduleRecurrence, day) : (hoursWorked * cost) + paymentByHours(endS, end, scheduleRecurrence, day);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
