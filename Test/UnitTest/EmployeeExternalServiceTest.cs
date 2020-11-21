using System.Collections.Generic;
using Data;
using Entities.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.UnitTest
{
    [TestClass]
    public class EmployeeExternalServiceTest
    {
        [TestMethod]
        [Description("Should GetAll return List employeeExternal")]
        public void EmployeeExternalService_Case_GetAll()
        {
            var expecteds = CreateExpectListEmployeeExternals();
            var employeeExternalService = new EmployeeExternalService();

            List<EmployeeExternal> employeeExternals = employeeExternalService.GetAll();

            AssertExternalEmployees(expecteds, employeeExternals);
        }

        private List<EmployeeExternal> CreateExpectListEmployeeExternals()
        {
            return new List<EmployeeExternal>
            {
                new EmployeeExternal(1, "Juan", "HourlySalaryEmployee", 1, "Administrator", null, 60000.0m, 80000.0m),
                new EmployeeExternal(2, "Sebastian", "MonthlySalaryEmployee", 2, "Contractor", null, 60000.0m, 80000.0m)
            };
        }

        private void AssertExternalEmployees(List<EmployeeExternal> expecteds, List<EmployeeExternal> employeeExternals)
        {
            for (int i = 0; i < expecteds.Count; i++)
            {
                Assert.AreEqual(expecteds[i].Name, employeeExternals[i].Name);
                Assert.AreEqual(expecteds[i].ContractTypeName, employeeExternals[i].ContractTypeName);
                Assert.AreEqual(expecteds[i].Id, employeeExternals[i].Id);
                Assert.AreEqual(expecteds[i].MonthlySalary, employeeExternals[i].MonthlySalary);
                Assert.AreEqual(expecteds[i].RoleDescription, employeeExternals[i].RoleDescription);
                Assert.AreEqual(expecteds[i].RoleId, employeeExternals[i].RoleId);
                Assert.AreEqual(expecteds[i].RoleName, employeeExternals[i].RoleName);
            }
        }
    }
}
