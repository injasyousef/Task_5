using Task_5.Models;

namespace Task_5.Services.Employee
{
    public interface IEmployeeServices
    {
        Task<Tables.Employee> GetEmployeeByIdAsync(int empId);
        Task<List<EmployeeModel>> GetAllEmployeesAsync();
        Task<Tables.Employee> AddEmployeeAsync(Tables.Employee employee);
        Task UpdateEmployeeAsync(int empId, Tables.Employee updatedEmployee);
        Task DeleteEmployeeAsync(int empId);
        void SendMessage(string email);
    }
}
