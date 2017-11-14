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

		 
        // General settings
		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = "yes";

	    public static string GeneralSettings
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

        //LastUsedUrl

        private const string LastUsedUrl = "settings_key_url";
	    private static readonly string LastUsedDefault = string.Empty;

	    public static string UrlSettings
	    {
	        get
	        {
	            return AppSettings.GetValueOrDefault(LastUsedUrl, LastUsedDefault);
	        }
	        set
	        {
	            AppSettings.AddOrUpdateValue(LastUsedUrl, value);
	        }
	    }





    }
    }
