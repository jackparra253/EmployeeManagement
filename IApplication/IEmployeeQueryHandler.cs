using System.Collections.Generic;
using Entities.DTO;

namespace IApplication
{
    public interface IEmployeeQueryHandler
    {
        List<EmployeeDetail> Get();
        EmployeeDetail GetById(int idEmployee);
    }
}