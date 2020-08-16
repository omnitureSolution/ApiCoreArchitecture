using FluentValidation;

namespace iSocietyCare.Core.Model.Insurance
{
    public class BuildingPolicyAreaRateViewModel : ViewModel
    {
        public int BuildingAreaId { get; set; }
        public int? BuildingArea { get; set; }
        public decimal? BuildingAreaRate { get; set; }

    }


    public class BuildingPolicyAreaRateViewModelValidator : AbstractValidator<BuildingPolicyAreaRateViewModel>
    {
        public BuildingPolicyAreaRateViewModelValidator()
        {
            RuleFor(p => p.BuildingArea).NotEmpty().WithMessage("Area is required");
            RuleFor(p => p.BuildingAreaRate).NotEmpty().WithMessage("Area rate is required");

        }
    }
}
