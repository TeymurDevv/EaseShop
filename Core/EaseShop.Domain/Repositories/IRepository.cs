using System.Linq.Expressions;

namespace EaseShop.Domain.Repositories;

public interface IRepository<T> where T : class
{

    Task<T> GetEntity(Expression<Func<T, bool>> predicate = null, bool AsnoTracking = false, bool AsSplitQuery = false, int skip = 0, int take = 0, bool isIgnoredDeleteBehaviour = false, params Func<IQueryable<T>, IQueryable<T>>[] includes);
    Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null, bool AsnoTracking = false, bool AsSplitQuery = false, int skip = 0, int take = 0, bool isIgnoredDeleteBehaviour = false, params Func<IQueryable<T>, IQueryable<T>>[] includes);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<bool> isExists(Expression<Func<T, bool>> predicate = null, bool AsNoTracking = false, bool isIgnoredDeleteBehaviour = false);
    Task<IQueryable<T>> GetQuery(
        Expression<Func<T, bool>> predicate = null, bool AsnoTracking = false, bool AsSplitQuery = false,
        bool isIgnoredDeleteBehaviour = false,
        params Func<IQueryable<T>, IQueryable<T>>[] includes);
}