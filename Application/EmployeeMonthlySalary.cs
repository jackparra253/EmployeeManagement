using System;
using Domain;
using Entities;
using Entities.DTO;
using IData;

namespace Application
{
    public class EmployeeMonthlySalary: EmployeeSalary
    {
        private IEmployeeService _employeeService;

        public EmployeeMonthlySalary(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public override void Create(RequestEmployee requestEmployee)
        {
            var requestEmployeeMonthlySalary = new RequestEmployeeMonthlySalary(requestEmployee.Name,requestEmployee.LastName, requestEmployee.IdRole, requestEmployee.Amount);

            var monthlySalaryContract = new MonthlySalaryContract(new Money(requestEmployeeMonthlySalary.Amount, Currency.USD));

            var employee = new Employee(requestEmployeeMonthlySalary.Name, requestEmployee.LastName, monthlySalaryContract.TypeContract, monthlySalaryContract.Salary, monthlySalaryContract.AnnualSalary, requestEmployeeMonthlySalary.IdRole);

            _employeeService.Save(employee);
        }
    }
}