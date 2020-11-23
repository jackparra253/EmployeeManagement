using System.Collections.Generic;
using Entities.DTO;

namespace IApplication
{
    public interface IEmployeeExternalQueryHandler
    {
        List<EmployeeDetail> GetAll();
        EmployeeDetail GetById(int id);
    }
}