using System;
using System.Collections.Generic;
using iSocietyCare.Core.Model.Account;
using iSocietyCare.Core.Model.Insurance;
using iSocietyCare.Db.Abstractions.Enums;
using iSocietyCare.Db.Shared.Paging;

namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class LeadViewModel : ViewModel
    {
        public int LeadId { get; set; }
        public DateTime LeadDate { get; set; }
        public DateTime? MoveOnDate { get; set; }
        public LeadStatus LeadStatusId { get; set; }
        public LeadSource LeadSourceId { get; set; }
        public EntryTypes EntryFrom { get; set; }
        public Boolean? IsFloodRisk { get; set; }
        public Boolean? IsNds { get; set; }
        public int? ReferenceId { get; set; }
        public int? EnquiryId { get; set; }
        public string Note { get; set; }
        public String Agent { get; set; }
        public int? AgentId { get; set; }
        public AddressViewModel PropertyLocation { get; set; }
        public IList<TenantViewModel> Tenants { get; set; }
        public LeadSaleInfoViewModel LeadSaleInfoViewModel { get; set; }
    }
    public class ActiveLeadView : ViewModel
    {
        public int LeadId { get; set; }
        public DateTime LeadDate { get; set; }
        public DateTime? MoveOnDate { get; set; }
        public string LeadStatus { get; set; }
        public String LeadSource { get; set; }
        public Boolean IsFloodRisk { get; set; }
        public Boolean IsNds { get; set; }
        public int ReferenceId { get; set; }
        public int? EnquiryId { get; set; }
        public string Note { get; set; }
        public String Address { get; set; }
        public String AgentName { get; set; }
        public String Advisor { get; set; }
        public String LeadNo { get; set; }
        public int? EmployeeId { get; set; }

    }
    public partial class LeadDetailModel : ViewModel
    {
        public int LeadId { get; set; }
        public DateTime LeadDate { get; set; }
        public DateTime? MoveOnDate { get; set; }
        public LeadStatus LeadStatusId { get; set; }
        public LeadSource LeadSourceId { get; set; }
        public string LeadSource { get; set; }
        public EntryTypes EntryFrom { get; set; }
        public Boolean? IsFloodRisk { get; set; }
        public Boolean? IsNds { get; set; }
        public int? ReferenceId { get; set; }
        public int? EnquiryId { get; set; }
        public string Note { get; set; }
        public string AssignedTo { get; set; }
        public TenantEnquiryViewModel Enquiry { get; set; }
        public AddressViewModel PropertyLocation { get; set; }
        public AgentInfoModel AgentInfo { get; set; }
        public IList<ActivityViewModel> Activity { get; set; }
        public IList<TenantViewModel> Tenants { get; set; }

    }
    public partial class LeadView : ViewModel
    {
        public int LeadId { get; set; }
        public DateTime LeadDate { get; set; }

    }
    public class SoldLeadView : ViewModel
    {
        public int LeadId { get; set; }
        public string LeadStatus { get; set; }
        public String LeadSource { get; set; }
        public String Advisor { get; set; }
        public String Address { get; set; }
        public String AgentName { get; set; }
        public string Policy { get; set; }
        public String Product { get; set; }
        public DateTime? SaleDate { get; set; }
        public DateTime? StartDate { get; set; }
        public Decimal? Premium { get; set; }

    }
    public class NoSaleLeadView : ViewModel
    {
        public string LeadNo { get; set; }
        public int LeadId { get; set; }
        public string LeadStatus { get; set; }
        public String LeadSource { get; set; }
        public String Advisor { get; set; }
        public int ContactAttempts { get; set; }
        public String Address { get; set; }
        public String AgentName { get; set; }
        public DateTime LeadDate { get; set; }
        public DateTime NoSaleDate { get; set; }
        public string Reason { get; set; }
        public string AdditionalInfo { get; set; }

    }
    public class SoldLeadSearch 
    {
        public DateTime? SaleFromDate { get; set; }
        public DateTime? SaleToDate { get; set; }
        public int? EmployeeId { get; set; }
    }

    public class NoSaleSearch 
    {
        public DateTime? LeadFromDate { get; set; }
        public DateTime? LeadToDate { get; set; }
        public DateTime? NoSaleFromDate { get; set; }
        public DateTime? NoSaleToDate { get; set; }
        public int? EmployeeId { get; set; }
    }
}
