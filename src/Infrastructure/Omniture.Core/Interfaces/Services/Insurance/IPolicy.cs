using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using iSocietyCare.Core.Model.Insurance;

namespace iSocietyCare.Core.Interfaces.Services.Insurance
{
    public interface IPolicyService: IServiceCommon
    {
        Task<PolicyViewModel> GetPolicy(int policyId );
        //Task<List<lstUnderWriterQuestion>> GetUnderWriterQuestionByName(string questionName);
        Task<List<IActionResult>> GetUnderWriterAnswerByName(int policyId);
    }
}
