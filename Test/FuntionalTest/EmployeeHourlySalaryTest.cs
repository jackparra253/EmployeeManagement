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
        public void EmployeeHourlySalary_Case_Create()
        {
            var requestEmployee =
                new RequestEmployee("Martin", "Fowler", 3, 1_000m);

            _employeeHourlySalary.Create(requestEmployee);
            var employee = _employeeContext.Employees.FirstOrDefault();

            Assert.AreEqual(new Money(1_440_000M, Currency.USD), employee.AnnualSalary );
            Assert.AreEqual(TypeContract.HourlySalary, employee.TypeContract);
        }
    }
}
