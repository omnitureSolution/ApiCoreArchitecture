using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.Insurance
{
    public partial class UnderWriterAnswerDetailViewModel : ViewModel
    {

        public int UnderWriterAnswerDetailId { get; set; }
        public int PolicyId { get; set; }
        public int UnderWriterQuestionId { get; set; }
        public string Answer { get; set; }
        public AnswerTypes AnswerType { get; set; }
        public string Description { get; set; }
        public string QuestionText { get; set; }
        public int AnswerNumber { get; set; }
        //public virtual PolicyViewModel Policy { get; set; }
        //public virtual UnderWriterQuestionViewModel UnderWriterQuestion { get; set; }
    }
}
