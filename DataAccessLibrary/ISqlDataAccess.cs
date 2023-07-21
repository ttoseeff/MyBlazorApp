namespace DataAccessLibrary
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U Parameters);
        Task SaveData<U>(string sql, U Parameters);

        Task DeleteData<U>(string sql, U Parameters);

        Task UpdateData<U>(string sql, U Parameters);

    }
}