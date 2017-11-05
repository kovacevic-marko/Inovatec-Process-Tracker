using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IPTXamarinForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            int brojKorisnika = 5;
            InitializeComponent();



            var stackLayoutVertical = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };

            for (int i=1; i<=brojKorisnika; i++)
            {
                Button btn = new Button
                {
                    Text = "Client " + i,
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

    }
}
