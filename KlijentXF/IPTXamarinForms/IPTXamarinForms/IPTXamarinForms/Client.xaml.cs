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
        public Client(String nazivKlijenta)
        {
            string nazivKlijentaProsledjivac = nazivKlijenta;
            InitializeComponent();

            var stackLayoutVertical = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };

            Button btnServices = new Button
            {
                Text = "Services",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };
            btnServices.Clicked += (sender, args) => { Navigation.PushAsync(new Services(nazivKlijentaProsledjivac)); };

            Button btnApplications = new Button
            {
                Text = "Applications",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };
            btnApplications.Clicked += (sender, args) => { Navigation.PushAsync(new Applications(nazivKlijentaProsledjivac)); };

            stackLayoutVertical.Children.Add(btnServices);
            stackLayoutVertical.Children.Add(btnApplications);

            this.Content = new ScrollView { Content = stackLayoutVertical };
        }
    }
}