using Microsoft.EntityFrameworkCore;

namespace Task_5.Services.Employee
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ApplicationDBContext _Context;

        public EmployeeServices(ApplicationDBContext dbContext)
        {
            _Context = dbContext;
        }

        public async Task<Tables.Employee> GetEmployeeByIdAsync(int empId)
        {
            return await _Context.Employee.FirstOrDefaultAsync(e => e.empId == empId);
        }

        public async Task<List<Tables.Employee>> GetAllEmployeesAsync()
        {
            return await _Context.Employee.ToListAsync();
        }

        public async Task<Tables.Employee> AddEmployeeAsync(Tables.Employee employee)
        {
            _Context.Employee.Add(employee);
            await _Context.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateEmployeeAsync(int empId, Tables.Employee updatedEmployee)
        {
            var existingEmployee = await _Context.Employee.FirstOrDefaultAsync(e=>e.empId==empId);
            if (existingEmployee != null)
            {
                existingEmployee.empName = updatedEmployee.empName;
                existingEmployee.age = updatedEmployee.age;
                existingEmployee.salary = updatedEmployee.salary;
                existingEmployee.cityId = updatedEmployee.cityId;
                await _Context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployeeAsync(int empId)
        {
            var employee = await _Context.Employee.FindAsync(empId);
            if (employee != null)
            {
                _Context.Employee.Remove(employee);
                await _Context.SaveChangesAsync();
            }
        }

     
    }
}
