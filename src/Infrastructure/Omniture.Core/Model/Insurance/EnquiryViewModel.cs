using System.Collections.Generic;
using iSocietyCare.Db.Abstractions.Enums;
using iSocietyCare.Db.Entity.Enquiries;

namespace iSocietyCare.Core.Model.Insurance
{
    public class EnquiryViewModel : ViewModel
    {
        public int EnquiryId { get; set; }
        public string EnquiryNumber { get; set; }
        public int? AddressId { get; set; }
        public int? AgentId { get; set; }
        public EntryTypes EntryFromId { get; set; }
        public EnquiryTypes EnquiryTypeId { get; set; }
        public ICollection<EnquiryTenantViewModel> EnquiryTenant;
        public AddressViewModel Address { get; set; }
    }

    public class CreateUpdateEnquiryModel : ViewModel
    {
        public int EnquiryId { get; set; }
        public int? AgentId { get; set; }
        public EnquiryTypes EnquiryType { get; set; }
        public LeadSource LeadSource { get; set; }
        public EntryTypes EntryFrom { get; set; }
        public IList<TenantViewModel> Tenants { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
