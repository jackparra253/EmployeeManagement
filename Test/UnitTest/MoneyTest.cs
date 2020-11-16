using Entities;
using Entities.Constant;
using Entities.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.UnitTest
{
    [TestClass]
    public class MoneyTest
    {
        [TestMethod]
        [Description("Should Money create to new Money with amount and USD currency.")]
        public void Money_Case_newValueObject()
        {
            decimal amount = 2_500m;
            string currency = Currency.USD;

            var money = new Money(amount, currency);

            Assert.AreEqual(amount, money.Amount);
            Assert.AreEqual(currency, money.Currency);
        }

    }
}
