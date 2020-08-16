using System;
using System.Collections.Generic;
using System.Text;

namespace iSocietyCare.Core.Model.TenantLead
{
    public class LeadSaleInfoViewModel
    {
        public int LeadId { get; set; }

        public int PolicyNo { get; set; }

        public string Product { get; set; }

        public DateTime? SaleDate { get; set; }

        public DateTime? StartDate { get; set; }

        public decimal? Premium { get; set; }

    }
}
