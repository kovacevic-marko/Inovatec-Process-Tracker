using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Json;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace Inovatec_process_tracker.Activities
{
    [Activity(Label = "Services_Service1Activity")]
    public class Services_Service1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Services_Service1);

            FindViewById<Button>(Resource.Id.Services_Service1_btnRefresh).Click += async (o, e) =>
            {
                string url = "https://kovacevicm.com/api/";

                JsonValue jsonValue = await FetchServiceStatus(url);
                ParseAndDisplayServiceStatus(jsonValue);
            };
            FindViewById<Button>(Resource.Id.Services_Service1_btnServiceInfo).Click += (o, e) =>
            {
                StartActivity(typeof(Activities.Services_Service1_ServiceInfo));
            };

        }




        // Uzima informaciju da li je servis aktivan ili nije preko Web API
        private async Task<JsonValue> FetchServiceStatus(string url)
        {
            //Pravi HTTP zahtev koristeci zadati url
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Salje zahtev serveru i ceka odgovor
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    // Ovde pravi JSON dokument:
                    JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                    // Vraca JSON dokument:
                    return jsonDoc;
                }
            }
        }

        //Ovde parsuje prethodno dobijenu informaciju i ispisuje da li je servis aktivan ili nije
        private void ParseAndDisplayServiceStatus(JsonValue json)
        {
            TextView txtServiceStatus = FindViewById<TextView>(Resource.Id.Services_Service1_txtStatus);

            JsonValue serviceStatusResults = json;

            txtServiceStatus.Text = serviceStatusResults["status"];
        }
    }
}