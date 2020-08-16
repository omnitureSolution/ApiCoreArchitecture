using System.ComponentModel.DataAnnotations;
using iSocietyCare.Core.Model.Account;

namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class LeadAssigneeViewModel : ViewModel
    {
        [Key]
        public int LeadAssigneId { get; set; }
        public int LeadId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsAssigned { get; set; }
        public string Note { get; set; }
        
    }

    public partial class LeadAssigneeDetail : ViewModel
    {
        [Key]
        public int LeadAssigneId { get; set; }
        public int LeadId { get; set; }
        public int UserId { get; set; }
        public virtual UsersViewModel User { get; set; }
    }
}
