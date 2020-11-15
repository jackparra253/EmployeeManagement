using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class HourlySalaryContractTest
    {
        [TestMethod]
        [Description("Should HourlySalary return TypeContract HourlySalary")]
        public void HourlySalary_Case_TypeContract()
        {
            string typeContract = TypeContract.HourlySalary;
            var salary = new Money(1_150m, Currency.USD);

            var hourlySalary = new HourlySalaryContract(salary);

            Assert.AreEqual(typeContract, hourlySalary.TypeContract);
        }

        [TestMethod]
        [Description("Should CalculatedAnnualSalary for TypeContract Hourly")]
        public void HourlySalary_Case_CalculatedAnnualSalary()
        {
            var expected = new Money(1_656_000m, Currency.USD);
            var salary = new Money(1_150m, Currency.USD);
            var hourlySalary = new HourlySalaryContract(salary);

            var annualSalary = hourlySalary.CalculatedAnnualSalary();

            Assert.AreEqual(expected.Amount, annualSalary.Amount);
            Assert.AreEqual(expected.Currency, annualSalary.Currency);
        }

    }
}
