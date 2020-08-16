using System.Collections.Generic;
using SocietyCare.Core.Model.Insurance;
using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.Enquiries;

namespace SocietyCare.Core.Interfaces.Repository.Enquiries
{
    public interface ITenant : IEntityRepository<Tenant>
    {
        void AddTenants(IList<TenantViewModel> Tenants, Enquiry enquiry);
        void UpdateTenants(IList<TenantViewModel> tenants, Enquiry enquiry);
    }
}
