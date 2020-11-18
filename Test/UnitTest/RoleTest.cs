using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.UnitTest
{
    [TestClass]
    public class RoleTest
    {
        [TestMethod]
        [Description("Should Role create to new instance role")]
        public void Role_Case_NewObject()
        {
            var id = 1;
            string name = "Developer";
            string description = "Developer back end";

            var role = new Role(id, name, description);

            Assert.AreEqual(id, role.Id);
            Assert.AreEqual(name, role.Name);
            Assert.AreEqual(description, role.Description);
        }
    }
}
