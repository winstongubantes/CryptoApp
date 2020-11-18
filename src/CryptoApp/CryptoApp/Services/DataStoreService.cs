using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CryptoApp.Constants;
using CryptoApp.Models.Entities.Base;
using CryptoApp.Services.Interfaces;
using SQLite;

namespace CryptoApp.Services
{
    public class DataStoreService<TEntity> : IDataStoreService<TEntity> where TEntity : IEntityRecord, new()
    {
        protected readonly SQLiteAsyncConnection Connection;

        public DataStoreService()
        {
            var conn = new SQLiteConnection(AppConstant.OfflineDbPath);
            conn.CreateTable<TEntity>();
            Connection = new SQLiteAsyncConnection(AppConstant.OfflineDbPath);
        }

        public AsyncTableQuery<TEntity> Query => Connection.Table<TEntity>();

        public virtual async Task InsertAsync(TEntity record)
        {
            //Api submit successful. Insert to Db.
            await Connection.InsertAsync(record);
        }

        public virtual async Task UpdateAsync(TEntity record)
        {
            //Api submit successful. Insert to Db.
            await Connection.UpdateAsync(record);
        }

        public virtual async Task DeleteAsync(TEntity record)
        {
            await Connection.DeleteAsync(record);
        }

        public virtual async Task DeleteAllAsync()
        {
            await Connection.DropTableAsync<TEntity>();
            await Connection.CreateTableAsync<TEntity>();
        }
    }
}
