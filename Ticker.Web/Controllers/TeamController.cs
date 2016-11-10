using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class TeamController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Team
        public IEnumerable<dynamic> GetTeams()
        {
            var ret = new List<dynamic>();
            dynamic expando = new ExpandoObject();
            expando = new { ID = -1, Name = "NONE" };
            ret.Add(expando);

            return ret.Concat(db.Teams.Select(t => new
            {
                t.ID,
                Name = t.CityName + " " + t.Abbreviation //t.NickName
            }));
        }
        public class TeamObject
        {
            public int ID { get; set; }
            public Nullable<int> SportID { get; set; }
            public Nullable<int> LeagueID { get; set; }
            public Nullable<int> SourceTeamID { get; set; }
            public string Abbreviation { get; set; }
            public string DisplayAbbreviation { get; set; }
            public string City { get; set; }
            public string Name { get; set; }
            public string DisplayName { get; set; }
            public string CityAndState { get; set; }
            public string Stadium { get; set; }
            public Nullable<int> Capacity { get; set; }
            public string Surface { get; set; }
            public Nullable<bool> Dome { get; set; }
            public Nullable<short> Ranking { get; set; }
            public Nullable<short> Wins { get; set; }
            public Nullable<short> Losses { get; set; }
            public Nullable<short> Ties { get; set; }
            public string Logo { get; set; }
            public string Country { get; set; }
            public string CountryCode { get; set; }
            //public bool Deleted { get; set; }
            public string League { get; set; }
            public string Sport { get; set; }
            public string Color { get; set; }
            public string Image { get; set; }
            public string ImagePath { get; set; }
        }
        // GET api/Team/0/MLB
        public IEnumerable<dynamic> Get(string teams, string league)
        {
            string vcode = teams.Split('^')[0];
            string hcode = teams.Split('^')[1];
            var ret = new List<dynamic>();
            dynamic expando = new ExpandoObject();
            try
            {
                expando = new { ID = -1, Name = "NONE" };
                ret.Add(expando);
                //********* Following lines were comment out due to SDM integration  -- Start *****************//
                //int count = db.Sports.Where(s => s.ShortDisplay == league).Count();
                //if (count != 1)
                //{
                //    return ret;
                //}
                //expando = new { ID = 117, Name = "MIN" };
                //ret.Add(expando);
                //expando = new { ID = 1231, Name = "ATL" };
                //ret.Add(expando);
                    
                //int sport = db.Sports.Where(s => s.ShortDisplay == league).SingleOrDefault().ID;
                //return ret.Concat(db.Teams.Where(t1 => t1.SportID == sport && (t1.Abbreviation == vcode || t1.Abbreviation == hcode)).Select(t => new
                //{
                //    t.ID,
                //    Name = t.Abbreviation//t.CityName + " " + t.Abbreviation //t.NickName
                //}));
                //********* Following lines were comment out due to SDM integration  -- Start *****************//
                TeamObject Vt = GetTeamsData(vcode,league);
                if (Vt != null)
                {
                    expando = new { ID = Vt.ID, Name = Vt.Abbreviation };
                    ret.Add(expando);
                }

                TeamObject Ht = GetTeamsData(hcode, league);
                if (Ht != null)
                {
                    expando = new { ID = Ht.ID, Name = Ht.Abbreviation };
                    ret.Add(expando);
                }



                return ret;
            }
            catch
            {
                return ret;
            }
        }

        public  TeamObject GetTeamsData(string teamcode, string leaguecode)
        {
            TeamObject Team = new TeamObject();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["SDMUrl"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //HttpResponseMessage response = await client.GetAsync("api/TeamsAPI/SelectTeams?Abbr=" + Abbr + "&Code="+Code);
                HttpResponseMessage response = client.GetAsync("/api/Team?id=" + teamcode + "&value=" + leaguecode+"&withoutEnvelope=True").Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;// ReadAsAsync<LeagueObject>();
                    if (result.ToLower() != "null")
                        Team = JsonConvert.DeserializeObject<TeamObject>(result);
                    return Team;

                }
                else
                {
                    return null;
                }
            }
           
        } 





        // GET api/Team/5
        public Team GetTeam(int id)
        {
            Team team = db.Teams.Single(t => t.ID == id);

            if (team == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return team;
        }
        public IEnumerable<dynamic> GetTeam(int id, int sportID, string sort)//, string Sort)
        {
            IEnumerable<dynamic> team = null;

            var ret = new List<dynamic>();
            dynamic expando = new ExpandoObject();
            expando = new { ID = -1, Name = "NONE" };
            ret.Add(expando);
            //************ Following lines were commented for SDM Integration  -- Start  *********************//
            //switch (sort)
            //{
            //    case "FromTeam":

            //        //if (id == 0)
            //        //    return ret;

            //        team = db.Teams.Where(t => t.Sport.Teams.Where(st => st.ID == id).Count() > 0).OrderBy(tob => tob.NickName).OrderBy(ob => ob.NickName).Select(t => new
            //       {
            //           t.ID,
            //           Name = t.CityName + " " + t.Abbreviation
            //       });
            //        break;
            //    case "CityName":
            //        team = db.Teams.Where(t => t.SportID == sportID).OrderBy(tob => tob.NickName).OrderBy(ob => ob.CityName).Select(t => new
            //        {
            //            t.ID,
            //            Name = t.CityName + " " + t.Abbreviation // t.CityName
            //        });
            //        break;
            //    case "Abbreviation":
            //        team = db.Teams.Where(t => t.SportID == sportID).OrderBy(tob => tob.NickName).OrderBy(ob => ob.Abbreviation).Select(t => new
            //        {
            //            t.ID,
            //            Name =  t.Abbreviation
            //        });
            //        break;
            //    case "NickName":
            //        team = db.Teams.Where(t => t.SportID == sportID).OrderBy(tob => tob.NickName).OrderBy(ob => ob.NickName).Select(t => new
            //        {
            //            t.ID,
            //            Name = t.NickName
            //        });
            //        break;
            //}
            
            ////IEnumerable<Team> team = db.Teams.Where(t => t.SportID == sportID).OrderBy(tob => tob.NickName).AsEnumerable();
            //if (team == null)
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            //}
            //return ret.Concat(team);
            //************ Following lines were commented for SDM Integration  -- End  *********************//

            return ret;
        }

        //overload for restricting to visitor, home team (game centric notes)
        public IEnumerable<dynamic> GetTeam(int id, string sort, int HomeID, int VisitorID)//, string Sort)
        {
            IEnumerable<dynamic> team = null;

            var ret = new List<dynamic>();
            dynamic expando = new ExpandoObject();
            expando = new { ID = 0, Name = "NONE" };
            ret.Add(expando);
            //************ Following lines were commented for SDM Integration  -- Start  *********************//
            //switch (sort)
            //{
            //    case "FromTeam":

            //        //if (id == 0)
            //        //    return ret;

            //        team = db.Teams.Where(t => t.ID == HomeID || t.ID == VisitorID).OrderBy(tob => tob.NickName).OrderBy(ob => ob.NickName).Select(t => new
            //        {
            //            t.ID,
            //            Name = t.CityName + " " + t.Abbreviation
            //        });
            //        break;
            //    case "CityName":
            //        team = db.Teams.Where(t => t.ID == HomeID || t.ID == VisitorID).OrderBy(tob => tob.NickName).OrderBy(ob => ob.CityName).Select(t => new
            //        {
            //            t.ID,
            //            Name = t.CityName + " " + t.Abbreviation // t.CityName
            //        });
            //        break;
            //    case "Abbreviation":
            //        team = db.Teams.Where(t => t.ID == HomeID || t.ID == VisitorID).OrderBy(tob => tob.NickName).OrderBy(ob => ob.Abbreviation).Select(t => new
            //        {
            //            t.ID,
            //            Name = t.CityName + " " + t.Abbreviation
            //        });
            //        break;
            //    case "NickName":
            //        team = db.Teams.Where(t => t.ID == HomeID || t.ID == VisitorID).OrderBy(tob => tob.NickName).OrderBy(ob => ob.NickName).Select(t => new
            //        {
            //            t.ID,
            //            Name = t.NickName
            //        });
            //        break;
            //}
            
            ////IEnumerable<Team> team = db.Teams.Where(t => t.SportID == sportID).OrderBy(tob => tob.NickName).AsEnumerable();
            //if (team == null)
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            //}

            //return ret.Concat(team);
            //************ Following lines were commented for SDM Integration  -- End  *********************//
            return ret;
        }

        // PUT api/Team/5
        public HttpResponseMessage PutTeam(int id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != team.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Teams.Attach(team);
            db.ObjectStateManager.ChangeObjectState(team, EntityState.Modified);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Team
        public HttpResponseMessage PostTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.AddObject(team);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, team);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = team.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Team/5
        public HttpResponseMessage DeleteTeam(int id)
        {
            Team team = db.Teams.Single(t => t.ID == id);
            if (team == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Teams.DeleteObject(team);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, team);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}