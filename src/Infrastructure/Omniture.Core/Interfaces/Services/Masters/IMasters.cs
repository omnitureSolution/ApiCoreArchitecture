using System.Collections.Generic;
using System.Threading.Tasks;
using Omniture.Core.Interfaces.Common;

namespace Omniture.Core.Interfaces.Services.Masters
{
    public interface IMasters : IServiceCommon
    {
      
       
        Task<List<ListTable>> GetCountries();
    }
}
