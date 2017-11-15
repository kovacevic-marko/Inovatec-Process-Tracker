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
        Entry entryUrl;

        public ConfigPage()
        {
            InitializeComponent();

            entryUrl = new Entry
            {
                HorizontalOptions = LayoutOptions.Center,
                Placeholder = Application.Current.Properties.ContainsKey("WebAPIUrl") ?
                    Application.Current.Properties["WebAPIUrl"].ToString() :
                    "http://"
            };

            StackLayout stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };

            Button btnSave = new Button
            {
                Text = "Save",
                HorizontalOptions = LayoutOptions.Center
            };

            Button btnDone = new Button
            {
                Text = "Done",
                HorizontalOptions = LayoutOptions.Center
            };

            btnSave.Clicked += (sender, args) => { UpdateUrlAsync(entryUrl.Text); };
            btnDone.Clicked += (sender, args) => {  Navigation.PushAsync(new WelcomePage());};

            stackLayout.Children.Add(entryUrl);
            stackLayout.Children.Add(btnSave);
            stackLayout.Children.Add(btnDone);

            this.Content = stackLayout;
        }

        public async void UpdateUrlAsync(string url)
        {
            if (Application.Current.Properties.ContainsKey("WebAPIUrl"))
            {
                Application.Current.Properties["WebAPIUrl"] = url;
            }
            else
            {
                Application.Current.Properties.Add("WebAPIUrl", url);
            }

            await Application.Current.SavePropertiesAsync();
        }
    }
}