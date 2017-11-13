using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;
namespace IPTWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        //public string Get(string json)
        //{
            // Primer podataka koji se salju sa klijenta
            //var jsonStructure = new {
            //    Email = "ndukic25@gmail.com",
            //    IsOn = true,
            //    Services = new []
            //    {
            //        new { ClientServiceID = 1, IsOn = true },
            //        new { ClientServiceID = 2, IsOn = false },
            //        new { ClientServiceID = 3, IsOn = true },
            //    }
            //};
            //var jsonSerialized = JsonConvert.SerializeObject(jsonStructure);

            
        //    JObject jsonResponse = JObject.Parse(jsonSerialized);

        //    Email
        //    string r = $"{{Email : {jsonResponse["Email"]}\nIsOn : {jsonResponse["IsOn"]}\nServices : {{\n";
        //    foreach (var item in jsonResponse["Services"])
        //    {
        //        r += $"{{ClientServiceID : {item["ClientServiceID"]}, IsOn : {item["IsOn"]}}}";
        //    }
        //    r += "}}}}";

        //    return r;
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
