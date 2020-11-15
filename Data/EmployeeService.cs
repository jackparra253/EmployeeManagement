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
    }
}
