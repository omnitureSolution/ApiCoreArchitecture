using Omniture.Db.Abstractions.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Omniture.Db.Entity.Notification
{
    //[Table("Scheduler", Schema = "not")]
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
                Enum.TryParse(FrequencyType, out FrequencyType frequencyTypeValue);
                return frequencyTypeValue;
            }
        }
        [NotMapped]
        public CallTypes CallTypeValue
        {
            get
            {
                Enum.TryParse(CallType, out CallTypes callTypeValueValue);
                return callTypeValueValue;
            }
        }
        [NotMapped]
        public ScheduleType ScheduleTypeValue
        {
            get
            {
                Enum.TryParse(ScheduleType, out ScheduleType scheduleTypeValue);
                return scheduleTypeValue;
            }
        }
        [NotMapped]
        public int FreqMin
        {
            get
            {
                return 10;
                //switch (FrequencyTypeValue)
                //{
                //    case FrequencyType.Min:
                //        return 1;
                //    case FrequencyType.Hourly:
                //        return 60;
                //    case FrequencyType.Daily:
                //        return 60 * 24;
                //    case FrequencyType.Weekly:
                //        return 60 * 24 * 7;
                //    default:
                //        return 10;
                //}
            }
        }

        [NotMapped]
        public DateTime LatestNextDateTime
        {
            get
            {
                switch (FrequencyTypeValue)
                {
                    case Abstractions.Enums.FrequencyType.Min:
                        return NextDateTime.AddMinutes(FrequencyValue);
                    case Abstractions.Enums.FrequencyType.Hourly:
                        return NextDateTime.AddHours(FrequencyValue);
                    case Abstractions.Enums.FrequencyType.Daily:
                        return NextDateTime.AddDays(FrequencyValue);
                    case Abstractions.Enums.FrequencyType.Weekly:
                        return NextDateTime.AddDays(7 * FrequencyValue);
                    case Abstractions.Enums.FrequencyType.Monthly:
                        return NextDateTime.AddMonths(FrequencyValue);
                    case Abstractions.Enums.FrequencyType.Yearly:
                        return NextDateTime.AddYears(FrequencyValue);
                    default:
                        return NextDateTime;
                }
            }
        }
    }

}
