using WebApi.Models;

namespace WebApi.Service.EmployeeService
{
    public interface IEmployeeInterface
    {
        Task<ServiceResponse<List<EmployeeModel>>> GetEmployees();
        Task<ServiceResponse<List<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee);
        Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id);
        Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel editEmployee);
        Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id);
        Task<ServiceResponse<List<EmployeeModel>>> InactiveEmployee(int id);
    }
}
