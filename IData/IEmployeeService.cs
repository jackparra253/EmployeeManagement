using System.Collections.Generic;
using Entities;

namespace IData
{
    public interface IEmployeeService
    {
        void Save(Employee employee);
        Employee Get(int id);
        List<Employee> GetAll();
    }
}