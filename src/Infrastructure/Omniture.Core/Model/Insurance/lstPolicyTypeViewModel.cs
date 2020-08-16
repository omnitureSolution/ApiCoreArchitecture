namespace iSocietyCare.Core.Model.Insurance
{
    public partial class lstPolicyTypeViewModel : ViewModel
    {
        public int PolicyTypeId { get; set; }
        public string PolicyTypeDesc { get; set; }
        public string PolicyCode { get; set; }
        public int? NominalCode { get; set; }
        public int? DepartmentId { get; set; }
        public decimal? AdminFees { get; set; }
    }
}
