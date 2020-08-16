using SocietyCare.Core.Model.Insurance;
using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.Enquiries;

namespace SocietyCare.Core.Interfaces.Repository.Enquiries
{
    public interface IEnquiry : IEntityRepository<Enquiry>
    {
        Enquiry CreateEnquiry(CreateUpdateEnquiryModel createEnquiryModel);
        Enquiry UpdateEnquiry(CreateUpdateEnquiryModel enquiryModel);
        
    }
}
