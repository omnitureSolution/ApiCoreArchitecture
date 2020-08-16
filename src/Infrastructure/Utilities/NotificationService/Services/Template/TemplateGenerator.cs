using Omniture.Core.Interfaces.Common;
using Omniture.Core.Interfaces.Notification;
using Omniture.Core.Interfaces.Notification.Templates;
using Omniture.Core.Models.Notification;
using Omniture.Db.Abstractions.Enums;
using Omniture.Db.Shared.Services; 

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omniture.NotificationService.Services.Template
{
    public class TemplateGenerator : ITemplateGenerator
    {
        private IMessageTemplate _notificationtemplate;
        private readonly OmnitureConfiguration _config;
        private readonly Func<NotificationTypes, ITemplates> _templateSelectors;
        private readonly Func<string, IMessageData> _dataHandler;
        private readonly string loadedUrl = "";

        public TemplateGenerator(Func<NotificationTypes, ITemplates> templateSelectors,
        IMessageTemplate notificationtemplate,
        Func<string, IMessageData> dataHandler,
            OmnitureConfiguration config)
        {
            _templateSelectors = templateSelectors;
            _notificationtemplate = notificationtemplate;
            _config = config;
            _dataHandler = dataHandler;
        }

        public ITemplates GetTemplateHandler(TemplateGenerateView templateGenerateView)
        {
            var templateHandler = SetHandler(templateGenerateView);
            //if (loadedUrl != templateGenerateView.FeatureEndPoint)
            //{
            //    loadedUrl = templateGenerateView.FeatureEndPoint;
            //    templateGenerateView.JsonData = GetDataForTemplate(templateGenerateView.FeatureEndPoint,
            //        templateGenerateView.Parameters);
            //}
            //templateGenerateView.JsonData = "{'to':['ebids2018@gmail.com','test1@t.com']}";
            templateGenerateView.EMailDataView = _dataHandler("SMS").GetMessageData(templateGenerateView.MessageId);
            templateHandler.TemplateView = templateGenerateView;
            return templateHandler;
        }

        public ITemplates GetTemplateHandler(TemplateGenerateView templateGenerateView, string JsonData)
        {
            var templateHandler = SetHandler(templateGenerateView);
            templateGenerateView.JsonData = JsonData;
            templateHandler.TemplateView = templateGenerateView;
            return templateHandler;
        }

        private ITemplates SetHandler(TemplateGenerateView templateGenerateView)
        {
            var templateHandler = _templateSelectors(templateGenerateView.NotificationType);
            if (templateHandler == null)
                throw new InvalidOperationException($"Template handler not defined for " +
                                                    $"{templateGenerateView.NotificationType.ToString()}");

            var template = _notificationtemplate.GetTemplate();
            templateHandler.Template = template ?? throw new KeyNotFoundException($"Template not found for " +
                                              $"SMS");

            return templateHandler;

        }
        private string GetDataForTemplate(string endpoint, string parameters)
        {
            //temp
            return "";
            //    string url = endpoint.Contains("{{") ? _config.ReplaceConfiguration(endpoint) :
            //$"{_config.GetConfigValue(SystemConfig.VisionPlusAPIUrl.ToString())}//{endpoint}";

            //    return HttpApiClient.Get($"{url}?"
            //        + getQueryStringFromJson(parameters), "", new System.Threading.CancellationToken());

        }

        private string getQueryStringFromJson(string jsonString)
        {
            var jObj = (JObject)JsonConvert.DeserializeObject(jsonString);
            return String.Join("&",
                        jObj.Children().Cast<JProperty>()
                        .Select(jp => jp.Name + "=" + HttpUtility.UrlEncode(jp.Value.ToString())));
        }
    }
}
