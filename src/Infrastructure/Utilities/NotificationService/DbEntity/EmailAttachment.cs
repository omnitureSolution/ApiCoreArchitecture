using iSocietyCare.Db;
using System.ComponentModel.DataAnnotations;
using iSocietyCare.NotificationService.Models;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class EmailAttachment: BaseEntity
    {
        [Key] 
        public int EmailAttachmentId { get; set; }
        public int EmailType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}