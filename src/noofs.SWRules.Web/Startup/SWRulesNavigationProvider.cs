﻿using Abp.Application.Navigation;
using Abp.Localization;

namespace noofs.SWRules.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class SWRulesNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "Home/About",
                        icon: "fa fa-info"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Powers,
                        L("Powers"),
                        url: "Powers",
                        icon: "fa fa-hand"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SWRulesConsts.LocalizationSourceName);
        }
    }
}
