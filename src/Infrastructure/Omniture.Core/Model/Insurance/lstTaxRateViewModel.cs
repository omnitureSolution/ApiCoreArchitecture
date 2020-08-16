using System;

namespace iSocietyCare.Core.Model.Insurance
{
    public partial class lstTaxRateViewModel : ViewModel
    {
        public int TaxId { get; set; }
        public decimal Ipt { get; set; }
        public decimal Vat { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? IptMtaAp { get; set; }
        public decimal? IptMtaRf { get; set; }
    }
}
