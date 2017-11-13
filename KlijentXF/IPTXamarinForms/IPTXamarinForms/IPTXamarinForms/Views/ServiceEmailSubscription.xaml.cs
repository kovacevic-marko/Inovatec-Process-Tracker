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

            
            btnSacuvaj.Clicked += (sender, args) => { postreqAsync(entryEmail.Text, switcherIsOn.IsToggled); };

            rootKontejner.Children.Add(entryEmail);
            rootKontejner.Children.Add(switcherIsOn);
            rootKontejner.Children.Add(btnSacuvaj);

            this.Content = new ScrollView { Content = rootKontejner };
        }


        public async void postreqAsync(string email, bool ison)
        {
            string ukljucen = ison.ToString();
            HttpClient client = new HttpClient();

            var values = new Dictionary<string, string>
            {
               { "email", email },
               { "ison", ukljucen }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://172.24.2.51:5000/api/postens", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }


    }
}