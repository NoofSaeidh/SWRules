using System;
using System.Threading.Tasks;
using Abp.TestBase;
using noofs.SWRules.EntityFrameworkCore;
using noofs.SWRules.Tests.TestDatas;

namespace noofs.SWRules.Tests
{
    public class SWRulesTestBase : AbpIntegratedTestBase<SWRulesTestModule>
    {
        public SWRulesTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<SWRulesDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<SWRulesDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<SWRulesDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SWRulesDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<SWRulesDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<SWRulesDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<SWRulesDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SWRulesDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
