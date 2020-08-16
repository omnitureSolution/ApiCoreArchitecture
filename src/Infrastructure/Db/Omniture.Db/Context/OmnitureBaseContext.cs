using Omniture.Shared.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Omniture.Db.Abstractions;
using System.Linq;
using System.Collections.Generic;
using Omniture.Shared.Common;

namespace Omniture.Db.Context
{
    public class OmnitureBaseContext<TContext> : DbContext where TContext : DbContext
    {
        public IUserInfo UserInfo { get; }
        protected OmnitureBaseContext(DbContextOptions<TContext> options, IUserInfo userInfo)
         : base(options)
        {
            UserInfo = userInfo;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetAuditInformation();
            return base.SaveChangesAsync(cancellationToken);
        }
        public void ApplyStateChanges()
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>())
            {
                BaseEntity stateInfo = entry.Entity;
                entry.State = ConvertState(stateInfo.State);
            }
        }

        #region Transactions
        public void Begin()
        {
            base.Database.BeginTransaction();
        }
        public void Commit()
        {
            base.Database.CommitTransaction();
        }
        public void Rollback()
        {
            base.Database.RollbackTransaction();
        }
        #endregion

        #region Entity Operations
        public void SetRemove(object entity)
        {
            Entry(entity).State = EntityState.Deleted;
        }
        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
        public void SetAdd(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }
        public IEnumerable<HistoryEntity> HistoryChangeList()
        {
            return ChangeTracker.Entries<IHistoryRequired>()
                .Select(t => new HistoryEntity
                {
                    TableName = t.Entity.GetType().Name,
                    JsonObject = t.Entity.ToJsonString()
                }).ToList();
        }
        //public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class => this.Set<TEntity>().FromSql(sql, parameters);
        #endregion
        private void SetAuditInformation()
        {
            foreach (var entry in ChangeTracker.Entries<IAudit>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = UserInfo.UserId;
                    entry.Entity.CreatedDate = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity.IsDeleteProcess && entry.Entity.DeletedDate == null)
                    {
                        entry.Entity.DeletedBy = UserInfo.UserId;
                        entry.Entity.DeletedDate = DateTime.Now;
                    }
                    else
                    {
                        entry.Entity.ModifiedBy = UserInfo.UserId;
                        entry.Entity.ModifiedDate = DateTime.Now;
                    }
                }
            }
        }
        EntityState ConvertState(MaintananceState state)
        {
            switch (state)
            {
                case MaintananceState.Added:
                    return EntityState.Added;
                case MaintananceState.Modified:
                    return EntityState.Modified;
                case MaintananceState.DeletedByDate:
                    return EntityState.Modified;
                case MaintananceState.Remove:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

    }
}
