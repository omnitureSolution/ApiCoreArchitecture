using Omniture.Core.Model.Account;
using System;
using System.Collections.Generic;

namespace Omniture.Core.Interfaces.Services.Account
{
    public interface IUserService : IServiceCommon
    {
        List<UserList> GetUsers();
        LoginResponseModel Login(LoginModel request);
        LoginResponseModel Refresh(string accessToken, string RefreshToken,int societyId);
        Boolean ChangePassword(ChangePasswordModel changePassword);
    }
}
