using FluentValidation;
using System;
using System.Collections.Generic;

namespace Omniture.Core.Model.Account
{
    public class UsersViewModel : ViewModel
    {
        public int UserId { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }

    }

    public class UsersViewModelValidator : AbstractValidator<UsersViewModel>
    {
        public UsersViewModelValidator()
        {
            RuleFor(p => p.MobileNo).NotEmpty().WithMessage("User Name is required");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password is required");

        }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class RefreshTokenModel
    {
        public string Accesstoken { get; set; }
        public string Refreshtoken { get; set; }
    }

    public class LoginResponseModel
    {
        public string accessToken { get; set; }
        public DateTime expiredafter { get; set; }
        public string refreshToken { get; set; }
        public int ReferenceId { get; set; }
        public int UserId { get; set; }
        public string ImageUrl { get; set; }
    }
    public class UserList
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public Boolean IsActive { get; set; }
        public int PersonId { get; set; }
    }

    public class ChangePasswordModel
    {
        public int userId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
