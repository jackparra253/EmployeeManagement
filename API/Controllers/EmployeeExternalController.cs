using System;
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
        public List<EmployeeDetail> Get()
        {
            return _employeeExternalQueryHandler.GetAll();
        }


        [HttpGet]
        [Route("{id}/employee")]
        public ActionResult<EmployeeDetail> Get(int id)
        {
            try
            {
                return Ok(_employeeExternalQueryHandler.GetById(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
