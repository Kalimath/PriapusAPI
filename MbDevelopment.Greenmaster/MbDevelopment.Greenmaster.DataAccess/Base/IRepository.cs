using System.Linq.Expressions;

namespace MbDevelopment.Greenmaster.DataAccess.Base;

public interface IRepository<T> where T : class
{
    bool Exists(Expression<Func<T, bool>> predicate);
    #region Get items
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> Query(Expression<Func<T, bool>> predicate);
    IQueryable<T> All();
    #endregion

    #region Add/update items
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    #endregion
   
    #region Delete items
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    #endregion

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}