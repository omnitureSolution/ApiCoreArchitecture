using System;
using System.Collections.Generic;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.Insurance
{
    public partial class PolicyViewModel : ViewModel
    {
        public int PolicyId { get; set; }
        public int EnquiryId { get; set; }
        public int AddressId { get; set; }
        public int TenantId { get; set; }
        public int? PolicyStatusId { get; set; }
        public int? DealDurationId { get; set; }
        public TenantTypes TenantTypeId { get; set; }
        public string AgentCode { get; set; }
        public int? TenantType { get; set; }
        public bool? IsCoverRequired { get; set; }
        public bool? IsEmergencyAssistanceRequired { get; set; }
        public int? TenantAgeId { get; set; }
        public int? ExcessLevelId { get; set; }
        public decimal? BuildingSumInsured { get; set; }
        public decimal? ContentsSumInsured { get; set; }
        public int? PropertyTypeId { get; set; }
        public int? PolicyTypeId { get; set; }
        public string PostCode { get; set; }
        public bool? IsExcessVariableRequired { get; set; }
        public decimal? ExcessVariableValue { get; set; }
        public bool? IsAccidentalDamageRequired { get; set; }
        public decimal? BuildingAccidentalDamageValue { get; set; }
        public bool? IsContentAccidentalDamageRequired { get; set; }
        public decimal? ContentAccidentalDamageValue { get; set; }
        public bool? IsSpecifiedItemRequired { get; set; }
        public bool? IsUnSpecifiedItemRequired { get; set; }
        public bool? IsPedalCycleRequired { get; set; }
        public bool? IsPolicyGenerated { get; set; }
        public bool? IsStopRenewal { get; set; }
        public int? PolicyRateId { get; set; }
        public string Email { get; set; }
        public DateTime? PolicyStartDate { get; set; }
        public DateTime? PolicyEndDate { get; set; }
        public bool? IsUkresident { get; set; }
        public int? PropertyAgeId { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? RateId { get; set; }
        public int? TcsumInsuredId { get; set; }
        public bool? IsMonthLyPolicy { get; set; }
        public string LegacyReferenceNo { get; set; }

        public bool? IsSecondAttempt { get; set; }
        public bool? IsAutomaticallyLapsed { get; set; }
        public DateTime? AutomaticallyLapsedDate { get; set; }
        //public int? InsuredId { get; set; }
        public string BrowserInformation { get; set; }
        public virtual AddressViewModel Address { get; set; }
        public virtual TenantViewModel Tenant { get; set; }
        public virtual EnquiryViewModel Enquiry { get; set; }

        public virtual ICollection<UnderWriterAnswerViewModel> UnderWriterAnswer { get; set; }
        public virtual ICollection<UnderWriterAnswerDetailViewModel> UnderWriterAnswerDetail { get; set; }

    }

    public partial class PolicyYourDetailViewModel : ViewModel
    {
        public int PolicyId { get; set; }
        public int EnquiryId { get; set; }
        public int AddressId { get; set; }
        public EnquiryTypes enquiryTypeId { get; set; }
        public TenantTypes TenantTypeId { get; set; }
        public EntryTypes EntryFrom { get; set; }
        public AddressViewModel Address { get; set; }
        public AddressViewModel CorrespondenceAddress { get; set; }
        public TenantViewModel PrimaryTenant { get; set; }
        public IList<TenantViewModel> AdditionalTenant { get; set; }
        

    }
}
