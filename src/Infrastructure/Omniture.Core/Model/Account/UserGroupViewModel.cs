namespace Omniture.Core.Model.Account
{
    public class UserGroupViewModel : ViewModel
    {
        public int UserGroupId { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public virtual GroupViewModel Group { get; set; }
        public virtual UsersViewModel User { get; set; }
    }
}
