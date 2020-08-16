using System;
using System.Collections.Generic;
using System.Text;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.TenantLead
{
   public partial class ActivityViewModel : ViewModel 
    {
        public int ActivityeId { get; set; }
        public int TenantId { get; set; }
        public int EnquiryId { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string UserName { get; set; }
        public EntryTypes EntryFromId { get; set; }
        public ActivityType ActivityTypeId { get; set; }
    }
}
