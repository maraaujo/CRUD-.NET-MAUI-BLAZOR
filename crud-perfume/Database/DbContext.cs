using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace crud_perfume.Database
{
    public class DbContext
    {
        public SQLiteAsyncConnection _dbConection;
        public readonly static string nameSpace = "crud_perfume.Database";
        public const string DatabaseFileName = "crud_perfume.Database.db3";
        public static string databasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite
            | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;
        public DbContext()
        {
            if (_dbConection == null)
            {
                _dbConection = new SQLiteAsyncConnection(databasePath, Flags);
                _dbConection.CreateTableAsync<Models.Perfume>();
            }
        }
        public async Task Initialize()
        {
            await _dbConection.CreateTableAsync<Models.Perfume>();
        }

        public List<T> GetTableRows (string tableName) where T : class
        {
            object[] obj = new object[] { };
            TableMapping map  = new TableMapping(Type.GetType(nameSpace + tableName);
            string query = "SELECT * FROM ["+ tableName +"]" ;
            return _dbConection.QueryAsync(map, query, obj).Result.Cast<T>.ToList();
        }
      
        public object GetTableRow(string tableNmae, string colum, string value)
        {
            object[] obj = new object[] { };
            TableMapping map = new TableMapping(Type.GetType(nameSpace + tableNmae));
            string query = "SELECT * FROM [" + tableNmae + "] WHERE [" + colum + "] = " + value;
            return _dbConection.QueryAsync(map, query, obj).Result.Cast<T>.ToList();
        }
        public async Task<int> CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConection.InsertAsync(entity);
        }
        public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConection.UpdateAsync(entity);
        }
        public async Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConection.DeleteAsync(entity);
        }
        public async Task<int> ArrOrUpdate<TEntity>(TEntity entity) where TEntity : class
        {
            return await _dbConection.InsertOrReplaceAsync(entity);
        }
    }
}
