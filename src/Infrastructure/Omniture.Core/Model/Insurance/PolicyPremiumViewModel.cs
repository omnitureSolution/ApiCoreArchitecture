namespace iSocietyCare.Core.Model.Insurance
{
    public partial class PolicyPremiumViewModel : ViewModel
    {
        public int PolicyPremiumId { get; set; }
        public int EnquiryId { get; set; }
        public decimal LoadingRate { get; set; }
        public decimal TotalBuildingPremium { get; set; }
        public decimal TotalContentPremium { get; set; }
        public decimal ActualBuildingPremium { get; set; }
        public decimal ActualContentPremium { get; set; }
        public decimal BasicPremium { get; set; }
        public decimal PremiumWithLoading { get; set; }
        public decimal RetailPremium { get; set; }
        public decimal RetailForFullTime { get; set; }
        public decimal FinalForFullTime { get; set; }
        public decimal Ipt { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal FinalPremium { get; set; }
        public decimal MonthlyPremium { get; set; }
        public bool IsDiscountinPerc { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmt { get; set; }
        public bool IsDirectDebit { get; set; }
        public decimal DdCharge { get; set; }
        public decimal DdChargePerc { get; set; }
        public decimal AdminCharge { get; set; }
        public decimal DdMonthlyPermium { get; set; }
        public int TotalMonth { get; set; }
        public int RemainingMonth { get; set; }
        public bool IsDeleted { get; set; }
        public decimal AfterDiscount { get; set; }
        public decimal IptRate { get; set; }
        public decimal IptIncl { get; set; }
        public decimal AdminFee { get; set; }
        public decimal AdminFeeIncl { get; set; }
        public decimal PremiumAfterEas { get; set; }
        public decimal PremiumAfterExtraLoading { get; set; }
        public decimal PremiumAfterAllLoading { get; set; }
        public decimal InitialPremium { get; set; }
        public decimal EmergencyAssitanceCharge { get; set; }
        public decimal NigLoadingPercentage { get; set; }
        public decimal NigLoadingAmount { get; set; }
        public decimal NigNewPremium { get; set; }
        public decimal NigMultiplier { get; set; }
        public decimal TipProratedPremium { get; set; }
        public decimal InitialPremiumTenantProRated { get; set; }
        public decimal InitialPremiumTenantProRatedIncAdminFee { get; set; }

        public virtual EnquiryViewModel Enquiry { get; set; }
    }
}
