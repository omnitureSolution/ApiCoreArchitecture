using FluentValidation;

namespace iSocietyCare.Core.Model.Insurance
{
    public class BuildingPolicyMaliciousDamageRateViewModel : ViewModel
    {
        public int BuildingMaliciousAreaId { get; set; }
        public int? Area { get; set; }
        public decimal? LoadingRate { get; set; }

    }

    public class BuildingPolicyMaliciousDamageRateViewModelValidator : AbstractValidator<BuildingPolicyMaliciousDamageRateViewModel>
    {
        public BuildingPolicyMaliciousDamageRateViewModelValidator()
        {
            RuleFor(p => p.Area).LessThanOrEqualTo(0).WithMessage("Area is required");
            RuleFor(p => p.LoadingRate).LessThanOrEqualTo(0).WithMessage("Loading Rate is required");

        }
    }

}
