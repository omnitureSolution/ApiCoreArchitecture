namespace iSocietyCare.Core.Model.Insurance
{
    public partial class lstExcessLevelViewModel : ViewModel
    {       
        public int ExcessLevelId { get; set; }
        public int ExcessLevel { get; set; }
        public decimal Discount { get; set; }
        public decimal TcLoading { get; set; }
        public string ExcessLevelText { get; set; }
       
    }
}
