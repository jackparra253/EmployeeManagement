using System.Collections.Generic;
using Entities.DTO;
using IData;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeExternalController : ControllerBase
    {
        private readonly IEmployeeExternalService _employeeExternalService;

        public EmployeeExternalController(IEmployeeExternalService employeeExternalService)
        {
            _employeeExternalService = employeeExternalService;
        }

        [HttpGet]
        public List<EmployeeExternal> GetList()
        {
            return _employeeExternalService.GetAll();
        }
    }
}
