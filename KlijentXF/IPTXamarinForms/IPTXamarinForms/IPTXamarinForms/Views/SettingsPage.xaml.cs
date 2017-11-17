using IPTXamarinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IPTXamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            entryURL.Text = Settings.WebApiUrl;
            entryEmail.Text = Settings.Email;
            switchEmail.IsToggled = Settings.IsSubscribed;
        }

        private void btnSaveURL_Pressed(object sender, EventArgs e)
        {
            Settings.WebApiUrl = entryURL.Text;
            entryURL.BackgroundColor = Color.FromHex("#2ecc71");
        }

        private void btnSaveEmail_Pressed(object sender, EventArgs e)
        {
            Settings.Email = entryEmail.Text;
            Settings.IsSubscribed = switchEmail.IsToggled;
            entryEmail.BackgroundColor = Color.FromHex("#2ecc71");
        }

        private void btnDone_Pressed(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}