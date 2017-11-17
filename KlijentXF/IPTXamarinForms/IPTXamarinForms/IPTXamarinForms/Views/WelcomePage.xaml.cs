using System.Collections.Generic;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IPTXamarinForms.Helpers;

namespace IPTXamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            var url = string.Empty;

            if (Settings.IsFirstRun)
            {
                Navigation.PushAsync(new SettingsPage());
                Settings.IsFirstRun = false;
            }

            //while (string.IsNullOrEmpty(url))
            //{
            //    if (Application.Current.Properties.ContainsKey("WebAPIUrl"))
            //    {
            //        url = Application.Current.Properties["WebAPIUrl"] as string;
            //    }

            //    if (string.IsNullOrEmpty(url))
            //    {
            //        var newConfigPage = new ConfigPage();
            //        await Navigation.PushAsync(newConfigPage);

            //        var poppedPage = await Navigation.PopAsync();
            //    }
            //}
        }

        private void btnSettings_Pressed(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private void btnClients_Pressed(object sender, System.EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new ClientsPage());
            }
            catch (System.Exception ex)
            {
                //"Proveriti adresu WebAPI-a";
            }
        }
    }
}