using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.MarketingModule.Core
{
    public class ModuleConstants
    {
        public static class Security
        {
            public static class Permissions
            {
                public const string Read = "marketing:read";
                public const string Create = "marketing:create";
                public const string Update = "marketing:update";
                public const string Access = "marketing:access";
                public const string Delete = "marketing:delete";

                public static string[] AllPermissions = new[] { Read, Create, Update, Access, Delete };
            }
        }

        public static class Settings
        {
            public static class General
            {
                public static SettingDescriptor CombinePolicy = new SettingDescriptor
                {
                    Name = "Marketing.Promotion.CombinePolicy",
                    ValueType = SettingValueType.ShortText,
                    GroupName = "Marketing|General",
                    DefaultValue = "BestReward",
                    AllowedValues = new[] { "BestReward", "CombineStackable" }
                };

                public static SettingDescriptor ExportImportDescription = new SettingDescriptor
                {
                    Name = "Marketing.ExportImport.Description",
                    ValueType = SettingValueType.ShortText,
                    GroupName = "Marketing|General",
                    DefaultValue = "Export/Import promotions and dynamic contents (places, contents, publications)"
                };

                public static IEnumerable<SettingDescriptor> AllSettings
                {
                    get
                    {
                        yield return CombinePolicy;
                        yield return ExportImportDescription;
                    }
                }
            }
        }

        public static class MarketingConstants
        {
            public const string ContentPlacesRootFolderId = "ContentPlace";
            public const string CotentItemRootFolderId = "ContentItem";
        }
    }
}
