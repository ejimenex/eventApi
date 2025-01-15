using EventApi.Application.Contract.Persistence;
using EventApi.Domain.Common;
using EventApi.Infrasestructure.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventApi.Percistence.Repositories.Base
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseId, new()
    {
        protected readonly EventApiDbContext _dbContext;
        protected readonly ITokenService _tokenService;
        public BaseRepository(EventApiDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public virtual async Task<T> AddAsync(T entity)
        {         
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
        }
        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
        public IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return  query.Where(predicate);
        }
        public virtual async Task<T> GetByIdAsync(int Id)=> await _dbContext.Set<T>().FindAsync(Id);        
        public  IQueryable<T> GetByExpressionAsync(Expression<Func<T, bool>> expression)=> _dbContext.Set<T>().Where(expression).AsQueryable();        
        public virtual async Task<IReadOnlyList<T>> ListAllAsync()=> await _dbContext.Set<T>().ToListAsync();        
        public virtual IQueryable<T> ListAllDataBaseAsync()=> _dbContext.Set<T>().AsQueryable();        
        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> ExistAsync(Expression<Func<T, bool>> expression)
        {
           return _dbContext.Set<T>().AnyAsync(expression); 
        }
    }
}
