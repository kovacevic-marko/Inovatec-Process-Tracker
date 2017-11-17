using IPTXamarinForms.Helpers;
using IPTXamarinForms.Models;
using IPTXamarinForms.Views;
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
    public partial class Service : ContentPage
    {
        //Label lblStatusServisa;
        Button btnRefresh;
        StackLayout stackLayoutVerticalROOT;
        StackLayout tabelaZaLog;
        Label lblNazivServisa;
        ScrollView scrollTabelaLog;

        int idServisaProsledjivacZaMetoduRefresh;

        public Service(int idServisa, string nazivServisa, int statusServisa)
        {
            idServisaProsledjivacZaMetoduRefresh = idServisa;
            string statusServisaProsledjivac = statusServisa.ToString();
            char statusServisaPrvaCifra = statusServisaProsledjivac[0];

            InitializeComponent();

            stackLayoutVerticalROOT = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };


            lblNazivServisa = new Label
            {
                Text = nazivServisa,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            //lblStatusServisa = new Label
            //{
            //    Text = "Unknown",
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //    HorizontalOptions = LayoutOptions.Center,
            //    MinimumWidthRequest = 50
            //};

            if (statusServisaPrvaCifra.Equals('2'))
            {
                //lblStatusServisa.Text = "Active";
                lblNazivServisa.BackgroundColor = Color.FromHex("#00ff00");  //zelena    
            }
            else
            {
                //lblStatusServisa.Text = "Not Active";
                lblNazivServisa.BackgroundColor = Color.FromHex("#ff0000");  //crvena
            }


            btnRefresh = new Button
            {
                Text = "Refresh",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            btnRefresh.Clicked += (sender, args) => { refreshServiceStatus(); };

            Label lblLogInfo = new Label
            {
                Text = "Log Informations",
                FontSize = 25,
                Margin = new Thickness(20),
                HorizontalOptions = LayoutOptions.Center
            };




            //TABELA
            Label lblOfflineFromNASLOV = new Label
            {
                Text = "Offline from",
                WidthRequest = 120,
                FontAttributes = FontAttributes.Bold
            };
            Label lblOfflineToNASLOV = new Label
            {
                Text = "Offline to",
                WidthRequest = 120,
                FontAttributes = FontAttributes.Bold
            };
            Label lblGreskaOpisNASLOV = new Label
            {
                Text = "Opis",
                WidthRequest = 280,
                FontAttributes = FontAttributes.Bold
            };
            Label lblGreskaErrorNASLOV = new Label
            {
                Text = "Error",
                WidthRequest = 280,
                FontAttributes = FontAttributes.Bold
            };



            StackLayout naziviKolonaKontejner = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
            };
            naziviKolonaKontejner.Children.Add(lblOfflineFromNASLOV);
            naziviKolonaKontejner.Children.Add(lblOfflineToNASLOV);
            naziviKolonaKontejner.Children.Add(lblGreskaOpisNASLOV);
            naziviKolonaKontejner.Children.Add(lblGreskaErrorNASLOV);



            tabelaZaLog = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
            };
            // tabelaZaLog.Children.Add(naziviKolonaKontejner);


            //Pozivanje metode koja ce popuniti i postaviti tabelu u kontejner
            setLogTable(idServisa);


            StackLayout kontejnerZaNazivServisaIrefresh = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center
            };
            kontejnerZaNazivServisaIrefresh.Children.Add(lblNazivServisa);
            kontejnerZaNazivServisaIrefresh.Children.Add(btnRefresh);

            Button btnRedirektEmailSubscription = new Button
            {
                Text = "Email Subscription"
            };
            btnRedirektEmailSubscription.Clicked += (sender, args) => { Navigation.PushAsync(new ServiceEmailSubscription()); };

            stackLayoutVerticalROOT.Children.Add(btnRedirektEmailSubscription);
            stackLayoutVerticalROOT.Children.Add(kontejnerZaNazivServisaIrefresh);
            stackLayoutVerticalROOT.Children.Add(lblLogInfo);
            stackLayoutVerticalROOT.Children.Add(naziviKolonaKontejner);


            scrollTabelaLog = new ScrollView { Content = tabelaZaLog };

            //Ubacivanje prazne tabele koja ce biti kasnije uklonjena i zamenjena novom ukoliko postoje logovi z aservis, ukoliko ne postoje ostace prazna
            stackLayoutVerticalROOT.Children.Add(scrollTabelaLog);

            this.Content = stackLayoutVerticalROOT;
        }


        public async void refreshServiceStatus()
        {
            //lblStatusServisa.Text = "Loading...";
            lblNazivServisa.BackgroundColor = Color.FromHex("#000000");  //zelena   

            string url = Settings.WebApiUrl;
            url = string.Format("{0}{1}servicestatus?id={2}", url, url.EndsWith("/") ? string.Empty : "/", idServisaProsledjivacZaMetoduRefresh);
            JsonValue jsonValue = await FetchServiceStatus(url);

            string status = jsonValue.ToString();
            char statusPrvaCifra = status[0];

            if (statusPrvaCifra.Equals('2'))
            {
                //lblStatusServisa.Text = "Active";
                lblNazivServisa.BackgroundColor = Color.FromHex("#00ff00");  //zelena    
            }
            else
            {
                //lblStatusServisa.Text = "Not Active";
                lblNazivServisa.BackgroundColor = Color.FromHex("#ff0000");  //crvena
            }
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






        public async void setLogTable(int serviceID)
        {
            string url = Settings.WebApiUrl;
            url = string.Format("{0}{1}servicelog?id={2}", url, url.EndsWith("/") ? string.Empty : "/", serviceID);
            string jsonString = await JsonFunctions.GetJson(url);
            List<ServiceLogModel> logList = JsonConvert.DeserializeObject<List<ServiceLogModel>>(jsonString);


            //Rucno pravljenje tabele posto i Xamarin forms nepostoji TableView sa vise kolona
            foreach (var log in logList)
            {
                var tabelaHorizontal = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                };


                Label lblOfflineFrom = new Label
                {
                    Text = log.OfflineFrom.ToString(),
                    WidthRequest = 120
                };
                Label lblOfflineTo = new Label
                {
                    Text = log.OfflineTo.ToString(),
                    WidthRequest = 120
                };
                Label lblGreskaOpis = new Label
                {
                    Text = log.StatusDescription,
                    WidthRequest = 280
                };
                Label lblGreskaError = new Label
                {
                    Text = log.Error,
                    WidthRequest = 280
                };


                tabelaHorizontal.Children.Add(lblOfflineFrom);
                tabelaHorizontal.Children.Add(lblOfflineTo);
                tabelaHorizontal.Children.Add(lblGreskaOpis);
                tabelaHorizontal.Children.Add(lblGreskaError);



                tabelaZaLog.Children.Add(tabelaHorizontal);

                //Prvo mora da ukloni praznu tabelu koja je na pocetku napravljena zbog toga sto neki servis ima logove a neki nema
                stackLayoutVerticalROOT.Children.Remove(scrollTabelaLog);
                stackLayoutVerticalROOT.Children.Add(scrollTabelaLog);
            }

        }

    }
}