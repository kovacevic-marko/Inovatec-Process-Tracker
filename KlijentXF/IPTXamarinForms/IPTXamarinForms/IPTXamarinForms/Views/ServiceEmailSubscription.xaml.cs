using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Collections.Specialized;
using System.Net.Http;
using Newtonsoft.Json;

namespace IPTXamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceEmailSubscription : ContentPage
    {
        Entry entryEmail;
        Switch switcherIsOn;

        public ServiceEmailSubscription()
        {
            InitializeComponent();

            entryEmail = new Entry
            {
                HorizontalOptions = LayoutOptions.Center,
                Placeholder = "Add your email here"
            };

            switcherIsOn = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
                
            };

            StackLayout rootKontejner = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };

            Button btnSacuvaj = new Button
            {
                Text = "Sacuvaj"
            };

            btnSacuvaj.Clicked += (sender, args) => { sacuvajIzmeneAsync("1.1.1.1.1", entryEmail.ToString(), switcherIsOn.IsEnabled); };

            rootKontejner.Children.Add(entryEmail);
            rootKontejner.Children.Add(switcherIsOn);
            rootKontejner.Children.Add(btnSacuvaj);

            this.Content = rootKontejner;
        }


        public async Task sacuvajIzmeneAsync(string url, string email, bool ison)
        {
            var client = new HttpClient();
            var content = new StringContent(
                JsonConvert.SerializeObject(new { Email = email, IsOn = ison }));
            var result = await client.PostAsync(url, content).ConfigureAwait(false);
            if (result.IsSuccessStatusCode)
            {
                var tokenJson = await result.Content.ReadAsStringAsync();
            }
        }
    }
}