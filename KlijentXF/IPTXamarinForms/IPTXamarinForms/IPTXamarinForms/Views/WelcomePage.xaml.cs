using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPTXamarinForms.Helpers;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IPTXamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            init();
        }

        public async void init()
        {
            // string url = "http://172.24.2.51:5000/api/clients";

            var url = string.Empty;

            while (string.IsNullOrEmpty(url))
            {
                if (Application.Current.Properties.ContainsKey("WebAPIUrl"))
                {
                    url = Application.Current.Properties["WebAPIUrl"] as string;
                }

                if (string.IsNullOrEmpty(url))
                {
                    var newConfigPage = new ConfigPage();
                    await Navigation.PushAsync(newConfigPage);
                    
                    var poppedPage = await Navigation.PopAsync();
                }
            }

            url = string.Format("{0}{1}api/clients", url, url.EndsWith("/") ? string.Empty : "/");
            string jsonString = await JsonFunctions.GetJson(url);
            List<ClientModel> clients = JsonConvert.DeserializeObject<List<ClientModel>>(jsonString);


            //string url = Settings.UrlSettings + "/api/clients";
            //string jsonString = await JsonFunctions.GetJson(url);
            //List<ClientModel> clients = JsonConvert.DeserializeObject<List<ClientModel>>(jsonString);

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
            Navigation.PushAsync(new Client(m.ClientID, m.ClientName));
            listClient.SelectedItem = false;
        }

    }
}