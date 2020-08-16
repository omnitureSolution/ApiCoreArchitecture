namespace iSocietyCare.NotificationService.Models
{
    public enum NotificationSentStatus
    {
        New = 0,
        Processing = 1,
        Failed = 2,
        Sent = 3,
        Disabled = 4,
        Partial = 5
    }
    public enum FrequencyType
    {
        Min = 0,
        Hourly = 1,
        Daily = 2,
        Weekly = 3,
    }
    public enum CallTypes
    {
        Api,
        Assembly
    }
   
}


