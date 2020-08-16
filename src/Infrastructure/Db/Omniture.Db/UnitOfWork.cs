using System.Collections.Generic;
using System.Threading.Tasks;
using Omniture.Db.Context;

namespace Omniture.Db
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IUnitOfWork
        where TContext : IContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
        public TContext Context => _context;
        public void Dispose()
        {
            _context.Dispose();
        }
        public IEnumerable<HistoryEntity> HistoryChangeList()
        {
            return _context.HistoryChangeList();

        }
    #region Transactions
    public void Begin()
    {
        Context.Begin();
    }
    public void Commit()
    {
        Context.Commit();
    }
    public void Rollback()
    {
        Context.Rollback();
    }
    #endregion

}
}
