using AL_Ioet.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Ioet.Controller
{
    public class Payment
    {
        /// <summary>
        /// Responsible for obtaining all employees from a file
        /// </summary>
        /// <param name="path">path of employees</param>
        /// <returns>List of employees</returns>
        public List<Employee> getAllEmployees(string path)
        {
            List<Employee> listEmployees = new List<Employee>();
            try
            {
                string[] data = File.ReadAllLines(path);
                foreach (string item in data)
                {
                    List<Schedule> listSchedules = new List<Schedule>();
                    Employee employee = new Employee();
                    string[] infoEmployee = item.Split('=');
                    employee.name = infoEmployee[0];
                    foreach (string info in infoEmployee[1].Split(','))
                    {
                        Schedule schedule = new Schedule();
                        schedule.day = info.Substring(0, 2); 
                        string [] scheduleInfo = info.Substring(2, info.Length - 2).Split('-');
                        schedule.startDay = TimeSpan.Parse(scheduleInfo[0]);
                        schedule.endDay = TimeSpan.Parse(scheduleInfo[1]);
                        listSchedules.Add(schedule);
                    }
                    employee.hoursWorked = listSchedules;
                    listEmployees.Add(employee);
                }
                return listEmployees;
            }catch(Exception e)
            {
                throw new Exception("Error while reading the file, descripción: "+ e.Message);
            }
        }
        /// <summary>
        /// In charge of obtaining the schedule
        /// </summary>
        /// <param name="path">path of schedule</param>
        /// <returns>List of schedule</returns>
        public List<string> getAllSchedule(string path)
        {
            List<string> schedule = new List<string>();
            try
            {
                string [] data = File.ReadAllLines(path);
                foreach (string item in data)
                {
                    string[] line = item.Split(',');
                    schedule.Add(line[0]);
                }
                return schedule;
            }catch(Exception e)
            {
                throw new Exception("Error while reading the file, descripción: " + e.Message);
            }
        }
        /// <summary>
        /// Create a dictionary with time and cost
        /// </summary>
        /// <param name="path">path of schedule</param>
        /// <returns>Dictionary</returns>
        public Dictionary<string,float> getDictionary(string path)
        {
            Dictionary<string, float> dictionary = new Dictionary<string, float>();
            try
            {
                string[] data = File.ReadAllLines(path);
                foreach (string item in data)
                {
                    string[] line = item.Split(',');
                    dictionary.Add(line[0], float.Parse(line[1]));
                }
                return dictionary;
            }
            catch (Exception e)
            {
                throw new Exception("Error while reading the file, descripción: " + e.Message);
            }
        }
    }
}
