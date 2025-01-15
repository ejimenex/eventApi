using System.Linq.Expressions;

namespace EventApi.Application.Contract.Persistence
{
   
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> ListAllDataBaseAsync();
        IQueryable<T> GetByExpressionAsync(Expression<Func<T, bool>> expression);
        Task<bool> ExistAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    }
}
