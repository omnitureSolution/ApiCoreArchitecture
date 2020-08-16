using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Omniture.Db.Abstractions.Repository
{
    public interface IEntityRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> FindByIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        ValueTask<T> FindAsync(int id);
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        void Remove(T entity);

        void InsertGraph(T entity);
        void UpdateGraph(T entity);
        void Validate(T entity);

    }
}
