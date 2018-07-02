using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace noofs.SWRules
{
    [DependsOn(
        typeof(SWRulesCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SWRulesApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SWRulesApplicationModule).GetAssembly());
        }
    }
}