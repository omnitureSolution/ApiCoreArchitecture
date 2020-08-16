using Omniture.Db.Context;
using Omniture.Db.Shared.Configuration;
using Omniture.Shared.Helper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Omniture.Db.Shared
{
    public class OmnitureCommonContext : OmnitureBaseContext<OmnitureCommonContext>, IOmnitureCommonContext
    {
        public OmnitureCommonContext(DbContextOptions<OmnitureCommonContext> options)
        : base(options, new UserInformation())
        {
        }

        public DbSet<SystemConfiguration> SystemConfiguration { get; set; }
    }

    public class UserInformation : IUserInfo
    {
        public int UserId { get; set; }
        public int UserType { get; set; }
        public int UserAccess { get; set; }
        public int ReferenceId { get; set; }
    }
}
