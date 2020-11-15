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
            Money salary = new Money(30_000, Currency.USD);
            //TypeContract

        }
    }
}
