namespace iSocietyCare.Core.Model.Insurance
{
    public partial class UnderWriterAnswerViewModel : ViewModel
    {

        public int UnderWriterAnswerId { get; set; }
        public int PolicyId { get; set; }
        public int UnderWriterQuestionId { get; set; }
        public int? PolicyHolderAgeId { get; set; }
        public int? PropertyAgeId { get; set; }
        public int? PropertyTypeId { get; set; }
        public int? TenancyTypeId { get; set; }
        public int? PropertyGradeId { get; set; }
        public int? ExcessLevelId { get; set; }

        public int? RoofConstructionTypeId { get; set; }
        public int? RoofAreaId { get; set; }
        public int? ConvictionTypeId { get; set; }
        public int? ConstructionTypeId { get; set; }
        public string QuestionText { get; set; }
        public int AnswerNumber { get; set; }
        public virtual lstConstructionTypeViewModel ConstructionType { get; set; }
        public virtual lstConvictionTypeViewModel ConvictionType { get; set; }
        //public virtual PolicyViewModel Policy { get; set; }
        public virtual lstExcessLevelViewModel EnquiryNavigation { get; set; }
        public virtual lstPoliceHolderAgeViewModel PolicyHolderAge { get; set; }
        public virtual lstPropertyAgeViewModel PropertyAge { get; set; }
        public virtual lstPropertyGradeViewModel PropertyGrade { get; set; }
        public virtual lstPropertyTypeViewModel PropertyType { get; set; }
        public virtual lstRoofAreaViewModel RoofArea { get; set; }
        public virtual lstConstructionTypeViewModel RoofConstructionType { get; set; }
        public virtual lstTenancyTypeViewModel TenancyType { get; set; }
        public virtual UnderWriterQuestionViewModel UnderWriterQuestion { get; set; }
    }
}
