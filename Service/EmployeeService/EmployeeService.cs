﻿using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebApi.DataContext;
using WebApi.Models;

namespace WebApi.Service.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {

        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
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
                    
                serviceResponse.Datas = await _context.Employees.ToListAsync();
            }
            catch (Exception ex) 
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id)
        {

            ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                if(id == 0) 
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Not found this id!";
                    serviceResponse.Datas = null;
                    return serviceResponse;
                }

                serviceResponse.Datas = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            }
            catch(Exception ex) 
            {

            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployees()
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                serviceResponse.Datas = await _context.Employees.ToListAsync();

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

        public Task<ServiceResponse<List<EmployeeModel>>> InactiveEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel editEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
