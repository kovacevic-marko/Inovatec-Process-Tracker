using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IPTCommon
{
    public static class WebCommunication
    {
        public static int GetStatusCode(string URL)
        {
            int statusCode = -1;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(URL);
                var response = (HttpWebResponse)request.GetResponse();
                statusCode = (int)response.StatusCode;
            }
            catch (WebException)
            {
                statusCode = -1;
            }
            catch (Exception)
            {
                statusCode = -2;
            }

            return statusCode;
        }
    }
}
