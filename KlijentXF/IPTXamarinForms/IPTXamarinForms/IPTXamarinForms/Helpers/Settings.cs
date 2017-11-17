// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace IPTXamarinForms.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        // Application first run
        private const string SettingsKey = "IsFirstRun";
        private static readonly bool SettingsDefault = true;

        public static bool IsFirstRun
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        // WebAPI URL
        private const string WebApiUrlKey = "WebApiUrl";
        private static readonly string WebAPIUrlDefault = string.Empty;

        public static string WebApiUrl
        {
            get
            {
                return AppSettings.GetValueOrDefault(WebApiUrlKey, WebAPIUrlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(WebApiUrlKey, value);
            }
        }

        // Email
        private const string EmailKey = "Email";
        private static readonly string EmailDefault = string.Empty;

        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault(EmailKey, EmailDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(EmailKey, value);
            }
        }

        private const string IsSubscribedKey = "IsSubscribed";
        private static readonly bool IsSubscribedDefault = false;

        public static bool IsSubscribed
        {
            get
            {
                return AppSettings.GetValueOrDefault(IsSubscribedKey, IsSubscribedDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(IsSubscribedKey, value);
            }
        }
    }
}
