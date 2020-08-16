namespace iSocietyCare.Core.Model.Insurance
{
    public class PostcodeViewModel : ViewModel
    {
        public int PostCodeId { get; set; }
        public string PostcodePart1 { get; set; }
        public string PostcodeArea { get; set; }
        public string PostalTown { get; set; }
        public string County { get; set; }
        public string LandlordBuildingRegion { get; set; }
        public string LandlordContentRegion { get; set; }
        public string TenantContentRegion { get; set; }
        public int BuildingArea { get; set; }
        public int ContentArea { get; set; }

    }
}
