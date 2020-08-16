using System.Collections.Generic;
using System.Threading.Tasks;
using iSocietyCare.Core.Model.Insurance;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Interfaces.Services.Insurance
{
    public interface IUnderWriterQuestionService: IServiceCommon
    {
        Task<List<UnderWriterQuestionViewModel>> GetUnderWriterQuestions(QuestionPolicyTypes questionPolicyType);
    }
}
