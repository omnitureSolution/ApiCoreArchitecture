using System.Collections.Generic;
using SocietyCare.Core.Model.TenantLead;
using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.Enquiries;

namespace SocietyCare.Core.Interfaces.Repository.TenantLead
{
    public interface IAgent : IEntityRepository<Agent>
    {
        void SyncAgent(IList<AgentViewModel> agent);

    }
}
