using System.Collections.Generic;
using Entities.DTO;
using IApplication;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeExternalController : ControllerBase
    {
        private readonly IEmployeeExternalQueryHandler _employeeExternalQueryHandler;

        public EmployeeExternalController(IEmployeeExternalQueryHandler employeeExternalQueryHandler)
        {
            _employeeExternalQueryHandler = employeeExternalQueryHandler;
        }

        [HttpGet]
        public List<EmployeeExternal> GetList()
        {
            return _employeeExternalQueryHandler.GetAll();
        }
    }
}
