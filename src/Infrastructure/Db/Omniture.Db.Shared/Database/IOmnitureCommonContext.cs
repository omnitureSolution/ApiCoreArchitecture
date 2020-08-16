using Microsoft.EntityFrameworkCore;
using Omniture.Db.Context;
using Omniture.Db.Shared.Configuration;

namespace Omniture.Db.Shared
{
    public interface IOmnitureCommonContext : IContext
    {
        DbSet<SystemConfiguration> SystemConfiguration { get; set; }
    }
}
