using System.Collections.Generic;

namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class lstFstManagerViewModel : ViewModel
    {
        public lstFstManagerViewModel()
        {
            Agent = new HashSet<AgentViewModel>();
        }
        public int FstManagerId { get; set; }
        public string FstManagerName { get; set; }

        public virtual ICollection<AgentViewModel> Agent { get; set; }
    }
}
