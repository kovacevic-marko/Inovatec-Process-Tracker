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
            InitializeComponent();
            init();
        }

        public async void init()
        {
            string url = "http://172.24.2.136:5000/api/clients";
            string jsonString = await JsonFunctions.GetJson(url);
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
                btn.Clicked += (sender, args) => { Navigation.PushAsync(new Client(client.ClientID, client.ClientName)); };

                stackLayoutVertical.Children.Add(btn);
            }
            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new ScrollView { Content = stackLayoutVertical };
        }

    }
}
