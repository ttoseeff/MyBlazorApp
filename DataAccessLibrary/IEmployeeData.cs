using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IEmployeeData
    {
        Task<List<Employee>> GetEmployees();
        Task InsertEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
    }
}