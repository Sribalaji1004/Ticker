using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class GetLeaguesSettingsController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();
        
        // GET api/getleaguessettings
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/getleaguessettings/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        // GET api/getleaguessettings/49/ATP
        public IHttpActionResult Get(int id, string lcode)
        {
            Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
            //var Settings = db.LeaguesSettings.Where(s => s.ClientID == id && s.LeagueCode == LeagueCode).Select(so => so.LeagueCode).FirstOrDefault();
            var Settings = db.LeaguesSettings.Where(s => s.ClientID == id && s.LeagueCode == lcode).Select(s => new
            {


                ClientID = s.ClientID,
                LeagueCode = s.LeagueCode,
                Settings = db.Settings.Where(ls => ls.Id == s.SettingsID).Select(ls => ls.Value).FirstOrDefault(),
                Value = db.SettingsOptions.Where(ls => ls.SettingsOptionValueID == s.OptionsID && ls.SettingsID == s.SettingsID).Select(ls => ls.Value).FirstOrDefault(),


            });
            result["data"] = Settings;
            result["Messages"] = "";
            result["Status"] = "SUCCESS";
            return Json(result);
            //var ret = new List<dynamic>();
            //return ret;
        }
          

        // POST api/getleaguessettings
        public void Post([FromBody]string value)
        {
        }

        // PUT api/getleaguessettings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/getleaguessettings/5
        public void Delete(int id)
        {
        }
    }
}
