using System.Collections.Generic;
using SocietyCare.Core.Model.Account;
using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.TenantLead;

namespace SocietyCare.Core.Interfaces.Repository.TenantLead
{
    public interface ITeamGroupAssignee : IEntityRepository<TeamGroupAssignee>
    {
        bool CheckifMultipleTeamAssigned(int EmployeeId);

        bool GetAnotherEmployeeOfTeam(int EmployeeId, out int otherEmployeeId);
    }
}
