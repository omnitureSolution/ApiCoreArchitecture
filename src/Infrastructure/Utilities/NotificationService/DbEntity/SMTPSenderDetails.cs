using iSocietyCare.Db;
using System;
using System.ComponentModel.DataAnnotations;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class SMTPSenderDetail : BaseEntity
    {
        [Key]
        public int SMTPSenderDetailsId { get; set; }
        public String MailFrom { get; set; }
        public String SenderName { get; set; }
        public string Password { get; set; }
        public String SenderContactNumber { get; set; }
        public Boolean IsDefault { get; set; }
        public String DefaultCC { get; set; }
        public String DefaultBCC { get; set; }
    }
}
