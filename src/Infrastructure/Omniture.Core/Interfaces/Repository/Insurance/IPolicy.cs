using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.Insurance;

namespace SocietyCare.Core.Interfaces.Repository.Insurance
{
    public interface IPolicy : IEntityRepository<Policy>
    {
        void CreatePolicy(Policy policy);

    }
}
