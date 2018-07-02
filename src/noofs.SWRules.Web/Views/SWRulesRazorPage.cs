using Abp.AspNetCore.Mvc.Views;

namespace noofs.SWRules.Web.Views
{
    public abstract class SWRulesRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected SWRulesRazorPage()
        {
            LocalizationSourceName = SWRulesConsts.LocalizationSourceName;
        }
    }
}
