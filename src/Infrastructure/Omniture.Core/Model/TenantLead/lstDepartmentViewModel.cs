using System.Collections.Generic;

namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class lstDepartmentViewModel : ViewModel
    {
        public lstDepartmentViewModel()
        {
            LstProduct = new HashSet<lstProductViewModel>();
        }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<lstProductViewModel> LstProduct { get; set; }
    }
}
