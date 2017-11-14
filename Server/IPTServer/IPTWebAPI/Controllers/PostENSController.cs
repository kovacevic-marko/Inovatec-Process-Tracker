using IPTDataAccess;
using System;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;

public class PostENSController : ApiController
{
    [System.Web.Http.HttpPost]
    public HttpResponseMessage Post()
    {
        int status = 500; // internal server error
        HttpContent requestContent = Request.Content;
        string jsonContent = requestContent.ReadAsStringAsync().Result;
        if (jsonContent != null)
        {
            try
            {
                using (IPTDBEntities entities = new IPTDBEntities())
                {
                    if (entities != null)
                    {
                        JObject json = JObject.Parse(jsonContent);
                        if (json != null)
                        {
                            try
                            {
                                string Email = (string)json["Email"];
                                bool IsOn = (bool)json["IsOn"];
                                int ClientServiceID = (int)json["Service"];
                                bool SubscribeToService = (bool)json["SubscribeToService"];




                                // BUG BUG BUG
                                // Vraceni ID je uvek 1 a procedura pokrenuta u SQL Management Studiu
                                // vraca pravi EmailID
                                
                                ObjectParameter output = new ObjectParameter("EmailID",typeof(int));
                                entities.UpdateInsertEmail(Email, IsOn,output);
                                entities.SaveChanges();

                                if (SubscribeToService)
                                {
                                    status = entities.InsertSubscribedService(ClientServiceID, (int)output.Value);
                                    entities.SaveChanges();
                                }
                                else
                                {
                                    status = entities.DeleteSubscribedService(ClientServiceID, (int)output.Value);
                                    entities.SaveChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                                status = 400; // bad request
                            }
                        }
                        else
                            status = 400; // bad request
                    }
                    else
                        status = 500; // internal server error
                }
            }
            catch (Exception ex)
            {
                status = 500; // internal server error

            }
        }
        else
            status = 400; // bad request
        
        return Request.CreateResponse((HttpStatusCode)status);
        //var message = Request.CreateErrorResponse(HttpStatusCode.Created, email);
        //message.Headers.Location = new Uri(Request.RequestUri + email.id.ToString());
        //return message;
        //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
    }
}

