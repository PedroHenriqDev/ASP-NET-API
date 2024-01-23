using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DataContext;
using WebApi.Models;
using WebApi.Service;
using WebApi.Service.EmployeeService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeInterface _employeeInterface;

        public EmployeeController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployees()
        {
            return Ok(await _employeeInterface.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> GetEmployeeById(int id) 
        {

            return Ok(await _employeeInterface.GetEmployeeById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> CreateEmployee(EmployeeModel newEmployee)
        {
            return Ok(await _employeeInterface.CreateEmployee(newEmployee));
        }

        [HttpPut("Inactive employee")]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> InactiveEmployee(int id) 
        {
            return Ok(await _employeeInterface.InactiveEmployee(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> UpdateEmployee(EmployeeModel editEmployee) 
        {
            return Ok(await _employeeInterface.UpdateEmployee(editEmployee));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> DeleteEmployee(int id) 
        {
            return Ok(await _employeeInterface.DeleteEmployee(id));
        }
    }
}
