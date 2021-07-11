using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sscs.Application.Common;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Persistence
{
    public static class PersistenceDependencies
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SscsDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Main")));
            
            services.AddScoped<IDesignTimeDbContextFactory<SscsDbContext>, SscsDbContextFactory>();

            services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<SscsDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ISscsDbContext>(provider => provider.GetService<SscsDbContext>());
            
            return services;
        }
    }
}