using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using noofs.SWRules.Rules;

namespace noofs.SWRules.EntityFrameworkCore
{
    public class SWRulesDbContext : AbpDbContext
    {
        public SWRulesDbContext(DbContextOptions<SWRulesDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Power> Powers { get; set; }
    }
}
