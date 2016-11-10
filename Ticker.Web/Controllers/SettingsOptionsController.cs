using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticker.Data;

namespace LeagueSet.Controllers
{
    public class SettingsOptionsController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();
        // GET api/settingsoptions
        public IEnumerable<dynamic> Get()
        {
            //return new string[] { "value1", "value2" };
            var slist = db.SettingsOptions.Select(s => new
            {
                id = s.SettingsOptionValueID,
                OptionsValue = s.Value

            });
            return slist;
        }

        public IEnumerable<dynamic> Get(int id)
        {
            //return new string[] { "value1", "value2" };
            //if (id != 0 )
            //{
            
                var slist = db.SettingsOptions.Where(so => so.SettingsID == id).Select(s => new
                {
                    id = s.SettingsOptionValueID,
                    OptionsValue = s.Value

                });
            
                return slist;
            //}
            //else
            //{
                //var list = new List<KeyValuePair<string, int>>();
                //list.Add(new KeyValuePair<string, int>("Cat", 1));
              //  return "";
            //}
        }

        // GET api/settingsoptions/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/settingsoptions
        public void Post([FromBody]string value)
        {
        }

        // PUT api/settingsoptions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/settingsoptions/5
        public void Delete(int id)
        {
        }
    }
}
