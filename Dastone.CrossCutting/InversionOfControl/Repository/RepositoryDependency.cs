using Dastone.Data.Repository;
using Dastone.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Dastone.CrossCutting.InversionOfControl.Repository
{
    public static class RepositoryDependency
    {
        public static IServiceCollection AddMySqlRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            return services;
        }
    }
}
