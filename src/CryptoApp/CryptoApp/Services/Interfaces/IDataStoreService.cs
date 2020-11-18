using System.Threading.Tasks;
using CryptoApp.Models.Entities.Base;
using SQLite;

namespace CryptoApp.Services.Interfaces
{
    public interface IDataStoreService<TEntity> where TEntity : IEntityRecord, new()
    {
        AsyncTableQuery<TEntity> Query { get; }
        Task InsertAsync(TEntity record);
        Task UpdateAsync(TEntity record);
        Task DeleteAsync(TEntity record);
        Task DeleteAllAsync();
    }
}