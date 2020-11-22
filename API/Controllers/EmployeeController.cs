using System.Collections.Generic;
using Entities.DTO;
using IApplication;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeHourlySalary _employeeHourlySalary;
        private readonly IEmployeeMonthlySalary _employeeMonthlySalary;
        private readonly IEmployeeQueryHandler _employeeQueryHandler;

        public EmployeeController(IEmployeeHourlySalary employeeHourlySalary, IEmployeeMonthlySalary employeeMonthlySalary, IEmployeeQueryHandler employeeQueryHandler)
        {
            _employeeHourlySalary = employeeHourlySalary;
            _employeeMonthlySalary = employeeMonthlySalary;
            _employeeQueryHandler = employeeQueryHandler;
        }

        [HttpGet]
        public List<EmployeeDetail> GetAll()
        {
            return _employeeQueryHandler.GetAll();
        }

        [HttpGet]
        [Route("{id}/employee")]
        public EmployeeDetail Get(int id)
        {
            return _employeeQueryHandler.GetById(id);
        }

        [HttpPost]
        [Route("HourlySalary")]
        public void SaveEmployeeHourlySalary(RequestEmployee requestEmployeeHourlySalary)
        {
            _employeeHourlySalary.Create(requestEmployeeHourlySalary);
        }

        [HttpPost]
        [Route("MonthlySalary")]
        public void Save(RequestEmployee requestEmployeeMonthlySalary)
        {
            _employeeMonthlySalary.Create(requestEmployeeMonthlySalary);
        }
    }
}
