using noofs.SWRules.Configuration;
using noofs.SWRules.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace noofs.SWRules.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class SWRulesDbContextFactory : IDesignTimeDbContextFactory<SWRulesDbContext>
    {
        public SWRulesDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SWRulesDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(SWRulesConsts.ConnectionStringName)
            );

            return new SWRulesDbContext(builder.Options);
        }
    }
}