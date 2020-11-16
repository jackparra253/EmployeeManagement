using Domain;
using Entities;
using Entities.Constant;
using Entities.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.UnitTest
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        [Description("Should Employee create to new instance Employee")]
        public void Employee_Case_newEmployee()
        {
            string name = "Alan";
            string lastName = "Turing";
            var salary = new Money(5_000m, Currency.USD);
            var salaryContract = new MonthlySalaryContract(salary);
            var employee = new Employee(name, lastName, salaryContract.TypeContract, salary, salaryContract.AnnualSalary, 2);

            Assert.AreEqual(name, employee.Name);
            Assert.AreEqual(lastName, employee.LastName);
            Assert.AreEqual(new Money(60_000m ,Currency.USD), employee.AnnualSalary);
            Assert.AreEqual(salary, employee.Salary);
            Assert.AreEqual(salaryContract.TypeContract, employee.TypeContract);
            Assert.AreEqual(2, employee.IdRole);
        }
    }
}
