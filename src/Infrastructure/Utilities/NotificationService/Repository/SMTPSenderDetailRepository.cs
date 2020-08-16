//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Omniture.Db;
//using Omniture.NotificationService.Context;
//
//
//

//namespace Omniture.NotificationService.Repository
//{
//    public class SMTPSenderDetailRepository : Repository<SMTPSenderDetail>, ISMTPSenderDetail
//    {

//        IEMailQueue _queue;
//        public SMTPSenderDetailRepository(OmnitureNotificationContext context, IEMailQueue queue) : base(context)
//        {
//            _queue = queue;
//        }

//        public void UdpatePassword(SMTPSenderViewModel smtpSender)
//        {
//            var sender = All.FirstOrDefault(t => string.Equals(t.MailFrom, smtpSender.Email, StringComparison.OrdinalIgnoreCase));
//            sender.Password = smtpSender.Password;
//            Update(sender);
//            var res = _queue.All.Where(t => t.From == smtpSender.Email && (DateTime.Now - t.ModifiedDate.Value).TotalDays <= 7
//                    && t.Status == NotificationSentStatus.Failed);
//            foreach (var item in res)
//            {
//                item.ModifiedBy = null;
//                _queue.Update(item);
//            }
//        }
//    }
//}

