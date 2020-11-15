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
    }
}
