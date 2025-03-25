using Dastone.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dastone.CrossCutting.InversionOfControl.AuctionManagerDbConfig
{
    public static class DependencyInjectionActionManagerDbConfig
    {
        public static IServiceCollection AddMySqlDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DastoneDbContext>(options =>
            {
                var server = configuration["database:mysql:server"];
                var port = configuration["database:mysql:port"];
                var database = configuration["database:mysql:database"];
                var username = configuration["database:mysql:username"];
                var password = configuration["database:mysql:password"];

                var connectionString = $"Server={server};Port={port};Database={database};Uid={username};Pwd={password}";
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            return services;
        }

        public static IServiceCollection UpdateDatabase(this IServiceCollection services, IApplicationBuilder app)
        {
            var seconds = 60;
            var minutes = 20;
            var commandTimeout = seconds * minutes;

            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DastoneDbContext>())
                {
                    context.Database.SetCommandTimeout(commandTimeout);

                    if (context.Database.GetPendingMigrations().Any())
                        context.Database.Migrate();
                    context.Database.SetCommandTimeout(null);
                }
            }

            return services;
        }
    }
}
