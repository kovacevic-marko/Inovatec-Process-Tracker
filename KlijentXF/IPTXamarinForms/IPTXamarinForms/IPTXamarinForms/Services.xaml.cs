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
    public partial class Services : ContentPage
    {
        public Services(string nazivKlijenta)
        {
            ServicesAsync(nazivKlijenta);
        }

        public async void ServicesAsync(string nazivKlijenta)
        {
            int brojServisa;

            switch (nazivKlijenta)
            {
                case "Client 1":
                    brojServisa = 3;
                    break;
                case "Client 2":
                    brojServisa = 5;
                    break;
                case "Client 3":
                    brojServisa = 7;
                    break;
                case "Client 4":
                    brojServisa = 10;
                    break;
                case "Client 5":
                    brojServisa = 25;
                    break;
                default:
                    brojServisa = 0;
                    break;
            }

            InitializeComponent();


            var stackLayoutVertical = new StackLayout()
            {
                Orientation = StackOrientation.Vertical, 
            };
            
            


            string url = "https://kovacevicm.com/api/";
            JsonValue StartingJsonValue = await FetchServiceStatus(url);
            string status = StartingJsonValue["status"];

            for (int i = 1; i <= brojServisa; i++)
            {
                var stackLayoutHorizontal = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.Center,
                    Spacing = 60
                };

                stackLayoutHorizontal.Children.Add(new Button
                {
                    Text = "Service " + i,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                });


                if (status.Equals("ok"))
                {
                    stackLayoutHorizontal.Children.Add(new Label
                    {
                        Text = "Active",
                        BackgroundColor = Color.FromHex("#00ff00"),  //zelena                      
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        HorizontalOptions = LayoutOptions.Center
                    });
                }
                else
                {
                    stackLayoutHorizontal.Children.Add(new Label
                    {
                        Text = "Not Active",
                        BackgroundColor = Color.FromHex("#ff0000"),  //crvena
                        MinimumWidthRequest = 50,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        HorizontalOptions = LayoutOptions.Center
                    });
                }

                stackLayoutVertical.Children.Add(stackLayoutHorizontal);
            }


            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new ScrollView { Content = stackLayoutVertical };
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