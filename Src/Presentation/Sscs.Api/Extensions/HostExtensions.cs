using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sscs.Persistence;

namespace Sscs.Api.Extensions
{
    internal static class HostExtensions
    {
        public static IHost Migrate(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            
            var services = scope.ServiceProvider;

            try
            {
                using var context = services
                    .GetRequiredService<IDesignTimeDbContextFactory<SscsDbContext>>()
                    .CreateDbContext(Array.Empty<string>());
                
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error migrating the DB.");
            }
            
            return host;
        }
    }
}