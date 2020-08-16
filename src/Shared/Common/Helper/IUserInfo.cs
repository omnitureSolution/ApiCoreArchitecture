using System;
using System.Collections.Generic;

namespace Omniture.Shared.Helper
{
    public interface IUserInfo
    {
        Int32 UserId { get; set; }
        Int32 UserType { get; set; }
        int UserAccess { get; set; }
        int ReferenceId { get; set; } 
    }
}
