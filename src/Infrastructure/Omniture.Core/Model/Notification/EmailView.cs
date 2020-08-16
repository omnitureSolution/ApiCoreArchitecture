using System;
using System.Collections.Generic;
using System.Text;

namespace Omniture.Core.Model.Notification
{
    public class EmailView
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime SendDateTime { get; set; }
    }
}
