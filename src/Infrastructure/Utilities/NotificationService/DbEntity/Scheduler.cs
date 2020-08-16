using iSocietyCare.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using iSocietyCare.NotificationService.Models;

namespace iSocietyCare.NotificationService.DbEntity
{
    public class Scheduler : BaseEntity
    {
        [Key]
        public int ScheduleId { get; set; }

        public string ScheduleType { get; set; }
        public DateTime NextDateTime { get; set; }
        public string FrequencyType { get; set; }
        public String CallType { get; set; }
        public int FrequencyValue { get; set; }
        public string Action { get; set; }
        public string Parameter { get; set; }
        public Boolean IsActive { get; set; }

        [NotMapped]
        public FrequencyType FrequencyTypeValue
        {
            get
            {
                Enum.TryParse(this.FrequencyType, out FrequencyType frequencyTypeValue);
                return frequencyTypeValue;
            }
        }
        [NotMapped]
        public CallTypes CallTypeValue
        {
            get
            {
                Enum.TryParse(this.CallType, out CallTypes callTypeValueValue);
                return callTypeValueValue;
            }
        }
        //[NotMapped]
        //public ScheduleType ScheduleTypeValue
        //{
        //    get
        //    {
        //        Enum.TryParse(this.ScheduleType, out ScheduleType scheduleTypeValue);
        //        return scheduleTypeValue;
        //    }
        //}
        [NotMapped]
        public int FreqMin
        {
            get
            {
                switch (FrequencyTypeValue)
                {
                    case Models.FrequencyType.Min:
                        return 1;
                    case Models.FrequencyType.Hourly:
                        return 60;
                    case Models.FrequencyType.Daily:
                        return 60 * 24;
                    case Models.FrequencyType.Weekly:
                        return 60 * 24 * 7;
                    default:
                        return 10;
                }
            }
        }
    }

}
