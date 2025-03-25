using Dastone.Domain.Interfaces.Service;
using Dastone.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dastone.CrossCutting.InversionOfControl.Service
{
    public static class ServiceDependency
    {
        public static IServiceCollection AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            return services;
        }
    }
}
