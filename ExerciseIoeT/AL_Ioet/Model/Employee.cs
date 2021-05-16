using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AL_Ioet.Model
{
    public class Employee
    {
        public string name { get; set; }
        public float payment { get; set; }
        public List<Schedule> hoursWorked { get; set; }
        public string paymentPrint()
        {
            return "The amount to pay " + name + " is: " + payment + " USD";
        }
    }
}
