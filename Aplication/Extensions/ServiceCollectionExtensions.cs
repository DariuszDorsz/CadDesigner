
using CadDesigner.Aplication.MappingProfile;
using CadDesigner.Aplication.Middleware;
using CadDesigner.Aplication.Services;
using Microsoft.Extensions.DependencyInjection;



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
