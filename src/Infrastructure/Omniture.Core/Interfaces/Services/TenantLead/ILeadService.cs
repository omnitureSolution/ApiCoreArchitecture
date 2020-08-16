using System.Collections.Generic;
using System.Threading.Tasks;
using iSocietyCare.Core.Model.Insurance;
using iSocietyCare.Core.Model.TenantLead;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Interfaces.Services.TenantLead
{
    public interface ILeadService : IServiceCommon
    {
        Task<List<ActiveLeadView>> GetActiveLead();
        Task<List<SoldLeadView>> GetSoldLead(SoldLeadSearch search);
        Task<List<NoSaleLeadView>> GetNoSale(NoSaleSearch search);
        Task<LeadViewModel> GetLeadById(int leadId);
        Task<LeadDetailModel> GetEnquiry(int leadId);
        Task<List<TenantInfo>> GetTenantByLead(int leadId);

    }
}
