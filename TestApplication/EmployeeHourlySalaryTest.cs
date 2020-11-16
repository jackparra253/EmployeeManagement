using System.Linq;
using Application;
using Data;
using Entities;
using Entities.DTO;
using IData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApplication
{
    [TestClass]
    public class EmployeeHourlySalaryTest: TestBase
    {
        private EmployeeContext _employeeContext;
        private EmployeeHourlySalary _employeeHourlySalary;

        public EmployeeHourlySalaryTest()
        {
            UseSqlite();
        }

        [TestInitialize]
        public void Initialize()
        {
            _employeeContext = GetDbContext();

            IEmployeeService employeeService = new EmployeeService(_employeeContext);

            _employeeHourlySalary = new EmployeeHourlySalary(employeeService);
        }


        [TestMethod]
        [Description("Should Create Save Employee type Hourly Salary Contract")]
        public void EmployeeHourlySalary()
        {
            var requestEmployeeHourlySalary =
                new RequestEmployeeHourlySalary("Martin", "Fowler", 3, 1_000m, TypeContract.HourlySalary);

            _employeeHourlySalary.Create(requestEmployeeHourlySalary);
            var employess = _employeeContext.Employees.FirstOrDefault();

            Assert.AreEqual(new Money(1_440_000M, Currency.USD), employess.AnnualSalary );
        }
    }
}
