using System.Collections.Generic;

namespace iSocietyCare.Core.Model.Insurance
{
    public partial class UnderWriterQuestionViewModel : ViewModel
    {
        public UnderWriterQuestionViewModel()
        {
            ChildUnderWriterQuestion = new HashSet<UnderWriterQuestionViewModel>();
            //UnderWriterAnswer = new HashSet<UnderWriterAnswerViewModel>();
            //UnderWriterQuestionPolicyType = new HashSet<UnderWriterQuestionPolicyTypeViewModel>();
        }
        public int UnderWriterQuestionId { get; set; }
        public string QuestionText { get; set; }
        public int DisplayOrder { get; set; }
        public int? Loading { get; set; }
        public string CorrectAnswer { get; set; }
        public int? ParentUnderWriterQuestionId { get; set; }
        public string QuestionName { get; set; }
        public string Answer { get; set; }
        //public virtual UnderWriterQuestionViewModel ParentUnderWriterQuestion { get; set; }
        //public virtual UnderWriterAnswerDetailViewModel UnderWriterAnswerDetail { get; set; }
        public virtual ICollection<UnderWriterQuestionViewModel> ChildUnderWriterQuestion { get; set; }
        //public virtual ICollection<UnderWriterAnswerViewModel> UnderWriterAnswer { get; set; }
        //public virtual ICollection<UnderWriterQuestionPolicyTypeViewModel> UnderWriterQuestionPolicyType { get; set; }
    }
}
