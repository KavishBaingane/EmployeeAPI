using Practice_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1.Service.IService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(int id, Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
