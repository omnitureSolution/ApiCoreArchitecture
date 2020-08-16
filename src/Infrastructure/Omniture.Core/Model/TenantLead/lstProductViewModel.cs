namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class lstProductViewModel : ViewModel
    {
       
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int? DepartmentId { get; set; }
        public string Tenant { get; set; }
        public decimal ReferencingRate { get; set; }
        public decimal VatAmount { get; set; }
        public decimal InsuranceRate { get; set; }
        public decimal Iptamount { get; set; }
        public decimal NetPrice { get; set; }
        public decimal UnderwriterRateExIpt { get; set; }
        public bool IsPerPropertyType { get; set; }
        public int? Duration { get; set; }
        public int? SortOrder { get; set; }
        public bool IsRgProduct { get; set; }
        public bool IsNdsAvailableWithProd { get; set; }
        public bool IsProdAvailableWtihD2t { get; set; }
        public int NominalCode { get; set; }
        public virtual lstDepartmentViewModel Department { get; set; }
    }
}
