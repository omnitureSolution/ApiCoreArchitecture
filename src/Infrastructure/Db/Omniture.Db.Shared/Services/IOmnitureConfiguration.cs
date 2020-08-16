using Omniture.Db.Shared.Configuration;
using System;
using System.Collections.Generic;

namespace Omniture.Db.Shared.Services
{
    public interface IOmnitureConfiguration
    {
        string GetConfigValue(String key);
        string GetConfigValue(ConfigurationKeys key);
        SystemConfigurationView GetConfig(ConfigurationKeys key);
        SystemConfigurationView GetConfig(String key);
        SystemConfigurationView GetConfig(ConfigurationKeys key, DateTime StartDate,
          DateTime? EndDate);
        List<SystemConfigurationView> GetAllConfig(ConfigurationKeys key, DateTime StartDate,
          DateTime? EndDate);
        SystemConfigurationView GetConfig(int societyId, ConfigurationKeys key, DateTime StartDate,
      DateTime? EndDate);
    }
}

