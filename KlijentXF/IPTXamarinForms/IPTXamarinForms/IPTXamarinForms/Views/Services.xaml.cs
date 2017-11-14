using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IPTXamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Services : ContentPage, INotifyPropertyChanged
    {

        private ListView lwServices = new ListView();
        private List<ServiceModel> listServices = new List<ServiceModel>();
        private int ClientID;

        private bool busy = false;

        public new bool IsBusy
        {
            get { return busy; }
            set
            {
                if (busy == value)
                    return;

                busy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        public Services(int ClientID)
        {
            InitializeComponent();

            this.ClientID = ClientID;
            LoadServices(ClientID);
        }

        private async void LoadServices(int ClientID)
        {
            IsBusy = true;
            activityIndicatorProveraServisa.IsRunning = IsBusy;
            activityIndicatorProveraServisa.IsVisible = IsBusy;
            lblStatus.Text = "Getting list of client's services...";

            // Povlacenje liste servisa zadatog klijenta
            string url = "http://172.24.2.51:5000/api/clientservice?ClientID=" + ClientID;
            string jsonString = await JsonFunctions.GetJson(url);
            listServices = JsonConvert.DeserializeObject<List<ServiceModel>>(jsonString);

            RefreshServices();

            lblStatus.Text = "Statusi servisa ucitani";
            IsBusy = false;
            activityIndicatorProveraServisa.IsRunning = IsBusy;
            activityIndicatorProveraServisa.IsVisible = IsBusy;
        }

        private void RefreshServices()
        {
            IsBusy = true;
            activityIndicatorProveraServisa.IsRunning = IsBusy;
            activityIndicatorProveraServisa.IsVisible = IsBusy;


            lblStatus.Text = "Getting status for each service...";
            foreach (var service in listServices)
            {
                StackLayout stackLayoutServisiImeIison = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                };

                // Ovde umesto nove labele treba dodati novi ListView (ili slicno) item.

                var btnServis = new Button { };
 
                
                var btn = new Button
 
                {
                    Text = service.ServiceName,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                btnServis.Clicked += (sender, args) => { Navigation.PushAsync(new Service(service.ClientServiceID, service.ServiceName, service.ServiceStatus)); };

                Switch switcherIsOn = new Switch
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand

                };
                switcherIsOn.Toggled += (sender, args) => { postreqAsync(service.ClientServiceID, switcherIsOn.IsToggled); };

                    lytStackLayout.Children.Add(btnServis);
                lytStackLayout.Children.Add(switcherIsOn);

                // Povlacenje statusa pojedinacnog servisa
                Task.Run(async () => {
                    string serviceUrl = "http://172.24.2.51:5000/api/ServiceStatus?ID=" + service.ClientServiceID;
                    string jsonServiceStatus = await JsonFunctions.GetJson(serviceUrl);

                    Device.BeginInvokeOnMainThread(() => {
                        // Promena teksta i boje
                        switch (jsonServiceStatus[0])
                        {
                            case '2':
                                btnServis.BackgroundColor = Color.LightGreen;
                                break;
                            default:
                                btnServis.BackgroundColor = Color.Red;
                                break;
                        }
                        btnServis.Text = $"{service.ServiceName} - Service status: {jsonServiceStatus}";
                    });
                });
            }

            lblStatus.Text = "Servisi";
            IsBusy = false;
            activityIndicatorProveraServisa.IsRunning = IsBusy;
            activityIndicatorProveraServisa.IsVisible = IsBusy;
        }

        //public async void ServicesAsync(int ClientID)
        //{


        //    string url = "http://172.24.2.51:5000/api/clientservice?ClientID=" + ClientID;
        //    string jsonString = await JsonFunctions.GetJson(url);
        //    List<ServiceModel> services = JsonConvert.DeserializeObject<List<ServiceModel>>(jsonString);

        //    var stackLayoutVertical = new StackLayout()
        //    {
        //        Orientation = StackOrientation.Vertical,
        //    };

        //    List<Task> tasks = new List<Task>();

        //    foreach (var service in services)
        //    {
        //        // tasks.Add(Task.Factory.StartNew( async () => 
        //        //{
        //        //url = "http://172.24.2.51:5000/api/servicestatus?id=" + service.ClientServiceID;
        //        //jsonString = await JsonFunctions.GetJson(url);
        //        //ServiceModel serviceModel = JsonConvert.DeserializeObject<ServiceModel>(jsonString);
        //        Button btn = new Button
        //        {
        //            Text = service.ClientServiceID + " " + service.ServiceName + " " + service.ServiceStatus,
        //            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
        //            HorizontalOptions = LayoutOptions.Center,
        //        };
        //        btn.Clicked += (sender, args) => { Navigation.PushAsync(new Service(service.ClientServiceID, service.ServiceName, service.ServiceStatus)); };

        //        stackLayoutVertical.Children.Add(btn);
        //        //} 
        //        // ));
        //    }

        //    //Task.WaitAll(tasks.ToArray());
        //    //for (int i = 1; i <= brojServisa; i++)
        //    //{
        //    //    var stackLayoutHorizontal = new StackLayout()
        //    //    {
        //    //        Orientation = StackOrientation.Horizontal,
        //    //        HorizontalOptions = LayoutOptions.Center,
        //    //        Spacing = 60
        //    //    };

        //    //    Button btnService = new Button
        //    //    {
        //    //        Text = "Service " + i,
        //    //        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
        //    //        HorizontalOptions = LayoutOptions.Center
        //    //    };
        //    //    btnService.Clicked += (sender, args) => { Navigation.PushAsync(new Service(btnService.Text, status)); };
        //    //    stackLayoutHorizontal.Children.Add(btnService);

        //    //    Label lblServiceStatus = new Label();

        //    //    if (status.Equals("ok"))
        //    //    {
        //    //        lblServiceStatus.Text = "Active";
        //    //        lblServiceStatus.BackgroundColor = Color.FromHex("#00ff00");  //zelena                      
        //    //        lblServiceStatus.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
        //    //        lblServiceStatus.HorizontalOptions = LayoutOptions.Center;
        //    //        lblServiceStatus.MinimumWidthRequest = 50;
        //    //    }
        //    //    else
        //    //    {
        //    //        lblServiceStatus.Text = "Not Active";
        //    //        lblServiceStatus.BackgroundColor = Color.FromHex("#00ff00");  //zelena                      
        //    //        lblServiceStatus.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
        //    //        lblServiceStatus.HorizontalOptions = LayoutOptions.Center;
        //    //        lblServiceStatus.MinimumWidthRequest = 50;
        //    //    }

        //    //    stackLayoutHorizontal.Children.Add(lblServiceStatus);

        //    //    stackLayoutVertical.Children.Add(stackLayoutHorizontal);
        //    //}


        //    // Accomodate iPhone status bar.
        //    //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

        //    // Build the page.
        //    this.Content = new ScrollView { Content = stackLayoutVertical };
        //}

        private void btnRefresh_Clicked(object sender, EventArgs e)
        {
            RefreshServices();
        }

        //Slanje post requesta za prijavljivanje na pracenje pojedinacnog servisa
        public async void postreqAsync(int clientServiceID, bool isOn)
        {
            string clientServiceIDString = clientServiceID.ToString();
            string ukljucenString = isOn.ToString();
            HttpClient client = new HttpClient();

            var values = new Dictionary<string, string>
            {
               { "ClientServiceID", clientServiceIDString },
               { "IsOn", ukljucenString }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("OVDE IDE URI", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}