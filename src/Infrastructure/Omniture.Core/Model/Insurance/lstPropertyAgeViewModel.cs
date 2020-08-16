namespace iSocietyCare.Core.Model.Insurance
{
    public partial class lstPropertyAgeViewModel : ViewModel
    {       
        public int PropertyAgeId { get; set; }
        public string PropertyAgeDesc { get; set; }
        public decimal Loading { get; set; }
        public bool IsRefer { get; set; }
        public int Minvalue { get; set; }
        public int MaxValue { get; set; }        
    }
}
