namespace iSocietyCare.Core.Model.Insurance
{
    public partial class PaymentRequestDetailViewModel : ViewModel
    {
        public int PaymentRequestDetailId { get; set; }
        public int TenantId { get; set; }
        public string InputString { get; set; }
        public string OutputString { get; set; }
        public bool IsSuccess { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool IsRefund { get; set; }

        public virtual TenantViewModel Tenant { get; set; }
    }
}
