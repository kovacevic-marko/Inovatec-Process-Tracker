using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPTXamarinForms.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IPTXamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigPage : ContentPage
    {
        

        public ConfigPage()
        {

           InitializeComponent();
 
        }

        private void BtnSave_OnClicked(object sender, EventArgs e)
        {
            Helpers.Settings.UrlSettings = editField.Text;
        }

        private void BtnGet_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Current Value:", Helpers.Settings.UrlSettings, "OK");
        }

        private void BtnDone_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TestPage());
           
        }
    }
}