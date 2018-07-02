using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using noofs.SWRules.Configuration;
using noofs.SWRules.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace noofs.SWRules.Web.Startup
{
    [DependsOn(
        typeof(SWRulesApplicationModule), 
        typeof(SWRulesEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class SWRulesWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public SWRulesWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(SWRulesConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<SWRulesNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(SWRulesApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SWRulesWebModule).GetAssembly());
        }
    }
}