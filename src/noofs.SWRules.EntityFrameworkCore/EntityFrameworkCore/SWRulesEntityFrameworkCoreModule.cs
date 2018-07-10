using Abp.Dependency;
using Abp.EntityFrameworkCore;
using Abp.EntityHistory;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace noofs.SWRules.EntityFrameworkCore
{
    [DependsOn(
        typeof(SWRulesCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class SWRulesEntityFrameworkCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.EntityHistory.IsEnabled = true;
            Configuration.EntityHistory.IsEnabledForAnonymousUsers = true;

            Configuration.UnitOfWork.IsTransactional = false;
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SWRulesEntityFrameworkCoreModule).GetAssembly());
        }
    }
}