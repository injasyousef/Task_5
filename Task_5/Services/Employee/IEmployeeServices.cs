namespace Task_5.Services.Employee
{
    public interface IEmployeeServices
    {
        Task<Tables.Employee> GetEmployeeByIdAsync(int empId);
        Task<List<Tables.Employee>> GetAllEmployeesAsync();
        Task<Tables.Employee> AddEmployeeAsync(Tables.Employee employee);
        Task UpdateEmployeeAsync(int empId, Tables.Employee updatedEmployee);
        Task DeleteEmployeeAsync(int empId);
    }
}
