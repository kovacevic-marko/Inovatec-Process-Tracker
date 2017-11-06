using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IPTXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Service : ContentPage
    {
        Label lblStatusServisa;
        Button btnRefresh;

        public Service(string nazivServisa, int statusServisa)
        {
            //InitializeComponent();

            var stackLayoutVertical = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };


            Label lblNazivServisa = new Label
            {
                Text = nazivServisa,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            lblStatusServisa = new Label
            {
                Text = "Unknown",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                MinimumWidthRequest = 50
            };

            if (statusServisa.Equals("ok"))
            {
                lblStatusServisa.Text = "Active";
                lblStatusServisa.BackgroundColor = Color.FromHex("#00ff00");  //zelena    
            }
            else
            {
                lblStatusServisa.Text = "Not Active";
                lblStatusServisa.BackgroundColor = Color.FromHex("#ff0000");  //crvena
            }


            btnRefresh = new Button
            {
                Text = "Refresh",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            btnRefresh.Clicked += (sender, args) => { refreshServiceStatus(); };

            Button btnServiceInfo = new Button
            {
                Text = "Service info",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            DatePicker datePicker = new DatePicker
            {
                Format = "D",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = false
            };

            datePicker.DateSelected += (sender, args) => { Navigation.PushAsync(new ServiceInfo(nazivServisa)); };

            btnServiceInfo.Clicked += (sender, args) => { datePicker.Focus(); };


            stackLayoutVertical.Children.Add(lblNazivServisa);
            stackLayoutVertical.Children.Add(lblStatusServisa);
            stackLayoutVertical.Children.Add(btnRefresh);
            stackLayoutVertical.Children.Add(btnServiceInfo);
            stackLayoutVertical.Children.Add(datePicker);

            this.Content = new ScrollView { Content = stackLayoutVertical };
        }


        public async void refreshServiceStatus()
        {
            lblStatusServisa.Text = "Loading...";
            lblStatusServisa.BackgroundColor = Color.FromHex("#000000");  //zelena   

            string url = "https://kovacevicm.com/api/";
            JsonValue jsonValue = await FetchServiceStatus(url);

            string status = jsonValue["status"];

            if (status.Equals("ok"))
            {
                lblStatusServisa.Text = "Active";
                lblStatusServisa.BackgroundColor = Color.FromHex("#00ff00");  //zelena    
            }
            else
            {
                lblStatusServisa.Text = "Not Active";
                lblStatusServisa.BackgroundColor = Color.FromHex("#ff0000");  //crvena
            }
        }

        // Uzima informaciju da li je servis aktivan ili nije preko Web API
        private async Task<JsonValue> FetchServiceStatus(string url)
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
                    // Ovde pravi JSON dokument:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));


                    // Vraca JSON dokument:
                    return jsonDoc;
                }
            }
        }
    }
}