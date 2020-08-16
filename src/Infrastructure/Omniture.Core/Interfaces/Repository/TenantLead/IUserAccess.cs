using SocietyCare.Core.Model.Account;
using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.Account;

namespace SocietyCare.Core.Interfaces.Repository.TenantLead
{
    public interface IUserAccess : IEntityRepository<UserAccess>
    {
        
    }
}
