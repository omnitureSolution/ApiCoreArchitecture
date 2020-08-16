using VisionPlus.Shared.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionPlus.Core.Model.Account;

namespace VisionPlusAPI.Authorization
{
    public static class Authorization
    {
        public static void AddAuth(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddCors(o => o.AddPolicy("AllowCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader().Build();
            }));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["AuthenticationKeys:Issuer"],
                        ValidAudience = configuration["AuthenticationKeys:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(configuration["AuthenticationKeys:SigningKey"]))
                    };
                    jwtBearerOptions.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            if (context.SecurityToken is JwtSecurityToken accessToken)
                            {
                                var userInfo = accessToken.Claims.FirstOrDefault(a => a.Type == "given_name")?.Value;
                                context.HttpContext.Request.Headers.Add("user", userInfo);
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddScoped<IUserInfo, UserInformation>(provider =>
            {
                var context = provider.GetService<IHttpContextAccessor>();
                if (context.HttpContext == null)
                    return new UserInformation();
                
                var user = context.HttpContext.Request.Headers["user"];
                if (user.Any())
                    return JsonConvert.DeserializeObject<UserInformation>(user);
                return new UserInformation();
            }); 
        }
    }
}
