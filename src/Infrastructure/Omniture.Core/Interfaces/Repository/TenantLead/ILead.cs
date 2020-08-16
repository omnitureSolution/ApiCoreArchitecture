using System.Collections.Generic;
using SocietyCare.Core.Model.TenantLead;
using SocietyCare.Db.Abstractions.Enums;
using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.Enquiries;
using SocietyCare.Db.Entity.TenantLead;

namespace SocietyCare.Core.Interfaces.Repository.TenantLead
{
    public interface ILead : IEntityRepository<Lead>
    {
        Lead CreateLead(LeadViewModel lead);
        Lead UpdateLead(int leadId, LeadViewModel leadView);
        Lead LeadFromRefence(LeadViewModel leadView);
        int UpdateLeadStatus(int leadId, LeadStatus leadStatusId);
        void ReAssignLeads(int employeeId, IList<int> leads);
    }
}
