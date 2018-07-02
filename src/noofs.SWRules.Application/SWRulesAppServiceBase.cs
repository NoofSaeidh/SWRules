using Abp.Application.Services;

namespace noofs.SWRules
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SWRulesAppServiceBase : ApplicationService
    {
        protected SWRulesAppServiceBase()
        {
            LocalizationSourceName = SWRulesConsts.LocalizationSourceName;
        }
    }
}