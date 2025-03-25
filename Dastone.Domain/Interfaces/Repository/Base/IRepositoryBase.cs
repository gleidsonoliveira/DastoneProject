using System.Linq.Expressions;

namespace Dastone.Domain.Interfaces.Repository.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task AddRange(IList<TEntity> entity);
        Task<TEntity> Update(TEntity entity);
        Task UpdateRange(IEnumerable<TEntity> entity);
        Task<TEntity> Delete(long Id);
        Task<TEntity> GetById(long Id);
        IQueryable<TEntity> GetAll(Func<TEntity, bool> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(Func<TEntity, bool> predicate);
    }
}
