using System.Collections.Generic;
using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.TenantLead;

namespace SocietyCare.Core.Interfaces.Repository.TenantLead
{
    public interface ILeave : IEntityRepository<Leave>
    {
        void CreateLeave(Leave leave);

        IList<int> GetTodaysEmployeesOnLeave();

        IList<int> GetTodaysEmployeesLeaveComplete();

    }
}
