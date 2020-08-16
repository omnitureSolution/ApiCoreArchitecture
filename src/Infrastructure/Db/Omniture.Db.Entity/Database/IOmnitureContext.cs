using Omniture.Db.Context; 
//using Omniture.Db.Entity.Utilities;
using Microsoft.EntityFrameworkCore;
using Omniture.Db.Entity.Notification;

namespace Omniture.Db.Entity.Database
{
    public interface IOmnitureContext : IContext
    {


        #region Utilities
       DbSet<User> User { get; set; }
        #endregion
    }
}
