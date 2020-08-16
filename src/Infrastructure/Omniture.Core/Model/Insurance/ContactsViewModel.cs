using FluentValidation;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.Insurance
{
    public class ContactsViewModel : ViewModel
    {
        public int ContactId { get; set; }
        public ContactTypes ContactTypeId { get; set; }
        public int TenantId { get; set; }
        public int TenantAddressId { get; set; }
        public string ContactInfo { get; set; }
        public string Position { get; set; }
        public string ContactName { get; set; }

    }

    public class ContactsViewModelValidator : AbstractValidator<ContactsViewModel>
    {
        public ContactsViewModelValidator()
        {
            RuleFor(p => p.TenantId).LessThanOrEqualTo(0).WithMessage("Tenant is required");
            RuleFor(p => p.TenantAddressId).LessThanOrEqualTo(0).WithMessage("Addres is required");
            RuleFor(p => p.ContactInfo).NotEmpty().WithMessage("Contact information is required");

        }
    }
}
