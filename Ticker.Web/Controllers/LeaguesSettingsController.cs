using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using LeagueSet.Models;
using System.Web.Mvc;

//using System.Web;
//using System.Linq;
using System.Data.SqlClient;
using Ticker.Data;
//using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueSet.Controllers
{
    public class LeaguesSettingsController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();
      
        // GET api/leaguessettings
        public IEnumerable<dynamic> Get()
        {
            //return new string[] { "value1", "value2" };
            var slist = db.LeaguesSettings.Select(s => new
            {

                Id = s.Id,
                ClientID = s.ClientID,
                Description = db.Clients.Where(c => c.ID == s.ClientID).Select(c => c.Description).FirstOrDefault(),
                LeagueCode = s.LeagueCode,
                SettingsID = s.SettingsID,
                SettingsDesc = db.Settings.Where(ls => ls.Id == s.SettingsID).Select(ls => ls.Value).FirstOrDefault(),
                OptionsID=s.OptionsID,
                OptionsValue = db.SettingsOptions.Where(ls => ls.SettingsOptionValueID == s.OptionsID && ls.SettingsID == s.SettingsID).Select(ls => ls.Value).FirstOrDefault(),
                

            });
            return slist;
        }

        // GET api/leaguessettings/5
        public IEnumerable<dynamic> Get(int id)
        {
            var slist = db.LeaguesSettings.Where(ls=>ls.ClientID==id).Select(s => new
            {

                Id = s.Id,
                ClientID = s.ClientID,
                Description = db.Clients.Where(c => c.ID == s.ClientID).Select(c => c.Description).FirstOrDefault(),
                LeagueCode = s.LeagueCode,
                SettingsID = s.SettingsID,
                SettingsDesc = db.Settings.Where(ls => ls.Id == s.SettingsID).Select(ls => ls.Value).FirstOrDefault(),
                OptionsID = s.OptionsID,
                OptionsValue = db.SettingsOptions.Where(ls => ls.SettingsOptionValueID == s.OptionsID && ls.SettingsID==s.SettingsID).Select(ls => ls.Value).FirstOrDefault(),


            });
            return slist;
        }

        // POST api/leaguessettings
        
        public dynamic Post([FromBody]LeaguesSetting value)
        {
           // db.LeaguesSettings.Add(value);
            if (value.LeagueCode != null)
            {
                string ClientID = Request.Headers.GetValues("ClientID").FirstOrDefault().Replace('{', ' ').Replace('}', ' ').Trim();
                value.ClientID = Convert.ToInt32(ClientID);

                bool exists = db.LeaguesSettings.Any(l => l.ClientID == value.ClientID && l.LeagueCode == value.LeagueCode && l.SettingsID == value.SettingsID && l.OptionsID == value.OptionsID);
                if (!exists)
                {
                    db.LeaguesSettings.AddObject(value);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return "FAILURE";
                    }

                    var retvalue = new LeaguesSetting();
                    retvalue.Id = value.Id;
                    retvalue.ClientID = value.ClientID;
                    retvalue.LeagueCode = value.LeagueCode;
                    retvalue.SettingsID = value.SettingsID;
                    retvalue.OptionsID = value.OptionsID;
                    return retvalue;
                }
                else
                    return "Exists";
            }
            else
                return "Error";
        }

        // PUT api/leaguessettings/5
        public dynamic Put(int id,[FromBody]LeaguesSetting value)
        {
            if (value == null || value.Id != id)
            {
                return "FAILURE";
            }

            //var uls = db.LeaguesSettings.Find(id);
            //if (uls == null)
            //{
            //    return "FAILURE";
            //}
            //uls.ClientID = value.ClientID;
            //uls.LeagueCode = value.LeagueCode;
            //uls.SettingsID  = value.SettingsID;
            //uls.OptionsID = value.OptionsID;
            
            //db.LeaguesSettings.Add(uls);
             bool exists = db.LeaguesSettings.Any(l => l.ClientID == value.ClientID && l.LeagueCode == value.LeagueCode && l.SettingsID == value.SettingsID && l.OptionsID == value.OptionsID && l.Id !=id);
             if (!exists)
             {

                 db.LeaguesSettings.Attach(value);
                 db.ObjectStateManager.ChangeObjectState(value, EntityState.Modified);


                 try
                 {
                     db.SaveChanges();
                 }
                 catch (Exception e)
                 {
                     return "FAILURE";
                 }
                 return value;
             }
             else
             {
                 return "Exists";
             }


        }

        // DELETE api/leaguessettings/5
       // [HttpDelete]
        public void Delete(int id)
        {
            LeaguesSetting Ls = db.LeaguesSettings.Single(l => l.Id == id);
            db.LeaguesSettings.DeleteObject(Ls);
            db.SaveChanges();
        }
    }
}
