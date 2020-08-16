using System.Collections.Generic;
using System.Threading.Tasks;
using iSocietyCare.Core.Model.Account;
using iSocietyCare.Db.Entity.Account;

namespace iSocietyCare.Core.Interfaces.Services.TenantLead
{
    public interface IUserAccessService : IServiceCommon
    {
        Task<TeamUserModifyView> GetTeamMemberDetails(int id);
    }
}
