using System.Collections.Generic;
using Entities;
using Entities.ValueObject;

namespace IData
{
    public interface IEmployeeService
    {
        void Save(Employee employee);
        Employee Get(int id);
        List<Employee> GetAll();
    }
}