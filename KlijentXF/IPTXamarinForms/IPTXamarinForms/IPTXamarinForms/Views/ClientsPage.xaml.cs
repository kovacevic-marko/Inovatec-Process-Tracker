using IPTXamarinForms.Helpers;
using Newtonsoft.Json;
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
    public partial class ClientsPage : ContentPage
    {
        public ClientsPage()
        {
            InitializeComponent();
            LoadClients();
        }

        private async void LoadClients()
        {
            string url = Settings.WebApiUrl;
            url = string.Format("{0}{1}clients", url, url.EndsWith("/") ? string.Empty : "/");
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

            listClients.ItemsSource = clients;
            // listClients.ItemTapped += (sender, args) => { Navigation.PushAsync(new Client(listClient.SelectedItem., client.ClientName)); };
            stackLayoutVertical.Children.Add(listClients);

            // Build the page.
            this.Content = new ScrollView { Content = stackLayoutVertical };
        }

        private void listClients_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //DisplayAlert("Item Selected", ((ListView)sender).SelectedItem.GetType().ToString(), "Ok");
            ClientModel m = new ClientModel();
            m = (ClientModel)((ListView)sender).SelectedItem;
            //DisplayAlert("Item Selected", m.ClientName + " id= " + m.ClientID, "Ok");
            Navigation.PushAsync(new Client(m.ClientID, m.ClientName));
            listClients.SelectedItem = false;
        }
    }
}