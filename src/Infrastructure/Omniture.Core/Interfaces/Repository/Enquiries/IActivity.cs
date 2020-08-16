using System;
using System.Collections.Generic;
using System.Text;
using SocietyCare.Core.Model.TenantLead;
using SocietyCare.Db.Abstractions.Repository;
using SocietyCare.Db.Entity.Enquiries;

namespace SocietyCare.Core.Interfaces.Repository.Enquiries
{
    public interface IActivity : IEntityRepository<Activity>
    {
        IList<Activity> UpdateLeadNotes(int enquiryId, IList<Activity> Activity);
        IList<Activity> UpdateContactAttempts(int enquiryId, IList<Activity> Activity);
        void AddEnquiryNotes(Activity ActivityView);
        void AddTenantNotes(Activity ActivityView);
    }
}
