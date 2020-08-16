using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omniture.Db.Entity.Notification
{
    //[Table("EmailAttachment", Schema = "not")]
    public class EmailAttachment : BaseEntity
    {
        [Key]
        public int EmailAttachmentId { get; set; }
        public int EmailType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}