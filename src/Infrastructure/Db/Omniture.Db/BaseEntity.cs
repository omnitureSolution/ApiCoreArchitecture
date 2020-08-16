using System;
using System.ComponentModel.DataAnnotations.Schema;
using Omniture.Shared.Common;
using Newtonsoft.Json;
using Omniture.Db.Abstractions;

namespace Omniture.Db
{
    public abstract class BaseEntity
    {
        [NotMapped]
        public MaintananceState State { get; set; }
        [NotMapped]
        [JsonIgnore]
        public bool IsDeleteProcess { get; set; } = false;
    }

    public abstract class AuditEntity : BaseEntity, IAudit
    {
        private DateTime? _createdDate;
        public DateTime? CreatedDate
        {
            get => _createdDate?.UtcDate();
            set => _createdDate = value?.UtcDate();
        }
        public int? CreatedBy { get; set; }
        private DateTime? _modifiedDate;
        public DateTime? ModifiedDate
        {

            get => _modifiedDate?.UtcDate();
            set => _modifiedDate = value?.UtcDate();
        }
        public int? ModifiedBy { get; set; }
        private DateTime? _deletedDate;
        public DateTime? DeletedDate
        {
            get => _deletedDate?.UtcDate();
            set => _deletedDate = value?.UtcDate();
        }
        public int? DeletedBy { get; set; }

    }

    public class HistoryEntity
    {
        public string TableName { get; set; }
        public string JsonObject { get; set; }
    }
}
