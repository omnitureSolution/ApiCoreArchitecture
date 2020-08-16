using SocietyCare.Core.Model.Insurance;
using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.Enquiries;

namespace SocietyCare.Core.Interfaces.Repository.Enquiries
{
    public interface IAddress : IEntityRepository<Address>
    {
        Address Update(int addressId, AddressViewModel addressViewModel);
    }
}
