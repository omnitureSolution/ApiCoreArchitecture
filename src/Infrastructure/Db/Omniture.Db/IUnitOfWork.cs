using System.Collections.Generic;
using System.Threading.Tasks;

namespace Omniture.Db
{
    public interface IUnitOfWork
    {
        IEnumerable<HistoryEntity> HistoryChangeList();
        //int Save();
        Task<int> SaveAsync();
        void Begin();
        void Commit();
        void Rollback();
    }
}