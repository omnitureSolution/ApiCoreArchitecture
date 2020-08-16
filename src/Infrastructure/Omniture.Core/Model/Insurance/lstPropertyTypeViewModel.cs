namespace iSocietyCare.Core.Model.Insurance
{
    public partial class lstPropertyTypeViewModel : ViewModel
    {        
        public int PropertyTypeId { get; set; }
        public string PropertyTypeDesc { get; set; }
        public int PolicyTypeId { get; set; }
        public decimal Loading { get; set; }
        
    }
}
