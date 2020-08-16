namespace iSocietyCare.Core.Model.Insurance
{
    public  class PostcodeDeclinedViewModel : ViewModel
    {
        public int DeclinedId { get; set; }
        public string Postcode { get; set; }
        public string PostTown { get; set; }
    }
}
