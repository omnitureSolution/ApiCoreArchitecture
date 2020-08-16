using Omniture.Core.Model.Common;
using Omniture.Db.Abstractions.Enums;
using Omniture.Db.Entity.Notification;
using System;

namespace Omniture.Core.Models.Notification
{
    public class TemplateGenerateView
    {
        public NotificationTypes NotificationType { get; set; }
        public String JsonData { get; set; }
        public NotificationQueue NotificationQueue { get; set; }
 
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
