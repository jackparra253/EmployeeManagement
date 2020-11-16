using Domain;
using Entities;
using Entities.DTO;
using IData;

namespace Application
{
    public class EmployeeHourlySalary:  EmployeeSalary
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeHourlySalary(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public override void Create(RequestEmployee requestEmployee)
        {
            var requestEmployeeHourlySalary = new RequestEmployeeHourlySalary(requestEmployee.Name, requestEmployee.LastName, requestEmployee.IdRole,requestEmployee.Amount); 

            var hourlySalaryContract = new HourlySalaryContract(new Money(requestEmployeeHourlySalary.Amount, Currency.USD));

            Employee employee = new Employee(requestEmployeeHourlySalary.Name, requestEmployeeHourlySalary.LastName, hourlySalaryContract.TypeContract, hourlySalaryContract.Salary, hourlySalaryContract.AnnualSalary, requestEmployeeHourlySalary.IdRole);

            _employeeService.Save(employee);
        }
    }
}