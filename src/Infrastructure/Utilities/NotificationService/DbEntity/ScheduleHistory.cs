using iSocietyCare.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class ScheduleHistory : BaseEntity
    {
        [Key]
        public int ScheduleId { get; set; }
        public DateTime HistoryDateTime { get; set; }
        public string Response { get; set; }
    }
}
