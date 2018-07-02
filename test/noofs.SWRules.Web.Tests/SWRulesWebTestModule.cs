using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using noofs.SWRules.Web.Startup;
namespace noofs.SWRules.Web.Tests
{
    [DependsOn(
        typeof(SWRulesWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class SWRulesWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SWRulesWebTestModule).GetAssembly());
        }
    }
}