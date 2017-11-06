using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IPTXamarinForms
{
    public static class JsonFunctions
    {
        public static async Task<string> GetJson(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Salje zahtev serveru i ceka odgovor
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    //JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));
                    string json = new StreamReader(stream).ReadToEnd();
                    // Vraca JSON string:
                    return json;
                }
            }
        }

    }
}
