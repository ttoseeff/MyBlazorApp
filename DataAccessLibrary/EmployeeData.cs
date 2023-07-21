using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class EmployeeData : IEmployeeData
    {
        private readonly ISqlDataAccess _db;
        public EmployeeData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<Employee>> GetEmployees()
        {
            string sql = "select * from dbo.Employees Where UserId = 1";

            return _db.LoadData<Employee, dynamic>(sql, new { });
        }

        public Task InsertEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employee.Phone = 0;
            employee.Salary = 0;
            employee.UserId = 1;
            string sql = @"insert into dbo.Employees(Id,[Name], Email, Phone, Salary, Department, UserId)
                           values (@Id ,@Name, @Email, @Phone, @Salary, @Department, @UserId);";

            return _db.SaveData(sql, employee);
        }

        public Task DeleteEmployee(Employee employee)
        {
            string sql = @"Delete from dbo.Employees where Id = @Id";
            return _db.DeleteData(sql, employee);
        }

        public Task UpdateEmployee(Employee employee)
        {
            employee.Phone = 0;
            employee.Salary = 0;
            employee.UserId = 1;
            string sql = @"Update dbo.Employees
                            set [Name] = @Name,
                            Email = @Email,
                            Department = @Department
                            Where Id = @Id";
            return _db.UpdateData(sql, employee);

        }
    }
}
