
using CadDesigner.Aplication.MappingProfile;
using CadDesigner.Aplication.Middleware;
using CadDesigner.Aplication.Services;
using CadDesigner.Aplication.Setings;
using CadDesigner.Domain.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CadDesigner.Aplication.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAplication(this IServiceCollection service, IConfiguration configuration)
        {
            var authenticationSettings = new AuthenticationSettings();
            configuration.GetSection("Authentication").Bind(authenticationSettings);

            service.AddSingleton(authenticationSettings);
            service.AddScoped<ErrorHandlingMiddleware>();
            service.AddAutoMapper(typeof(CadDesignerMapingProfile));
            service.AddScoped<IDesignerService, DesignerService>();
            service.AddScoped<IServiceService, ServiceService>();
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            service.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });

        }
    }
}
