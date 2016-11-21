using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ticker.Controllers
{
    public class SportsController : ApiController
    {
        // GET: api/Sports
        public IEnumerable<string> Get()
        {
            return new string[] { "NFL", "Soccer" };
        }

        // GET: api/Sports/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sports
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sports/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sports/5
        public void Delete(int id)
        {
        }
    }
}
