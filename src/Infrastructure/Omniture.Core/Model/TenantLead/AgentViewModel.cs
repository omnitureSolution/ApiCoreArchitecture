using System.Collections.Generic;
using iSocietyCare.Core.Model.Insurance;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class AgentViewModel : ViewModel
    {
        public AgentViewModel()
        {
            Enquiry = new HashSet<TenantEnquiryViewModel>();
        }
        public int AgentId { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string WorkContact { get; set; }
        public string TradingAgency { get; set; }
        public string LegacyAccountCode { get; set; }
        public int? TradingStatusId { get; set; }
        public bool IsAgentAuthorized { get; set; }
        public int? FstManagerId { get; set; }
        public string ContactPerson { get; set; }
        public string LiaisonContact { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddress2 { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public int ReferenceId { get; set; }

        public virtual AgentStatus AgentStatusId { get; set; }
        public virtual AgentType AgentTypeId { get; set; }
        public virtual lstFstManagerViewModel FstManager { get; set; }
        public virtual InsuranceStatus? InsuranceStatusId { get; set; }
        public virtual ICollection<TenantEnquiryViewModel> Enquiry { get; set; }
    }

    public partial class AgentInfoModel
    {
        public int AgentId { get; set; }
        public string AgentCode { get; set; }
        public string NameName { get; set; }
        public string WorkContact { get; set; }
        public string EmailAddress { get; set; }
        public string EmailAddress2 { get; set; }
        public string ContactPerson { get; set; }
    }

    public class AgentView : ViewModel
    {
        public int AgentId { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
    }
}
