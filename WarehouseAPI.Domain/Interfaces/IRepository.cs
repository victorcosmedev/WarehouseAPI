
using System.Linq.Expressions;

namespace WarehouseAPI.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByExternalIdAsync(Guid externalId);
        Task<T> AddAsync(T entity);
        void RemoveAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
