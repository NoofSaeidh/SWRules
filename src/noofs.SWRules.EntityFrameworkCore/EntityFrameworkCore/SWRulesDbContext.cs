using Abp.EntityFrameworkCore;
using Abp.EntityHistory;
using Microsoft.EntityFrameworkCore;
using noofs.SWRules.Powers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace noofs.SWRules.EntityFrameworkCore
{
    public class SWRulesDbContext : AbpDbContext
    {
        public SWRulesDbContext(DbContextOptions<SWRulesDbContext> options) 
            : base(options)
        {
        }

        public IEntityHistoryHelper EntityHistoryHelper { get; set; }

        #region Tables
        public DbSet<Power> Powers { get; set; }
        public DbSet<EntityChangeSet> EntityChangeSets { get; set; }
        public DbSet<EntityChange> EntityChanges { get; set; }
        public DbSet<EntityPropertyChange> EntityPropertyChanges { get; set; }
        #endregion

        public override int SaveChanges()
        {
            if (EntityHistoryHelper == null)
            {
                return base.SaveChanges();
            }

            var changeSet = EntityHistoryHelper.CreateEntityChangeSet(ChangeTracker.Entries().ToList());

            var result = base.SaveChanges();

            EntityHistoryHelper.Save(changeSet);

            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (EntityHistoryHelper == null)
            {
                return await base.SaveChangesAsync();
            }

            var changeSet = EntityHistoryHelper.CreateEntityChangeSet(ChangeTracker.Entries().ToList());

            var result = await base.SaveChangesAsync(cancellationToken);

            await EntityHistoryHelper.SaveAsync(changeSet);

            return result;
        }
    }
}
