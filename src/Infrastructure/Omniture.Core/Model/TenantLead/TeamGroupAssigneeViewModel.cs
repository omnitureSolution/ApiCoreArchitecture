using System.Collections.Generic;

namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class TeamGroupAssigneeViewModel : ViewModel
    {
        public TeamGroupAssigneeViewModel()
        {
            lstTeamGroupAssigneed = new HashSet<TeamGroupAssigneeViewModel>();
        }

        public int TeamGroupAssigneeId { get; set; }

        public int TeamGroupId { get; set; }

        public int UserId { get; set; }


        public virtual ICollection<TeamGroupAssigneeViewModel> lstTeamGroupAssigneed { get; set; }

    }
    
}
