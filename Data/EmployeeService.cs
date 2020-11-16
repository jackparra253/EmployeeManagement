using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using IData;

namespace Data
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeService(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public void Save(Employee employee)
        {
            _employeeContext.Add(employee);
            _employeeContext.SaveChanges();
        }

        public Employee Get(int id)
        {
            Employee employee = _employeeContext.Employees.Where(employee => employee.EmployeeId == id)
                .FirstOrDefault();

            if (employee is null)
                throw new Exception($"Employee with id {id} not exist.");

            return employee;
        }

        public List<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}
