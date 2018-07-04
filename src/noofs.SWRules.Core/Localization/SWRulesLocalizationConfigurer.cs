using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Json;
using Abp.Reflection.Extensions;

namespace noofs.SWRules.Localization
{
    public static class SWRulesLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("ru", "Русский", "famfamfam-flags russia", isDefault: true));

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SWRulesConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SWRulesLocalizationConfigurer).GetAssembly(),
                        "noofs.SWRules.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}