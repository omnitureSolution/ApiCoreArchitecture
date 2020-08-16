using Omniture.Shared.Helper;
using System.Collections.Generic;

namespace Omniture.Shared.Configuration.Authorization
{
    public class UserInformation : IUserInfo
    {
        public int UserId { get; set; }
        public int UserType { get; set; }
        public int UserAccess { get; set; }
        public int ReferenceId { get; set; } 
    }
}
