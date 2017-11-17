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
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                var response = (HttpWebResponse)await request.GetResponseAsync();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

    }
}
