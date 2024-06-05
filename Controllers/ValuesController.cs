using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
namespace WebApiCrud.Controllers
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
            // In a real application, you would retrieve data from a database or service
            var values = new Dictionary<int, string>
{
{ 1, "value1" },
{ 2, "value2" },
{ 3, "value3" }
};

            if (values.TryGetValue(id, out string value))
            {
                return value;
            }

            return "Value not found";
        }

        // Other actions like Post, Put, Delete can be added here as needed
    }
}