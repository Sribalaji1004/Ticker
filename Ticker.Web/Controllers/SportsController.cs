using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class SportsController : ApiController
    {

        private FoxTickerEntities db = new FoxTickerEntities();
        // GET: api/Sports
        public IEnumerable<dynamic> Get()
        {
            var ret = new List<dynamic>();
            dynamic expando = new ExpandoObject();
            expando = new { ID = 0, LongDisplay = "NONE" };
            ret.Add(expando);

            return ret.Concat(db.Sports.OrderBy(sob => sob.LongDisplay).Select(s => new { s.ID, s.LongDisplay }));
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
