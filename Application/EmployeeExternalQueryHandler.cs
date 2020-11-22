using System.Collections.Generic;
using Entities.DTO;
using IApplication;
using IData;

namespace Application
{
    public class EmployeeExternalQueryHandler : IEmployeeExternalQueryHandler
    {
        private readonly IEmployeeExternalService _employeeExternalService;

        public EmployeeExternalQueryHandler(IEmployeeExternalService employeeExternalService)
        {
            _employeeExternalService = employeeExternalService;
        }

        public List<EmployeeExternal> GetAll()
        {
            return _employeeExternalService.GetAll();
        }

    }
}
