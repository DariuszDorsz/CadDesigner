using CadDesigner.Aplication.DtoModels;
using CadDesigner.Domain.Interfaces;
using CadDesigner.Domain.Models;
using CadDesigner.Infrastructure.Persistence;
using CadDesigner.Infrastructure.Repositories;
using CadDesigner.Infrastructure.Validators;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

namespace CadDesigner.Infrastructure.Extension
{
    public static class ServiceCollectionExtensions
    {

        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DesignerDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("CadDesigner")));
            service.AddScoped<IDesignerRepository, DesignerRepository>();
            service.AddScoped<IServiceRepository, ServiceRepositor>();
            service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddControllers().AddFluentValidation();
            service.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            service.AddScoped<IValidator<DesignerQuery>, DesignerQueryValidator>();
        }
    }
}
