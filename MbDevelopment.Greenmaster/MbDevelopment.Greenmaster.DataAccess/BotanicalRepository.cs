using System.Linq.Expressions;
using MbDevelopment.Greenmaster.Core.Taxonomy;
using MbDevelopment.Greenmaster.DataAccess.Base;
using Microsoft.EntityFrameworkCore;

namespace MbDevelopment.Greenmaster.DataAccess;

public class BotanicalRepository<T> : IRepository<T> where T : class, ITaxonomyItem
{
    private readonly BotanicalContext _dbContext;
    private readonly DbSet<T> _modelDbSets;

    public BotanicalRepository(BotanicalContext dbContext)
    {
        _dbContext = dbContext;
        _modelDbSets = _dbContext.Set<T>();
    }

    public void Add(T entity)
    {
        _modelDbSets.Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _modelDbSets.AddRange(entities);
    }

    public IQueryable<T> All()
    {
        return _modelDbSets;
    }

    public void Delete(T entity)
    {
        _modelDbSets.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            _modelDbSets.Remove(entity);
        }
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return _modelDbSets.Where(predicate).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
    {
        return await _modelDbSets.Where(predicate).ToListAsync();
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
    {
        return _modelDbSets.Where(predicate);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Update(T entity)
    {
        _modelDbSets.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public bool Exists(Expression<Func<T, bool>> predicate)
    {
        return _modelDbSets.Any(predicate);
    }
}