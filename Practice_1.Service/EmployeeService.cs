using Practice_1.DataAccess.Repository.IRepository;
using Practice_1.Models;
using Practice_1.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _repository.GetEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _repository.GetEmployeeByIdAsync(id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await _repository.AddEmployeeAsync(employee);
        }

        public async Task UpdateEmployeeAsync(int id, Employee employee)
        {
            var existingEmployee = await _repository.GetEmployeeByIdAsync(id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.JoiningDate = employee.JoiningDate;

                await _repository.UpdateEmployeeAsync(existingEmployee);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _repository.DeleteEmployeeAsync(id);
        }
    }
}
