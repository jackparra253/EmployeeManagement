using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Domain;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class EmployeeServiceTest : TestBase
    {
        private EmployeeContext _employeeContext;
        private EmployeeService _employeeService;

        public EmployeeServiceTest()
        {
            UseSqlite();
        }

        [TestInitialize]
        public void Initialize()
        {
            _employeeContext = GetDbContext();
            _employeeService = new EmployeeService(_employeeContext);
        }

        [TestMethod]
        [Description("Should Save add and save to Employee")]
        public void EmployeeService_Case_Save()
        {
            var alanTuring = new Employee("Alan", "Turing", TypeContract.MonthlySalary, new Money(5_000m, Currency.USD), new Money(60_000m, Currency.USD), 2);

            _employeeService.Save(alanTuring);
            Employee employee = _employeeContext.Employees.FirstOrDefault();


            Assert.AreEqual(alanTuring.Name, employee.Name);
            Assert.AreEqual(alanTuring.AnnualSalary, employee.AnnualSalary);
        }

        [TestMethod]
        [Description("Should Get return Employee to Id")]
        public void EmployeeService_Case_Get()
        {
            var alanTuring = new Employee("Alan", "Turing", TypeContract.MonthlySalary, new Money(5_000m, Currency.USD), new Money(60_000m, Currency.USD), 2);

            _employeeService.Save(alanTuring);
            Employee employee = _employeeService.Get(1);

            Assert.AreEqual(alanTuring.Name, employee.Name);
            Assert.AreEqual(alanTuring.AnnualSalary, employee.AnnualSalary);
        }

        [TestMethod]
        [Description("Should Get return exception when Employee not exist")]
        public void EmployeeService_Case_GetExeption()
        {
            string messageExpect = "Employee with id 2 not exist.";

            string  message = Assert.ThrowsException<Exception>(() => _employeeService.Get(2)).Message;

            Assert.AreEqual(messageExpect, message);
        }

        [TestMethod]
        [Description("Should GetAll return all Employees")]
        public void EmployeeService_Case_GetAll()
        {
            List<Employee> expected = CreateEmployeesInMemory();

            List<Employee> employees = _employeeService.GetAll();

            Assert.AreEqual(expected.Count, employees.Count);
        }

        private List<Employee> CreateEmployeesInMemory()
        {
            var alanTuring = new Employee("Alan", "Turing", TypeContract.MonthlySalary, new Money(5_000m, Currency.USD), new Money(60_000m, Currency.USD), 2);
            var uncleBob = new Employee("Alan", "Turing", TypeContract.MonthlySalary, new Money(4_000m, Currency.USD), new Money(48_000m, Currency.USD), 2);

            var employees = new List<Employee> { alanTuring, uncleBob };

            _employeeContext.AddRange(employees);
            _employeeContext.SaveChanges();

            return employees;
        }

        [TestMethod]
        [Description("Should GetAll return list empty when not exists Employees")]
        public void EmployeeService_Case_GetAll_ListEmpty()
        {
            List<Employee> employees = _employeeService.GetAll();

            Assert.AreEqual(0, employees.Count);
        }
    }
}
