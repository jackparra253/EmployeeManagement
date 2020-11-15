using Domain;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class MonthlySalaryContractTest
    {
        [TestMethod]
        [Description("Should MonthlySalaryContract return TypeContract SalaryMonthly")]
        public void MonthlySalaryContract_Case_TypeContract()
        {
            string typeContract = TypeContract.MonthlySalary;
            var salary = new Money(10_500m, Currency.USD);

            var monthlySalaryContract = new MonthlySalaryContract(salary);

            Assert.AreEqual(typeContract, monthlySalaryContract.TypeContract);
        }

        [TestMethod]
        [Description("Should CalculatedAnnualSalary for TypeContract MonthlySalaryContract")]
        public void MonthlySalaryContract_Case_CalculatedAnnualSalary()
        {
            var expected = new Money(150_000m, Currency.USD);
            var salary = new Money(12_500m, Currency.USD);
            var monthlySalaryContract = new MonthlySalaryContract(salary);

            var annualSalary = monthlySalaryContract.CalculatedAnnualSalary();

            Assert.AreEqual(expected, annualSalary);
        }
    }
}
