using System;

namespace Omniture.Db.Abstractions
{
    public interface IAudit
    {
        DateTime? CreatedDate { get; set; }
        int? CreatedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        int? DeletedBy { get; set; }
        MaintananceState State { get; set; }
        Boolean IsDeleteProcess { get; set; }
    }
}
