namespace iSocietyCare.Core.Model.Insurance
{
    public partial class lstTcsumInsuredViewModel : ViewModel
    {
        public int TcsumInsuredId { get; set; }
        public decimal? TcsumInsuredValue { get; set; }
        public string TcsumInsuredDesc { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
    }
}
