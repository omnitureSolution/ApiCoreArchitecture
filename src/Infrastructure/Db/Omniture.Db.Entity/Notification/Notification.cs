using Omniture.Db.Abstractions.Enums;
using System.ComponentModel.DataAnnotations;

namespace Omniture.Db.Entity.Notification
{
    //[Table("Notification", Schema = "not")]
    public class Notification : BaseEntity
    {
        [Key]
        public int NotificationId { get; set; } 
        public NotificationTypes NotificationType { get; set; }
        public bool IsActive { get; set; }
        public int SMTPConfigurationId { get; set; }
        public SMTPConfiguration SMTP { get; set; }

    }
}
