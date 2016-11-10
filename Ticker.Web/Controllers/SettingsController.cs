using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticker.Data;

namespace LeagueSet.Controllers
{
    public class SettingsController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();
        // GET api/settings
        public IEnumerable<dynamic> Get()
        {
            //return new string[] { "value1", "value2" };
            var slist = db.Settings.Select(s => new
            {
                id = s.Id,
                SettingsDesc = s.Value

            });
            return slist;
        }

        // GET api/settings/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/settings
        public void Post([FromBody]string value)
        {
        }

        // PUT api/settings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/settings/5
        public void Delete(int id)
        {
        }
    }
}
