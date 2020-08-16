using Omniture.Core.Interfaces.Services.Account;
using Omniture.Core.Model.Account;
using Omniture.Db.Entity.Database;
using Omniture.Shared.Common;
using Omniture.Shared.Crypto;
using Omniture.Shared.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Omniture.Insurance.Services.Account
{
    public class UserService : IUserService
    {
        private OmnitureContext _omnitureContext; 
        private IUser _userRepo;
        private IOptions<AuthenticationKeys> _authKey;
        private readonly IUserInfo _userInfo;

        public UserService(OmnitureContext omnitureContext, IUser userRepo,
             IUserInfo userInfo,
            IOptions<AuthenticationKeys> authKey)
        {
            _omnitureContext = omnitureContext;
            _userRepo = userRepo;
            _authKey = authKey;
            _userInfo = userInfo;
        }

        public LoginResponseModel Login(LoginModel request)
        {
           
            return new LoginResponseModel
            {
                 
            };
        }

        public LoginResponseModel Refresh(string accessToken, string RefreshToken, int SocietyId)
        {
            

            var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.GivenName, "") };

            return new LoginResponseModel()
            {
                accessToken = GenerateAccessToken(claims),
                expiredafter = DateTime.UtcNow.AddMinutes(_authKey.Value.ExpireInMin),
                refreshToken = RefreshToken,
               
            };
        }

        public bool ChangePassword(ChangePasswordModel changePassword)
        {
            
            return true;
        }

        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authKey.Value.SigningKey));

            var jwtToken = new JwtSecurityToken(issuer: _authKey.Value.Issuer,
                audience: _authKey.Value.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authKey.Value.SigningKey)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        public List<UserList> GetUsers()
        {
            return null;
        }
    }
}

