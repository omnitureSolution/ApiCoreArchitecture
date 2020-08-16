using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.Insurance
{
    public partial class UnderWriterQuestionPolicyTypeViewModel : ViewModel
    {
        public int UnderWriterQuestionPolicyTypeId { get; set; }
        public int UnderWriterQuestionId { get; set; }
        public QuestionPolicyTypes QuestionPolicyTypeId { get; set; }

        public virtual UnderWriterQuestionViewModel UnderWriterQuestion { get; set; }
    }
}
