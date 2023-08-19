using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task_5.Models;
using Task3.Cash;

namespace Task_5.Services.Employee
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ApplicationDBContext _Context;
        private readonly IMapper _mapper;

        public EmployeeServices(ApplicationDBContext dbContext, IMapper mapper)
        {
            _Context = dbContext;
            _mapper = mapper;
        }

        public async Task<Tables.Employee> GetEmployeeByIdAsync(int empId)
        {
            return await _Context.Employee.FirstOrDefaultAsync(e => e.empId == empId);
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            var list = await _Context.Employee.Include(c => c.city).ToListAsync();
            var result = _mapper.Map<List<EmployeeModel>>(list);
            return result;
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

        public void SendMessage(string email)
        {
            Console.WriteLine("the message send to email " + email + " at " + DateTime.Now);
        }


    }
}
