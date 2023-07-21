using Dapper;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private IConfiguration _config;
        private string connectionStringName = "myConnection";
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U Parameters)
        {
            string connectionStrings = _config.GetConnectionString(connectionStringName) ?? "";

            using (IDbConnection connection = new SqlConnection(connectionStrings))
            {
                var data = await connection.QueryAsync<T>(sql, Parameters);
                return data.ToList();
            }
        }

        public async Task SaveData<U>(string sql, U Parameters)
        {
            string connectionStrings = _config.GetConnectionString(connectionStringName) ?? "";
            using (IDbConnection connection = new SqlConnection(connectionStrings))
            {
                try
                {

                await connection.ExecuteAsync(sql, Parameters);
                }
                catch(Exception ex)
                {

                }

            }
        }

        public async Task DeleteData<U>(string sql, U Parameters)
        {
            string connectionStrings = _config.GetConnectionString(connectionStringName) ?? "";
            using (IDbConnection connection = new SqlConnection(connectionStrings))
            {
                try
                {

                    await connection.ExecuteAsync(sql, Parameters);
                }
                catch (Exception ex)
                {

                }

            }
        }

        public async Task UpdateData<U>(string sql, U Parameters)
        {
            string connectionStrings = _config.GetConnectionString(connectionStringName) ?? "";
            using (IDbConnection connection = new SqlConnection(connectionStrings))
            {
                try
                {

                    await connection.ExecuteAsync(sql, Parameters);
                }
                catch (Exception ex)
                {

                }

            }
        }
    }
}