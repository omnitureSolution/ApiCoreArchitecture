using Microsoft.EntityFrameworkCore;
using System.Linq;
using Omniture.Db.Abstractions;

namespace Omniture.Db.Context
{
    public static class ContextHelpers
    {
        public static void ApplyStateChanges(this IContext context)
        {
            foreach (var entry in (context as DbContext).ChangeTracker.Entries<IAudit>())
            {
                IAudit stateInfo = entry.Entity;
                entry.State = StateHelpers.ConvertState(stateInfo.State);
            }
        }

        public static void DetachGraph(this IContext context)
        {
            var changedEntriesCopy = (context as DbContext).ChangeTracker.Entries().ToList();
            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;

        }
        

    }
}
