using Omniture.Db.Shared.Configuration;
using Omniture.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Omniture.Db.Shared.Services
{
    public class OmnitureConfiguration : IOmnitureConfiguration
    {
        private OmnitureCommonContext _omnitureContext;
        private readonly IUserInfo _userInfo;
        public OmnitureConfiguration(OmnitureCommonContext omnitureContext, IUserInfo userInfo)
        {
            _omnitureContext = omnitureContext;
            _userInfo = userInfo;
        }

        public string GetConfigValue(string key)
        {
            var value = _omnitureContext.SystemConfiguration
                 .Where(t => t.IsActive && t.ConfigKey.ToLower() == key.ToLower())
                 .Select(t => t.ConfigValue)
                 .FirstOrDefault();
            return value ?? string.Empty;
        }

        public string GetConfigValue(ConfigurationKeys key)
        {
            return GetConfigValue(key.ToString());
        }

        public SystemConfigurationView GetConfig(string key)
        {
            var value = _omnitureContext.SystemConfiguration
                  .Where(t => t.IsActive && string.Equals(t.ConfigKey, key, StringComparison.OrdinalIgnoreCase))
                  .Select(t => new SystemConfigurationView
                  {
                      ConfigKey = t.ConfigKey,
                      ConfigValue = t.ConfigValue,
                      DisplayName = t.DisplayName,
                      AdditionalDetails = t.AdditionalDetails
                  })
                  .FirstOrDefault();
            return value;
        }

        public SystemConfigurationView GetConfig(ConfigurationKeys key)
        {
            return GetConfig(key.ToString());
        }

        public SystemConfigurationView GetConfig(ConfigurationKeys key, DateTime StartDate,
          DateTime? EndDate)
        {
            return _omnitureContext.SystemConfiguration.Where(t =>
              t.ConfigKey.ToLower() == key.ToString().ToLower() &&
             t.StartDate <= StartDate && (t.EndDate >= EndDate || t.EndDate == null)).Select(t => new SystemConfigurationView
             {
                 ConfigKey = t.ConfigKey,
                 ConfigValue = t.ConfigValue,
                 DisplayName = t.DisplayName,
                 AdditionalDetails = t.AdditionalDetails
             }).FirstOrDefault();
        }

        public List<SystemConfigurationView> GetAllConfig(ConfigurationKeys key, DateTime StartDate,
          DateTime? EndDate)
        {
            return _omnitureContext.SystemConfiguration.Where(t =>
             string.Equals(t.ConfigKey, key.ToString(), StringComparison.CurrentCultureIgnoreCase) &&
             t.StartDate >= StartDate && (t.EndDate <= EndDate || t.EndDate == null)).Select(t => new SystemConfigurationView
             {
                 ConfigKey = t.ConfigKey,
                 ConfigValue = t.ConfigValue,
                 DisplayName = t.DisplayName,
                 AdditionalDetails = t.AdditionalDetails,
                 StartDate = t.StartDate,
                 EndDate = t.EndDate
             }).ToList();
        }

        public SystemConfigurationView GetConfig(int societyId, ConfigurationKeys key, DateTime StartDate,
      DateTime? EndDate)
        {
            return _omnitureContext.SystemConfiguration.Where(t =>
              t.ConfigKey.ToUpper() == key.ToString().ToUpper() &&
             t.StartDate <= StartDate && (t.EndDate >= EndDate || t.EndDate == null)).Select(t => new SystemConfigurationView
             {
                 ConfigKey = t.ConfigKey,
                 ConfigValue = t.ConfigValue,
                 DisplayName = t.DisplayName,
                 AdditionalDetails = t.AdditionalDetails
             }).FirstOrDefault();
        }
    }
}
