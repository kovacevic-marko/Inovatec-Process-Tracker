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
using Xamarin.Forms.Xaml;

namespace IPTXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Services : ContentPage
    {
        public Services(int ClientID)
        {
            ServicesAsync(ClientID);
        }

        public async void ServicesAsync(int ClientID)
        {
            //InitializeComponent();


            string url = "http://172.24.2.136:5000/api/clientservice?ClientID=" + ClientID;
            string jsonString = await JsonFunctions.GetJson(url);
            List<ServiceModel> services = JsonConvert.DeserializeObject<List<ServiceModel>>(jsonString);

            var stackLayoutVertical = new StackLayout()
            {
                Orientation = StackOrientation.Vertical, 
            };
            
            foreach (var service in services)
            {
                Button btn = new Button
                {
                    Text = service.ClientServiceID + " " + service.ServiceName + " " + service.ServiceStatus,
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center,
                };
                btn.Clicked += (sender, args) => { Navigation.PushAsync(new Service(service.ServiceName, service.ServiceStatus)); };

                stackLayoutVertical.Children.Add(btn);
            }

            //for (int i = 1; i <= brojServisa; i++)
            //{
            //    var stackLayoutHorizontal = new StackLayout()
            //    {
            //        Orientation = StackOrientation.Horizontal,
            //        HorizontalOptions = LayoutOptions.Center,
            //        Spacing = 60
            //    };

            //    Button btnService = new Button
            //    {
            //        Text = "Service " + i,
            //        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //        HorizontalOptions = LayoutOptions.Center
            //    };
            //    btnService.Clicked += (sender, args) => { Navigation.PushAsync(new Service(btnService.Text, status)); };
            //    stackLayoutHorizontal.Children.Add(btnService);

            //    Label lblServiceStatus = new Label();

            //    if (status.Equals("ok"))
            //    {
            //        lblServiceStatus.Text = "Active";
            //        lblServiceStatus.BackgroundColor = Color.FromHex("#00ff00");  //zelena                      
            //        lblServiceStatus.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            //        lblServiceStatus.HorizontalOptions = LayoutOptions.Center;
            //        lblServiceStatus.MinimumWidthRequest = 50;
            //    }
            //    else
            //    {
            //        lblServiceStatus.Text = "Not Active";
            //        lblServiceStatus.BackgroundColor = Color.FromHex("#00ff00");  //zelena                      
            //        lblServiceStatus.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            //        lblServiceStatus.HorizontalOptions = LayoutOptions.Center;
            //        lblServiceStatus.MinimumWidthRequest = 50;
            //    }

            //    stackLayoutHorizontal.Children.Add(lblServiceStatus);

            //    stackLayoutVertical.Children.Add(stackLayoutHorizontal);
            //}


            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new ScrollView { Content = stackLayoutVertical };
        }
    }
}