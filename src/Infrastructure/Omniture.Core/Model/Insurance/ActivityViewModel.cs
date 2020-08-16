namespace iSocietyCare.Core.Model.Insurance
{
    public partial class ActivityViewModel : ViewModel
    {
        public int ActivityId { get; set; }
        public int TenantId { get; set; }
        public int EnquiryId { get; set; }
        public string Note { get; set; }

        public virtual TenantViewModel Tenant { get; set; }
        public virtual EnquiryViewModel Enquiry { get; set; }
    }
}
