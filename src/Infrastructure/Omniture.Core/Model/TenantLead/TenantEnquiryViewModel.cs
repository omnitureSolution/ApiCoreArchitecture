using System;
using System.Collections.Generic;
using System.Text;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class TenantEnquiryViewModel : ViewModel
    {
        public int EnquiryId { get; set; }
        public string EnquiryNumber { get; set; }
        public EnquiryTypes EnquiryTypeId { get; set; }
        public EntryTypes EntryFromId { get; set; }
    }
}
