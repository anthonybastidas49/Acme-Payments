using AL_Ioet.Controller;
using AL_Ioet.Model;
using BL_Ioet.Catalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestPayments
{
    [TestClass]
    public class UnitTest1
    {
        string pathEmployees = @"../../../../AL_Ioet/Files/Employees.txt";
        string pathSchedule = @"../../../../AL_Ioet/Files/Schedule.txt";
        [TestMethod]
        public void TestMethod1()
        {
            Payment payment = new Payment();
            List<Employee> employees = payment.getAllEmployees(pathEmployees);
            Assert.IsNotNull(employees);
            Assert.AreEqual(5, employees.Count);
            List<string> schedules = payment.getAllSchedule(pathSchedule);
            Assert.IsNotNull(schedules);
            Assert.AreEqual(3, schedules.Count);
            Dictionary<string, float> dictionary = payment.getDictionary(pathSchedule);
            Assert.AreEqual(20,dictionary["18:01-23:59:59"]);
        }
        [TestMethod]
        public void TestMethod2()
        {
            PaymentCalculation payment = new PaymentCalculation();
            List<Employee> employees = payment.calculatePaymentEmployee(pathEmployees, pathSchedule);
            Assert.IsNotNull(employees);
            Assert.AreEqual(215, employees[0].payment);
            Assert.AreEqual(85, employees[1].payment);
            Assert.AreEqual(165, employees[2].payment);
            Assert.AreEqual(345, employees[3].payment);
            Assert.AreEqual(640, employees[4].payment);
        }
    }
}
