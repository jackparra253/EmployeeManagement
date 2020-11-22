using System.Collections.Generic;
using Entities.DTO;

namespace IApplication
{
    public interface IEmployeeQueryHandler
    {
        List<EmployeeDetail> GetAll();
        EmployeeDetail GetById(int idEmployee);
    }
}