using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Omniture.Db.Context
{
    public interface IContext : IDisposable
    {

        void ApplyStateChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        void SetModified(object entity);
        void SetAdd(object entity);
        void SetRemove(object entity);
        EntityEntry Entry(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class;
        void Begin();
        void Commit();
        void Rollback();
        IEnumerable<HistoryEntity> HistoryChangeList();
    }
}
