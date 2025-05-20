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
    }
}
