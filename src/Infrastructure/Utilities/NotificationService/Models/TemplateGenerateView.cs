using iSocietyCare.Core.Model.Common;
using iSocietyCare.Db.Abstractions.Enums;
using iSocietyCare.Db.Entity.Notification;
using System;

namespace iSocietyCare.NotificationService.Models
{
    public class TemplateGenerateView
    {
        public NotificationTypes NotificationType { get; set; }
        public String JsonData { get; set; }
        public NotificationQueue NotificationQueue { get; set; }
        public MessageTypes MessageType { get; set; }
        public Guid MessageId { get; set; }
        //EMailDataView _emailDataView;
        public EMailDataView EMailDataView { get; set; }
        //   [JsonIgnore]
        //    public EMailDataView EMailDataView
        //    {
        //        get
        //        {
        //            if (_emailDataView == null)
        //                _emailDataView = JsonData.ToObject<EMailDataView>();
        //            return _emailDataView;
        //        }
        //    }
    }
}
