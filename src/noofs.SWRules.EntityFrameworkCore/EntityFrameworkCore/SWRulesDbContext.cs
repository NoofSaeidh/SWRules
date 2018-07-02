using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace noofs.SWRules.EntityFrameworkCore
{
    public class SWRulesDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public SWRulesDbContext(DbContextOptions<SWRulesDbContext> options) 
            : base(options)
        {

        }
    }
}
