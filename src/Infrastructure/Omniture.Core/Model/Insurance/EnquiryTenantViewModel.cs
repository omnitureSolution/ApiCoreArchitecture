using FluentValidation;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.Insurance
{
    public class EnquiryTenantViewModel : ViewModel
    {
        public int EnquiryTenantId { get; set; }
        public int EnquiryId { get; set; }
        public int TenantId { get; set; }
        public TenantTypes TenantTypeId { get; set; }
    }


    public class EnquiryTenantViewModelValidator : AbstractValidator<EnquiryTenantViewModel>
    {
        public EnquiryTenantViewModelValidator()
        {
            RuleFor(p => p.EnquiryId).LessThanOrEqualTo(0).WithMessage("Enquiry is required");
            RuleFor(p => p.TenantId).LessThanOrEqualTo(0).WithMessage("Tenant is required");
        }
    }
}
