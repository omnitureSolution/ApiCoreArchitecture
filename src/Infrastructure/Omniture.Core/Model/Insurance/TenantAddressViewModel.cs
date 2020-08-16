using System.Collections.Generic;

namespace iSocietyCare.Core.Model.Insurance
{
    public partial class TenantAddressViewModel : ViewModel
    {
        public TenantAddressViewModel()
        {
            Contact = new HashSet<ContactsViewModel>();
        }

        public int TenantAddressId { get; set; }
        public int AddressId { get; set; }
        public int TenantId { get; set; }

        public virtual AddressViewModel Address { get; set; }
        public virtual TenantViewModel Tenant { get; set; }
        public virtual ICollection<ContactsViewModel> Contact { get; set; }
    }
}
