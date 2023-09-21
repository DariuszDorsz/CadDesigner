using CadDesigner.Aplication.Mapping_Profile;
using CadDesigner.Aplication.Middleware;
using CadDesigner.Aplication.Services;
using CadDesigner.Domain.Entitys;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CadDesigner.Aplication.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAplication(this IServiceCollection service)
        {
            service.AddScoped<ErrorHandlingMiddleware>();
            service.AddAutoMapper(typeof(CadDesignerMapingProfile));
            service.AddScoped<IDesignerService, DesignerService>();
            service.AddScoped<IServiceService, ServiceService>();
        
        }
    }
}
