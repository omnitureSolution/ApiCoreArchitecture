using iSocietyCare.Db.Abstractions.Enums;
using iSocietyCare.Db.Entity.Account;

namespace iSocietyCare.Core.Model.TenantLead
{
    public partial class UserAccessViewModel : ViewModel
    {
        public int UserAccessId { get; set; }

        public int AccessTypeId { get; set; }

        public int UserId { get; set; }

    }  
    
   
}
