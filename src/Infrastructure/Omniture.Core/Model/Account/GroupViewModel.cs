using System.Collections.Generic;

namespace Omniture.Core.Model.Account
{
    public class GroupViewModel : ViewModel
    {
        public GroupViewModel()
        {
            GroupRight = new HashSet<GroupRightViewModel>();
            UserGroup = new HashSet<UserGroupViewModel>();
        }
        public string GroupName { get; set; }

        public virtual ICollection<GroupRightViewModel> GroupRight { get; set; }
        public virtual ICollection<UserGroupViewModel> UserGroup { get; set; }
    }
}
