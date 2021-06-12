using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Persistence
{
    public static class PersistenceDependencies
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SscsDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Main")));
            
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SscsDbContext>()
                .AddDefaultTokenProviders();
            
            return services;
        }
    }
}