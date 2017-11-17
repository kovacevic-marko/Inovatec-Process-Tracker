using IPTXamarinForms.Models;
using IPTXamarinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IPTXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Client : ContentPage
    {
        public int ClientID { get; private set; }
        public string ClientName { get; set; }
        int newClientId;

        public Client(int ClientID, string ClientName)
        {
            int ClientIDprosledjivac = ClientID;
            newClientId = ClientID;

            //this.ClientID = ClientID;
            this.ClientName = ClientName;
            InitializeComponent();

            var stackLayoutVertical = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };
            List<ChoseItemModel> lista = new List<ChoseItemModel>();
            lista.Add(new ChoseItemModel("Services", ItemType.services));
            lista.Add(new ChoseItemModel("Applications", ItemType.applications));
            //Button btnServices = new Button
            //{
            //    Text = "Services",
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //    HorizontalOptions = LayoutOptions.Center,
            //};
            //btnServices.Clicked += (sender, args) => { Navigation.PushAsync(new Services(ClientIDprosledjivac)); };

            //Button btnApplications = new Button
            //{
            //    Text = "Applications",
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //    HorizontalOptions = LayoutOptions.Center,
            //};
            //btnApplications.Clicked += (sender, args) => { Navigation.PushAsync(new Applications(nazivKlijentaProsledjivac)); };

            //stackLayoutVertical.Children.Add(btnServices);
            //stackLayoutVertical.Children.Add(btnApplications);
            listClient.ItemsSource = lista;
            stackLayoutVertical.Children.Add(listClient);
            
            this.Content = new ScrollView { Content = stackLayoutVertical };
        }

        private void listClient_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ChoseItemModel model = new ChoseItemModel();
            model=(ChoseItemModel)((ListView)sender).SelectedItem;
            if (model.Type==ItemType.services)
            {
                Navigation.PushAsync(new Services(newClientId));
            }
            else if (model.Type==ItemType.applications)
            {
                Navigation.PushAsync(new ApplicationPage());
            }
            listClient.SelectedItem = false;
        }
    }
}