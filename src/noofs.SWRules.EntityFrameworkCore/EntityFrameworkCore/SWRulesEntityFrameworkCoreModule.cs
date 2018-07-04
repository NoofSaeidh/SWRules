using Abp.EntityFrameworkCore;
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
            Configuration.UnitOfWork.IsTransactional = false;
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SWRulesEntityFrameworkCoreModule).GetAssembly());
        }
    }
}