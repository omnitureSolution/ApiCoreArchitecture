namespace iSocietyCare.Core.Model.Insurance
{
    public partial class lstTenancyTypeViewModel : ViewModel
    {       
        public int TenancyTypeId { get; set; }
        public string TenancyTypeDesc { get; set; }
        public decimal Loading { get; set; }
        public bool IsRefer { get; set; }     
    }
}
