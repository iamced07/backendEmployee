using core.Response;
using data.Repository;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace core.Services
{
    public interface IEmployeeServices
    {
        public Task<generalModel> getEmployeeList(string employeeName);
        public Task<generalModel> deleteEmployee(int employeeId);
    }
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepo employeeRepo;
        private readonly IgeneralResponse response;

        public EmployeeServices(IEmployeeRepo emp, IgeneralResponse resp)
        {
            employeeRepo = emp;
            response = resp;
        }

        public async Task<generalModel> deleteEmployee(int employeeId)
        {
            var deletedEmployee = await employeeRepo.DeleteEmployee(employeeId);
            return response.response(deletedEmployee, true, "number of deleted employee successfully loaded", StatusCodes.Status200OK);
        }

        public async Task<generalModel> getEmployeeList(string employeeName)
        {
            var list =  await employeeRepo.getEmployeeList(employeeName);
            return response.response(list, true, "record successfully loaded", StatusCodes.Status200OK);
        }
    }
}
