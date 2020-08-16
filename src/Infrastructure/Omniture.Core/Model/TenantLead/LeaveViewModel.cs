using System;
using System.Collections.Generic;
using iSocietyCare.Core.Model.Account;

namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class LeaveViewModel : ViewModel
    {
        public LeaveViewModel()
        {
            LeadAssignee = new HashSet<LeadAssigneeViewModel>();
        }
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Note { get; set; }
        public virtual UsersViewModel User { get; set; }
        public virtual ICollection<LeadAssigneeViewModel> LeadAssignee { get; set; }
    }
}
