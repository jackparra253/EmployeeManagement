using System.Collections.Generic;
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
    public class EmployeeQueryHandlerTest: TestBase
    {
        private EmployeeContext _employeeContext;
        private EmployeeQueryHandler _employeeQueryHandler;

        public EmployeeQueryHandlerTest()
        {
            UseSqlite();
        }

        [TestInitialize]
        public void Initialize()
        {
            _employeeContext = GetDbContext();

            IEmployeeService employeeService = new EmployeeService(_employeeContext); 
            IRoleServiceFake roleService = new RoleServiceFake();

             _employeeQueryHandler = new EmployeeQueryHandler(employeeService, roleService);
        }

        [TestMethod]
        [Description("Should Get Return all Employee")]
        public void EmployeeQueryHandler_Case_Get()
        {
            CreateEmployeesInMemory();
            List<EmployeeDetail> expected = CreateEmployeesDetail();

            List<EmployeeDetail> employeeDetails = _employeeQueryHandler.GetAll();

            AssertEmployeesDetails(expected, employeeDetails);
        }

        [TestMethod]
        public void EmployeeQueryHandler_Case_GetById()
        {
            CreateEmployeesInMemory();
            EmployeeDetail expected = new EmployeeDetail(2,
                "Jack",
                "Parra Murillo",
                TypeContract.MonthlySalary,
                new Money(15_000m, Currency.USD),
                new Money(180_000m, Currency.USD),
                "Software developer",
                "a person who writes computer programs");

            EmployeeDetail employeeDetail = _employeeQueryHandler.GetById(2);

            Assert.AreEqual(expected.Name, employeeDetail.Name);
            Assert.AreEqual(expected.LastName, employeeDetail.LastName);
            Assert.AreEqual(expected.RoleName, employeeDetail.RoleName);
            Assert.AreEqual(expected.RoleDescriptrion, employeeDetail.RoleDescriptrion);
            Assert.AreEqual(expected.Salary, employeeDetail.Salary);
            Assert.AreEqual(expected.AnnualSalary, employeeDetail.AnnualSalary);
            Assert.AreEqual(expected.TypeContract, employeeDetail.TypeContract);
        }


        private List<EmployeeDetail> CreateEmployeesDetail()
        {
            return new List<EmployeeDetail>
            {
                new EmployeeDetail(1,
                    "Carlos Augusto",
                    "Parra Velasquez",
                    TypeContract.MonthlySalary,
                    new Money(10_000m, Currency.USD),
                    new Money(120_000m,Currency.USD),
                    "Video game developer",
                    "a person or business involved in video game development, the process of designing and creating games"),
                new EmployeeDetail(2,
                    "Jack",
                    "Parra Murillo",
                    TypeContract.MonthlySalary,
                    new Money(15_000m, Currency.USD),
                    new Money(180_000m,Currency.USD),
                    "Software developer",
                    "a person who writes computer programs"),
                new EmployeeDetail(3,
                    "Carlos",
                    "Parra Murillo",
                    TypeContract.MonthlySalary,
                    new Money(15_000m, Currency.USD),
                    new Money(180_000m,Currency.USD),
                    "",
                    "")
            };
        }

        private static void AssertEmployeesDetails(List<EmployeeDetail> expected, List<EmployeeDetail> employeeDetails)
        {
            for (int i = 0; i < employeeDetails.Count; i++)
            {
                Assert.AreEqual(expected[i].Name, employeeDetails[i].Name);
                Assert.AreEqual(expected[i].LastName, employeeDetails[i].LastName);
                Assert.AreEqual(expected[i].RoleName, employeeDetails[i].RoleName);
                Assert.AreEqual(expected[i].RoleDescriptrion, employeeDetails[i].RoleDescriptrion);
                Assert.AreEqual(expected[i].Salary, employeeDetails[i].Salary);
                Assert.AreEqual(expected[i].AnnualSalary, employeeDetails[i].AnnualSalary);
                Assert.AreEqual(expected[i].TypeContract, employeeDetails[i].TypeContract);
            }
        }

        private void CreateEmployeesInMemory()
        {
            var employees = new List<Employee>
            {
                new Employee("Carlos Augusto", "Parra Velasquez", TypeContract.MonthlySalary,
                    new Money(10_000m, Currency.USD), new Money(120_000m, Currency.USD), 4),
                new Employee("Jack", "Parra Murillo", TypeContract.MonthlySalary,
                    new Money(15_000m, Currency.USD), new Money(180_000m, Currency.USD), 3),
                new Employee("Carlos", "Parra Murillo", TypeContract.MonthlySalary,
                    new Money(15_000m, Currency.USD), new Money(180_000m, Currency.USD), 5)
            };

            _employeeContext.AddRange(employees);
            _employeeContext.SaveChanges();
        }
    }
}
