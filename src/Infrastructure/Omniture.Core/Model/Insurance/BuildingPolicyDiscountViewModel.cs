using FluentValidation;
using System;

namespace iSocietyCare.Core.Model.Insurance
{
    public class BuildingPolicyDiscountViewModel : ViewModel
    {
        public int BuildingSumDiscountId { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? DeleteAfter { get; set; }

    }


    public class BuildingPolicyDiscountViewModelValidator : AbstractValidator<BuildingPolicyDiscountViewModel>
    {
        public BuildingPolicyDiscountViewModelValidator()
        {
            RuleFor(p => p.MinValue).LessThanOrEqualTo(0).WithMessage("Min value is required");
            RuleFor(p => p.MaxValue).LessThanOrEqualTo(0).WithMessage("Max value is required");
            RuleFor(p => p.MaxValue).LessThanOrEqualTo(p => p.MinValue).WithMessage("Max value must be greater than min value");
            RuleFor(p => p.Discount).LessThanOrEqualTo(0).WithMessage("Discount is required");

        }
    }

}
