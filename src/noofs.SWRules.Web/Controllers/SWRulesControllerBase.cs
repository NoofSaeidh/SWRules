using Abp.AspNetCore.Mvc.Controllers;

namespace noofs.SWRules.Web.Controllers
{
    public abstract class SWRulesControllerBase: AbpController
    {
        protected SWRulesControllerBase()
        {
            LocalizationSourceName = SWRulesConsts.LocalizationSourceName;
        }
    }
}