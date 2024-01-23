using Microsoft.Identity.Client;
using System.ComponentModel;
using WebApi.DataContext;
using WebApi.Service;
using System.Collections.Generic;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Specialized;


namespace WebApi.Helpers
{
    public class EmployeeServiceHelper
    {
        private readonly ApplicationDbContext _context;

        public EmployeeServiceHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public ServiceResponse<EmployeeModel> BadServiceResponse(ServiceResponse<EmployeeModel> serviceResponse, string message) 
        {
            serviceResponse.Datas = null;
            serviceResponse.Success = false;
            serviceResponse.Message = message;
            return serviceResponse;
        }

        public async Task<List<EmployeeModel>> FindAllAsync() 
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
