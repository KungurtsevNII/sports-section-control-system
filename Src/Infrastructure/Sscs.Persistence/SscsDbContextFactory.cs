using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Sscs.Persistence
{
    public class SscsDbContextFactory : IDesignTimeDbContextFactory<SscsDbContext>
    {
        public SscsDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", true)
                .Build();

            var connectionString = configuration.GetConnectionString("Main");
            
            var optionsBuilder = new DbContextOptionsBuilder<SscsDbContext>().UseNpgsql(connectionString);

            return new SscsDbContext(optionsBuilder.Options);
        }
    }
}