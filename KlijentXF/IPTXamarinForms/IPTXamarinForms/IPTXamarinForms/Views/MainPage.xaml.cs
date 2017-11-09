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
            string url = "http://172.24.2.51:5000/api/clients";
            string jsonString = await JsonFunctions.GetJson(url);
            List<ClientModel> clients = JsonConvert.DeserializeObject<List<ClientModel>>(jsonString);

            var stackLayoutVertical = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };

            List<string> clientNames = new List<string>();

            foreach (var client in clients)
            {

                //btn.Clicked += (sender, args) => { Navigation.PushAsync(new Client(client.ClientID, client.ClientName)); };

                //stackLayoutVertical.Children.Add(btn);
            }

            listClient.ItemsSource = clients;
            // listClient.ItemTapped += (sender, args) => { Navigation.PushAsync(new Client(listClient.SelectedItem., client.ClientName)); };
            stackLayoutVertical.Children.Add(listClient);

            // Build the page.
            this.Content = new ScrollView { Content = stackLayoutVertical };
        }

        private void listClient_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //DisplayAlert("Item Selected", ((ListView)sender).SelectedItem.GetType().ToString(), "Ok");
            ClientModel m = new ClientModel();
            m = (ClientModel)((ListView)sender).SelectedItem;
            //DisplayAlert("Item Selected", m.ClientName + " id= " + m.ClientID, "Ok");
            Navigation.PushAsync(new Client(m.ClientID,m.ClientName));
        }

      
    }
}
