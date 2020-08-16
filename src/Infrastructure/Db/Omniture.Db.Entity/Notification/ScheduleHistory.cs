using Omniture.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Omniture.Db.Entity.Notification
{
    //[Table("ScheduleHistory", Schema = "not")]
    public class ScheduleHistory : BaseEntity
    {
        [Key]
        public int ScheduleId { get; set; }
        public DateTime HistoryDateTime { get; set; }
        public string Response { get; set; }
    }
}
