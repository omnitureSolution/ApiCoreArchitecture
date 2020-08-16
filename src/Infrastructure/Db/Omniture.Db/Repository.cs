using Omniture.Db.Abstractions.Repository;
using Omniture.Db.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Omniture.Db
{
  public abstract class Repository<T> : IEntityRepository<T> where T : class
  {
    internal readonly IContext Context;
    internal readonly DbSet<T> DbSet;
    protected Repository(IContext context)
    {
      Context = context;
      DbSet = Context.Set<T>();
    }
    public IQueryable<T> All => Context.Set<T>();
    public virtual void Add(T entity)
    {
      Validate(entity);
      Context.SetAdd(entity);
    }
    public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
    {
      return GetAllIncluding(includeProperties);
    }
    public Task<List<T>> FindByIncludeAsync(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includeProperties)
    {
      var query = GetAllIncluding(includeProperties);
      var results = query.Where(predicate);
      return results.ToListAsync();
    }
    public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
      IQueryable<T> queryable = DbSet.AsNoTracking();
      IEnumerable<T> results = queryable.Where(predicate).ToList();
      return results;
    }
    private IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
    {
      IQueryable<T> queryable = DbSet.AsNoTracking();

      return includeProperties.Aggregate
        (queryable, (current, includeProperty) => current.Include(includeProperty));
    }
    public T Find(int id)
    {
      return Context.Set<T>().Find(id);
    }
    public ValueTask<T> FindAsync(int id)
    {
      return Context.Set<T>().FindAsync(id);
    }
    public virtual void Update(T entity)
    {
      Validate(entity);
      Context.SetModified(entity);
    }
    public void InsertGraph(T entity)
    {
      Context.Set<T>().Add(entity);
    }
    public void UpdateGraph(T entity)
    {
      Context.Set<T>().Add(entity);
      Context.ApplyStateChanges();
    }
    public virtual void Delete(int id)
    {
      var entity = Context.Set<T>().Find(id) as AuditEntity;
      if (entity != null)
      {
        entity.IsDeleteProcess = true;
        Context.SetModified(entity);
      }
    }
    public virtual void Delete(T entity)
    {
      if (entity is AuditEntity)
      {
        (entity as AuditEntity).IsDeleteProcess = true;
        Context.SetModified(entity);
      }
    }
    public virtual void Remove(T entity)
    {
      Context.SetRemove(entity);
    }
    public void Dispose()
    {
      Context.Dispose();
    }
    public virtual void Validate(T entity)
    {
      //success
    }
  }
}
