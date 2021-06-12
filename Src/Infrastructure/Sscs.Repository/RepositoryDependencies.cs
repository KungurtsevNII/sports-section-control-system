using Microsoft.Extensions.DependencyInjection;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Repository
{
    public static class RepositoryDependencies
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            return services;
        }
    }
}