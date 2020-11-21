using System.Collections.Generic;
using Entities.DTO;

namespace IData
{
    public interface IEmployeeExternalService
    {
        List<EmployeeExternal> GetAll();
    }
}