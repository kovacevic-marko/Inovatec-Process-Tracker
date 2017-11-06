using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IPTXamarinForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            ////InitializeComponent();
            init();
        }

        public async void init()
        {
            string url = "http://172.24.2.136:5000/api/clients";
            string jsonString = await GetJson(url);
            List<ClientModel> clients = JsonConvert.DeserializeObject<List<ClientModel>>(jsonString);
            
            var stackLayoutVertical = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };

            foreach (var client in clients)
            {
                Button btn = new Button
                {
                    Text = client.ClientID + " " + client.ClientName,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center,
                };
                btn.Clicked += (sender, args) => { Navigation.PushAsync(new Client(btn.Text)); };

                stackLayoutVertical.Children.Add(btn);
            }
            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new ScrollView { Content = stackLayoutVertical };
        }
        // Uzima informaciju da li je servis aktivan ili nije preko Web API
        private async Task<string> GetJson(string url)
        {
            //Pravi HTTP zahtev koristeci zadati url
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Salje zahtev serveru i ceka odgovor
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    //JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    string json = new StreamReader(stream).ReadToEnd();
                    // Vraca JSON string:
                    return json;
                }
            }
        }

    }
}
