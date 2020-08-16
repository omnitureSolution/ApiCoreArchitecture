using System;
using Omniture.Core.Model.Common;
using Omniture.Core.Models.Notification;
using Omniture.Db.Entity.Notification;

namespace Omniture.Core.Interfaces.Notification.Templates
{
    public interface ITemplateGenerator
    {
        ITemplates GetTemplateHandler(TemplateGenerateView templateGenerateView);
        ITemplates GetTemplateHandler(TemplateGenerateView templateGenerateView, String JsonData);
    }

    public interface ITemplates
    {
        MessageTemplate Template { get; set; }
        TemplateGenerateView TemplateView { get; set; }
        MessageTemplateView GetMessage();
    }

    public interface ISMSTemplateGenerator : ITemplates
    {
    }

    public interface IEmailTemplateGenerator : ITemplates
    {
        String FormatMessage(String messageTemplate, EMailDataView eMailData);
    }

    public interface IEmailTemplate : ITemplates
    {

    }
}
