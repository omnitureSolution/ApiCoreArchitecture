using FluentValidation;

namespace iSocietyCare.Core.Model.Insurance
{
    public class ContentPolicyAreaRateViewModel : ViewModel
    {
        public int ContentAreaId { get; set; }
        public int? ContentArea { get; set; }
        public decimal? ContentAreaRate { get; set; }
        public decimal? ContentAreaRateTenant { get; set; }
    }

    public class ContentPolicyAreaRateViewModelValidator : AbstractValidator<ContentPolicyAreaRateViewModel>
    {
        public ContentPolicyAreaRateViewModelValidator()
        {
            RuleFor(p => p.ContentArea).LessThanOrEqualTo(0).WithMessage("Content area is required");
            RuleFor(p => p.ContentAreaRate).LessThanOrEqualTo(0).WithMessage("Content area rate is required");
            RuleFor(p => p.ContentAreaRateTenant).LessThanOrEqualTo(0).WithMessage("Content area rate for tenant is required");

        }
    }

}
