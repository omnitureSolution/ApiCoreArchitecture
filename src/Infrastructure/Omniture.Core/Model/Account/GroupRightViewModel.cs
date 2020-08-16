namespace Omniture.Core.Model.Account
{
    public class GroupRightViewModel : ViewModel
    {
        public int GroupId { get; set; }
        public int ModuleId { get; set; }
        public bool? IsAdd { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsEdit { get; set; }
        public bool? IsView { get; set; }
        public virtual GroupViewModel Group { get; set; }
        public virtual ModuleViewModel Module { get; set; }
    }
}
