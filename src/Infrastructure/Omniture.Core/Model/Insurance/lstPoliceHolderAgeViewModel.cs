namespace iSocietyCare.Core.Model.Insurance
{
    public partial class lstPoliceHolderAgeViewModel : ViewModel
    {        
        public int PoliceHolderAgeId { get; set; }
        public string Ages { get; set; }
        public decimal DiscountRate { get; set; }
        public string AgesTenant { get; set; }
        public decimal DiscountRateTenant { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public decimal DiscountRateMonthlyTenant { get; set; }        

    }
}
