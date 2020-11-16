using System.Linq;
using Application;
using Data;
using Entities;
using Entities.Constant;
using Entities.DTO;
using Entities.ValueObject;
using IData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.FuntionalTest
{
    [TestClass]
    public class EmployeeMonthlySalaryTest: TestBase
    {
        private EmployeeContext _employeeContext;

        private EmployeeMonthlySalary _employeeMonthlySalary;

        public EmployeeMonthlySalaryTest()
        {
            UseSqlite();
        }

        [TestInitialize]
        public void Initialize()
        {
            _employeeContext = GetDbContext();

            IEmployeeService employeeService = new EmployeeService(_employeeContext);

            _employeeMonthlySalary = new EmployeeMonthlySalary(employeeService);
        }

        [TestMethod]
        [Description("Should Create Save Employee type Monthly Salary Contract")]
        public void EmployeeMonthlySalary_Case_Create()
        {
            var requestEmployee =
                new RequestEmployee("Martin", "Fowler", 3, 2_000m);

            _employeeMonthlySalary.Create(requestEmployee);
            var employee = _employeeContext.Employees.FirstOrDefault();

            Assert.AreEqual(new Money(24_000M, Currency.USD), employee.AnnualSalary);
            Assert.AreEqual(TypeContract.MonthlySalary, employee.TypeContract);
        }
    }
}
