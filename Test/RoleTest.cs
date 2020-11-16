using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class RoleTest
    {
        [TestMethod]
        [Description("Should Role create to new instance role")]
        public void TestMethod1()
        {
            string name = "Developer";
            string description = "Developer back end";

            var role = new Role(name, description);

            Assert.AreEqual(name, role.Name);
            Assert.AreEqual(description, role.Description);
        }
    }
}
