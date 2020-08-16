using Omniture.Core.Model.Common;
using System;

namespace Omniture.Core.Interfaces.Common
{
    public interface IMessageData
    {
        EMailDataView GetMessageData(Guid messageId);
    }
}
