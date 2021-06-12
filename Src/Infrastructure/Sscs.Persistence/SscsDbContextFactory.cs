using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sscs.Persistence
{
    public class SscsDbContextFactory : IDesignTimeDbContextFactory<SscsDbContext>
    {
        public SscsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SscsDbContext>();
            // TODO надо как-то натравить на appsettings, либо создать отельно запускаемое приложение для миграция.
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sscs;Username=postgres;Password=password");

            return new SscsDbContext(optionsBuilder.Options);
        }
    }
}