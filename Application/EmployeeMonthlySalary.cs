﻿using Domain;
using Entities;
using Entities.Constant;
using Entities.DTO;
using Entities.ValueObject;
using IApplication;
using IData;

namespace Application
{
    public class EmployeeMonthlySalary: EmployeeSalary, IEmployeeMonthlySalary
    {
        private IEmployeeService _employeeService;

        public EmployeeMonthlySalary(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public override void Create(RequestEmployee requestEmployee)
        {
            var requestEmployeeMonthlySalary = new RequestEmployeeMonthlySalary(requestEmployee);

            var salary = new Money(requestEmployeeMonthlySalary.Amount, Currency.USD);

            var monthlySalaryContract = new MonthlySalaryContract(salary);

            var employee = new Employee(requestEmployeeMonthlySalary.Name, requestEmployee.LastName, monthlySalaryContract.TypeContract, monthlySalaryContract.Salary, monthlySalaryContract.AnnualSalary, requestEmployeeMonthlySalary.IdRole);

            _employeeService.Save(employee);
        }
    }
}