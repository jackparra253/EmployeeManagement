using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Entities.Constant;
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
        [Description("Should Get Return Employee by Id")]
        public void EmployeeQueryHandler_Case_GetById()
        {
            var employees = new List<Employee>
            {
                new Employee("Carlos Augusto", "Parra Velasquez", TypeContract.MonthlySalary,
                    new Money(10_000m, Currency.USD), new Money(120_000m,Currency.USD), 4),
                new Employee("Jack", "Parra Murillo", TypeContract.MonthlySalary,
                    new Money(15_000m, Currency.USD), new Money(180_000m,Currency.USD), 3),
                new Employee("Carlos", "Parra Murillo", TypeContract.MonthlySalary,
                    new Money(15_000m, Currency.USD), new Money(180_000m,Currency.USD), 5)
            };

            _employeeContext.AddRange(employees);
            _employeeContext.SaveChanges();
            
            List<EmployeeDetail> expected = new List<EmployeeDetail>
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


            List<EmployeeDetail> employeeDetails = _employeeQueryHandler.Get();

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
    }

    public class EmployeeQueryHandler
    {
        private IEmployeeService _employeeService;
        private IRoleServiceFake _roleService;

        public EmployeeQueryHandler(IEmployeeService employeeService, IRoleServiceFake roleService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
        }

        public List<EmployeeDetail> Get()
        {
            List<Role> roles = _roleService.GetAll();

            List<Employee> employees = _employeeService.GetAll();

            List<EmployeeDetail> employeeDetails = (from employee in employees
                join role in roles on employee.IdRole equals role.Id into ed
                from employeeWithDetail in ed.DefaultIfEmpty()
                select new EmployeeDetail(
                    employee.EmployeeId,
                    employee.Name,
                    employee.LastName,
                    employee.TypeContract,
                    employee.Salary,
                    employee.AnnualSalary,
                    employeeWithDetail?.Name ?? string.Empty,
                    employeeWithDetail?.Description ?? string.Empty)).ToList();

            return employeeDetails;
        }
    }

    public class EmployeeDetail
    {
        public int EmployeeId { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string TypeContract { get; private set; }
        public Money Salary { get; private set; }
        public Money AnnualSalary { get; private set; }
        public string RoleName { get; private set; }
        public string RoleDescriptrion { get; private set; }

        public EmployeeDetail(int employeeId, string name, string lastName, string typeContract, Money salary, Money annualSalary, string roleName, string roleDescriptrion)
        {
            EmployeeId = employeeId;
            Name = name;
            LastName = lastName;
            TypeContract = typeContract;
            Salary = salary;
            AnnualSalary = annualSalary;
            RoleName = roleName;
            RoleDescriptrion = roleDescriptrion;
        }
    }


}
