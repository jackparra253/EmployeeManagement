using System;
using System.Linq;
using Entities;

namespace Data
{
    public class EmployeeService
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
    }
}
