using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Globalization;
using WebApi.DataContext;
using WebApi.Models;
using WebApi.Helpers;

namespace WebApi.Service.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {

        private readonly ApplicationDbContext _context;
        private readonly EmployeeServiceHelper _employeeServiceHelper;

        public EmployeeService(ApplicationDbContext context, EmployeeServiceHelper employeeServiceHelper)
        {
            _context = context;
            _employeeServiceHelper = employeeServiceHelper;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try 
            {
                if (newEmployee == null)
                {
                    serviceResponse.Datas = null;
                    serviceResponse.Message = "Report data!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                
                await _context.Employees.AddAsync(newEmployee);
                await _context.SaveChangesAsync();
                    
                serviceResponse.Datas = await _employeeServiceHelper.FindAllAsync();
            }
            catch (Exception ex) 
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try 
            {
                EmployeeModel employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

                if(employee == null)
                {
                    serviceResponse.Datas = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "User not found!";
                    return serviceResponse;
                }

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                serviceResponse.Datas = await _employeeServiceHelper.FindAllAsync();

            }
            catch(Exception ex) 
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id)
        {

            ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                EmployeeModel employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

                if(employee == null) 
                {
                    return _employeeServiceHelper.BadServiceResponse(serviceResponse, "Id not found!");
                }

                serviceResponse.Datas = employee;

            }
            catch(Exception ex) 
            {
                serviceResponse.Success=false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployees()
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                serviceResponse.Datas = await _employeeServiceHelper.FindAllAsync();

                if(serviceResponse.Datas.Count == 0) 
                {
                    serviceResponse.Message = "No data found!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse; 
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> InactiveEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try 
            {

                EmployeeModel employeeModel = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                employeeModel.Active = false;
                employeeModel.DateChange = DateTime.Now;

                _context.Employees.Update(employeeModel);
                await _context.SaveChangesAsync();

                serviceResponse.Datas = await _employeeServiceHelper.FindAllAsync();
            }
            catch(Exception ex) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel editEmployee)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == editEmployee.Id);

                if (employee == null)
                {
                    serviceResponse.Datas = null;
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Id not found!";
                    return serviceResponse;
                }
                
                employee.DateChange = DateTime.Now;
                _context.Employees.Update(editEmployee);
                await _context.SaveChangesAsync();
                serviceResponse.Datas = await _employeeServiceHelper.FindAllAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
