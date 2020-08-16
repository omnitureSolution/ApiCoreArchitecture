using System;
using System.ComponentModel.DataAnnotations;

namespace Omniture.Db.Shared.Configuration
{
  public class SystemConfiguration : BaseEntity
  {
    [Key]
    public int SystemConfigurationId { get; set; }
    public string ConfigKey { get; set; }
    public string ConfigValue { get; set; }
    public bool IsActive { get; set; }
    public string DisplayName { get; set; }
    public string AdditionalDetails { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
  }

  public class SystemConfigurationView
  {
    public string ApplicationName { get; set; }
    public string ConfigKey { get; set; }
    public string ConfigValue { get; set; }
    public string DisplayName { get; set; }
    public string AdditionalDetails { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
  }
}
