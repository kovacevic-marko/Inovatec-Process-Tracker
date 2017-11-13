using IPTDataAccess;
using System;
using System.Web.Http;
using Newtonsoft.Json.Linq;

public class PostENSController : ApiController
{
    [System.Web.Http.HttpPost]
    public void Post([FromBody] string receivedString)
    {
        try
        {
            using (IPTDBEntities entities = new IPTDBEntities())
            {
                JObject json = JObject.Parse(receivedString);
                string Email = (string)json["Email"];
                bool IsOn = (bool)json["IsOn"];

                int EmailID = entities.UpdateInsertEmail(Email, IsOn);
                entities.SaveChanges();

                int status = 500;
                foreach (var service in json["Services"])
                {
                    if ((bool)service["IsOn"])
                    {
                        status = entities.InsertSubscribedService((int)service["ClientServiceID"], EmailID);
                        entities.SaveChanges();
                    }
                    else
                    {
                        status = entities.DeleteSubscribedService((int)service["ClientServiceID"], EmailID);
                        entities.SaveChanges();
                    }
                }

                //var message = Request.CreateErrorResponse(HttpStatusCode.Created, email);
                //message.Headers.Location = new Uri(Request.RequestUri + email.id.ToString());
                //return message;
            }
        }
        catch (Exception ex)
        {
            //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        }
    }
}

