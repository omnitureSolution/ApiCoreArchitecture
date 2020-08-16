using System;

namespace iSocietyCare.Core.Model.Insurance
{
    public partial class lstInsurerNameViewModel : ViewModel
    {
        public int InsurerId { get; set; }
        public string InsurerName { get; set; }
        public string UnderwriterCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
