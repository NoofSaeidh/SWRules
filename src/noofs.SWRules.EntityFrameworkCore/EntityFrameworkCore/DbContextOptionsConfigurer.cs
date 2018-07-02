using Microsoft.EntityFrameworkCore;

namespace noofs.SWRules.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<SWRulesDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for SWRulesDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
