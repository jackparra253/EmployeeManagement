using Domain;
using Entities;
using Entities.DTO;
using IData;

namespace Application
{
    public class EmployeeHourlySalary
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeHourlySalary(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void Create(RequestEmployeeHourlySalary requestEmployeeHourlySalary)
        {
            var hourlySalaryContract = new HourlySalaryContract(new Money( requestEmployeeHourlySalary.Amount, Currency.USD));

            Employee employee = new Employee(requestEmployeeHourlySalary.Name, requestEmployeeHourlySalary.LastName, hourlySalaryContract.TypeContract, hourlySalaryContract.Salary, hourlySalaryContract.AnnualSalary, requestEmployeeHourlySalary.IdRole);

            _employeeService.Save(employee);
        }
    }
}