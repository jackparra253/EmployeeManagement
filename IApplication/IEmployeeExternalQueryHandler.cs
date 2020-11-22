using System.Collections.Generic;
using Entities.DTO;

namespace IApplication
{
    public interface IEmployeeExternalQueryHandler
    {
        List<EmployeeExternal> GetAll();
    }
}