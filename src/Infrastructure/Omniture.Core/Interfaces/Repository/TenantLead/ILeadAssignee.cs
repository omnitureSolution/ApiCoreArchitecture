using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.TenantLead;

namespace SocietyCare.Core.Interfaces.Repository.TenantLead
{
    public interface ILeadAssignee : IEntityRepository<LeadAssignee>
    {
        void CreateLeadAssignee(LeadAssignee leadAssignee);

    }
}
