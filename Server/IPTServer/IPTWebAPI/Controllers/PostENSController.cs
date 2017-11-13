using IPTDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPTCommon;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public class PostENSController : ApiController
{
            [System.Web.Http.HttpPost]
            public void Post([FromBody] EmailNotificationSubscription email)
            {
                try
                {
                    using (IPTDBEntities entities = new IPTDBEntities())
                    {
                //entities.InsertEmail(email);
                entities.UpdateInsertEmail(email.Email, email.IsOn);

                        entities.SaveChanges();

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

