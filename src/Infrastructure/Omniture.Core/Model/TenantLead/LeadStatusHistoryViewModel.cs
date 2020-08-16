using System;
using System.Collections.Generic;
using System.Text;

namespace iSocietyCare.Core.Model.TenantLead
{
    public class LeadStatusHistoryViewModel:ViewModel
    {
        public int LeadId { get; set; }
        public int LeadStatusId { get; set; }
        public DateTime? NoSaleDate { get; set; }
        public string Reason { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
