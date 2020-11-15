using Domain;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        [Description("Should Employee create to new instance Employee")]
        public void TestMethod1()
        {
            string name = "Alan";
            string lastName = "Turing";
            var salary = new Money(5_000m, Currency.USD);
            ISalaryContract salaryContract = new MonthlySalaryContract(salary);

            var employee = new Employee(name, lastName, salaryContract);

            Assert.AreEqual(name, employee.Name);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(new Money(60_000m ,Currency.USD), employee.SalaryContract.CalculatedAnnualSalary());
        }
    }
}
