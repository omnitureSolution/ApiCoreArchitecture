namespace Omniture.Db.Abstractions.Enums
{
    public enum NotificationTypes
    {
        Email = 1,
        SMS = 2
    }


    public enum NotificationSentStatus
    {
        New = 0,
        Processing = 1,
        Failed = 2,
        Sent = 3,
        Disabled = 4,
        Partial = 5
    }
    public enum ScheduleType
    {
        none = 1
    }
    public enum FrequencyType
    {
        Min = 0,
        Hourly = 1,
        Daily = 2,
        Weekly = 3,
        Monthly = 4,
        Yearly = 5
    }
    public enum CallTypes
    {
        Api,
        Assembly
    }
    public enum MaintenanceStatus
    {
        Paid = 0,
        NotPaid = 1
    }

    public enum PaymentTypes
    {
        Cash = 0,
        Cheque = 1
    }
}
