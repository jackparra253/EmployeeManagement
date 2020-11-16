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
            string name = "Alan";
            string lastName = "Turing";
            var salary = new Money(5_000m, Currency.USD);
            var salaryContract = new MonthlySalaryContract(salary);
            var alanTuring = new Employee(name, lastName, salaryContract.TypeContract, salary, salaryContract.AnnualSalary, 2);

            _employeeService.Save(alanTuring);
            Employee employee = _employeeContext.Employees.FirstOrDefault();


            Assert.AreEqual(alanTuring.Name, employee.Name);
            Assert.AreEqual(alanTuring.AnnualSalary, employee.AnnualSalary);
        }

        [TestMethod]
        [Description("Should Get return Employee to Id")]
        public void EmployeeService_Case_Get()
        {
            string name = "Alan";
            string lastName = "Turing";
            var salary = new Money(5_000m, Currency.USD);
            var salaryContract = new MonthlySalaryContract(salary);
            var alanTuring = new Employee(name, lastName, salaryContract.TypeContract, salary, salaryContract.AnnualSalary, 2);

            _employeeService.Save(alanTuring);
            int id = 1;
            Employee employee = _employeeService.Get(id);


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

    }
}
