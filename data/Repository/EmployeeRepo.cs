using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace data.Repository
{
    public interface IEmployeeRepo
    {
        public Task<List<Employee>>  getEmployeeList(string employeeName);
        public Task<int>DeleteEmployee(int empId);
    }
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeContext context;

        //initialized Context
        public EmployeeRepo(EmployeeContext cn)
        {
            context = cn;
        }
        public async Task<List<Employee>> getEmployeeList(string employeeName)
        {
            List<Employee> list;
            if (employeeName != null)
            {
                list = await (from emp in context.Employees
                              orderby emp.EmployeeName
                              where employeeName.Contains(emp.EmployeeName)
                              select emp).ToListAsync();
            }
            else
            {
                list = await (from emp in context.Employees
                                             orderby emp.EmployeeName
                                             select emp).ToListAsync();
            }
           
            return list;
        }

        public async Task<int> DeleteEmployee(int empId)
        {
            Employee itemDel = await (from emp in context.Employees
                                         where emp.EmployeeId == empId
                                         select emp).SingleOrDefaultAsync();
            context.Employees.Remove(itemDel);
            return await context.SaveChangesAsync();
           
        }
    }
}
