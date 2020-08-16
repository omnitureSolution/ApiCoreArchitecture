using System;

namespace Omniture.Core.Models.Notification
{
    public class NotificationView
    {
        public int TypeOfFeature { get; set; }
        public String Parameters { get; set; }
        public String FromEmail { get; set; }
        public Guid? MessageId { get; set; }
        public int EmailType { get; set; }
    }
}
