using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.DTO;
using IData;

namespace Application
{
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

            return GetEmployeeDetails(employees, roles);
        }

        private List<EmployeeDetail> GetEmployeeDetails(List<Employee> employees, List<Role> roles)
        {
            return (from employee in employees
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
        }
    }
}