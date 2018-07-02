using Abp.Modules;
using Abp.Reflection.Extensions;
using noofs.SWRules.Localization;

namespace noofs.SWRules
{
    public class SWRulesCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            SWRulesLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SWRulesCoreModule).GetAssembly());
        }
    }
}