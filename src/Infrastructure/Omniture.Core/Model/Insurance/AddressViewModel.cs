using FluentValidation;
using System.Collections.Generic;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.Insurance
{
    public class AddressViewModel : ViewModel
    {
        public int AddressId { get; set; }
        public AddressTypes AddressTypeId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string PostcodePart1 { get; set; }
        public string PostcodePart2 { get; set; }
        public string AddressJson { get; set; }
        public int? AdressJsonTypeId { get; set; }
        public ICollection<ContactsViewModel> Contancts { get; set; }
    }

    public class AddressViewModelValidator : AbstractValidator<AddressViewModel>
    {
        public AddressViewModelValidator()
        {
            RuleFor(p => p.AddressLine1).NotEmpty().WithMessage("Address is required");
            RuleFor(p => p.AddressTypeId).NotEmpty().WithMessage("Address Type is required");

        }
    }

}
