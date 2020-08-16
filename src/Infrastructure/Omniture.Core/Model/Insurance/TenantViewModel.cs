using FluentValidation;
using System;
using System.Collections.Generic;
using iSocietyCare.Db.Abstractions.Enums;

namespace iSocietyCare.Core.Model.Insurance
{
    public class TenantViewModel : ViewModel
    {
        public TenantViewModel()
        {
            Contact = new HashSet<ContactsViewModel>();
        }
        public int TenantId { get; set; }
        public int TitleId { get; set; }
        public string OtherTitle { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public EntryTypes EntryFrom { get; set; }
        public bool? IsSanctionsCheck { get; set; }
        public bool? IsPositiveSanctionsMatch { get; set; }
        public bool? IsGdprmarkPermission { get; set; }
        public DateTime? GdprmarkPermDate { get; set; }
        public bool? IsGdprmarkActive { get; set; }
        public int? ReferenceId { get; set; }
        public ICollection<ContactsViewModel> Contact { get; set; }
        public AddressViewModel Address { get; set; }
        public string TenantStatus { get; set; }

    }

    public class TenantInfo : ViewModel
    {
        public int TitleId { get; set; }
        public String Title { get; set; }
        public string Forename { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public int TenantId { get; set; }

    }




    public class TenantViewModelValidator : AbstractValidator<TenantViewModel>
    {
        public TenantViewModelValidator()
        {
            RuleFor(p => p.TitleId).NotEmpty().WithMessage("Title is required");
            RuleFor(p => p.Forename).NotEmpty().WithMessage("Forename Type is required");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Surname Type is required");
            RuleFor(p => p.EntryFrom).NotEmpty().WithMessage("Entry from is required");

        }
    }
}
