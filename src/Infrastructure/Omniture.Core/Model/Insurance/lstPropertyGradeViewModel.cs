namespace iSocietyCare.Core.Model.Insurance
{
    public partial class lstPropertyGradeViewModel : ViewModel
    {        
        public int PropertyGradeId { get; set; }
        public string PropertyGradeDesc { get; set; }
        public decimal Loading { get; set; }
        public bool IsRefer { get; set; }
       
    }
}
