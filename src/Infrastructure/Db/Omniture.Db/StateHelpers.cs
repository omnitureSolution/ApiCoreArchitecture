using Omniture.Db.Abstractions;

namespace Omniture.Db
{
    public class StateHelpers
    {
        public static Microsoft.EntityFrameworkCore.EntityState ConvertState(MaintananceState objstate)
        {
            switch (objstate)
            {
                case MaintananceState.Added:
                    return Microsoft.EntityFrameworkCore.EntityState.Added;
                case MaintananceState.Modified:
                    return Microsoft.EntityFrameworkCore.EntityState.Modified;
                case MaintananceState.DeletedByDate:
                    return Microsoft.EntityFrameworkCore.EntityState.Deleted;
                default:
                    return Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            }
        }
    }
}
