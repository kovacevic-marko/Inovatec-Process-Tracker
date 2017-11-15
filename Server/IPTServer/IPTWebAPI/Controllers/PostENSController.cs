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
    public HttpResponseMessage Post(string action)
    {
        int status = 400; // bad request
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
                                ObjectParameter output = new ObjectParameter("EmailID", typeof(int));
                                if (action == "ToggleEmail" || action == "ToggleService")
                                {
                                    string Email = (string)json["Email"];
                                    bool IsOn = (bool)json["IsOn"];
                                    
                                    entities.UpdateInsertEmail(Email, IsOn, output);
                                    entities.SaveChanges();
                                    status = 200; // success
                                }
                                if (action == "ToggleService")
                                {
                                    status = 500; // internal server error
                                    int ClientServiceID = (int)json["Service"];
                                    bool SubscribeToService = (bool)json["SubscribeToService"];

                                    if (SubscribeToService)
                                    {
                                        entities.InsertSubscribedService(ClientServiceID, (int)output.Value);
                                        entities.SaveChanges();
                                        status = 200; // success
                                    }
                                    else
                                    {
                                        entities.DeleteSubscribedService(ClientServiceID, (int)output.Value);
                                        entities.SaveChanges();
                                        status = 200; // success
                                    }
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
    }
}

