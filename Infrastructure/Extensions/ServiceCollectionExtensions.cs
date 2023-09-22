using CadDesigner.Domain.Interfaces;
using CadDesigner.Infrastructure.Persistence;
using CadDesigner.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Infrastructure.Extension
{
    public static class ServiceCollectionExtensions
    {

        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<DesignerDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("CadDesigner")));
            service.AddScoped<IDesignerRepository, DesignerRepository>();
            service.AddScoped<IServiceRepository, ServiceRepositor>();          
        }
    }
}
