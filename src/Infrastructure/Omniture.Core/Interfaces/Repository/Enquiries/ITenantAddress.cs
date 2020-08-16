using System;
using System.Collections.Generic;
using System.Text;
using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.Enquiries;

namespace SocietyCare.Core.Interfaces.Repository.Enquiries
{
    public interface ITenantAddress : IEntityRepository<TenantAddress>
    {
    }
}
