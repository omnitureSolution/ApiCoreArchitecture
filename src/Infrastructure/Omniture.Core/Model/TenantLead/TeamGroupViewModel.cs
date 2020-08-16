using System.Collections.Generic;

namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class TeamGroupViewModel : ViewModel
    {
        public TeamGroupViewModel()
        {
            InverseParentTeamGroup = new HashSet<TeamGroupViewModel>();
        }
       
        public int TeamGroupId { get; set; }
        public string TeamGroupName { get; set; }
        public int TeamLeadUserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string SenderName { get; set; }
        public int? ParentTeamGroupId { get; set; }


        public virtual TeamGroupViewModel ParentTeamGroup { get; set; }
        public virtual ICollection<TeamGroupViewModel> InverseParentTeamGroup { get; set; }
    }
}
