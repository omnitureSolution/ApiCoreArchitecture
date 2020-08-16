using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Omniture.Core.Model.Common;

namespace Omniture.NotificationService.Services.Template
{
    public abstract class TemplateFormatter
    {
        private readonly IHostingEnvironment _hostEnvironment;

        public TemplateFormatter(IHostingEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public String FormatMessage(String templateName, EMailDataView eMailData)
        {
            String messageTemplate = File.ReadAllText(Path.Combine(_hostEnvironment.ContentRootPath,
                                        "Template", templateName), Encoding.UTF8);
            return ReplaceTags(messageTemplate, eMailData);
        }
        protected String ReplaceTags(string messageTemplate, EMailDataView eMailData)
        {
            if (string.IsNullOrEmpty(eMailData.TemplateData))
                return messageTemplate;
            messageTemplate = ReplaceTemplate(messageTemplate);
            string pattern = "<isociety>(.*?)<\\/isociety>";
            var matches = Regex.Matches(messageTemplate, pattern, RegexOptions.IgnoreCase);
            if (matches.Count > 0)
            {
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(eMailData.TemplateData);

                foreach (Match m in matches)
                {
                    if (dic.Any(t => string.Equals(t.Key, m.Groups[1].Value, StringComparison.OrdinalIgnoreCase)))
                    {
                        //if (DateTime.TryParse(SearchDictionary(dic, m.Groups[1].Value.ToLower()), out DateTime dt))
                        //{
                        //    messageTemplate = messageTemplate.Replace(m.Value, dt.ToString("dd/MM/yyyy HH:mm"));
                        //}
                        //else
                            messageTemplate = messageTemplate.Replace(m.Value, SearchDictionary(dic, m.Groups[1].Value));
                    }
                }
            }
            return messageTemplate;
        }
        private string ReplaceTemplate(string messageTemplate)
        {
            string pattern = "<visiontemplate>(.*?)<\\/visiontemplate>";
            var matches = Regex.Matches(messageTemplate, pattern, RegexOptions.IgnoreCase);
            if (matches.Count > 0)
            {

                foreach (Match m in matches)
                {
                    var text = File.ReadAllText(Path.Combine(_hostEnvironment.ContentRootPath,
                                            "Template", m.Groups[1].Value.ToLower()));
                    messageTemplate = messageTemplate.Replace(m.Value, text);
                }

            }
            return messageTemplate;
        }
        private string SearchDictionary(Dictionary<string, object> myDictionary, string key)
        {
            var value = myDictionary.FirstOrDefault(x => String.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value;
            return value == null ? "" : value.ToString();
        }
    }
}
