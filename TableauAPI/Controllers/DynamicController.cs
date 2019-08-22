using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TableauAPI.Controllers
{
    public class DynamicController : ApiController
    {
        // GET: api/Dynamic
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Dynamic/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dynamic
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Dynamic/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Dynamic/5
        public void Delete(int id)
        {
        }
    }
}
