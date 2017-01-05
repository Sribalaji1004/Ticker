using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class GameHiveEditorController : Controller
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        ////
        //// GET: /Game/

        //public ActionResult Index()
        //{
        //    return View(db.Games.ToList());
        //}

        ////
        //// GET: /Game/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    spTICK_Games_GetByEntryID_Result Game = db.spTICK_Games_GetByEntryID(0, id, 2, false, false).First();
        //    if (Game == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(Game);
        //}

        ////
        //// GET: /Game/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        public partial class TeamObject
        {
            public int ID { get; set; }
            public Nullable<int> LeagueID { get; set; }
           
            public string Abbreviation { get; set; }
            public string DisplayName { get; set; }
           
        }
        
        
        // GET: /Game/Edit/5

        public ActionResult Edit(string id, string hiveprefix, int clientID)
        {
            FoxTickerEntities db = new FoxTickerEntities();
            spTICK_Games_GetByEntryID_Result Game;
            //if (id != 0)
            //{
            if (id == null)
            {
                return View(new Game());
            }

            ViewData["HiveID"] = id;
            ViewData["HivePrefix"] = hiveprefix;
            ViewData["ClientID"] = clientID;

            //null team
            Team newTeam = new Team();
            newTeam.ID = -1;
            
            newTeam.NickName = "NONE";

            //Task<List<TeamObject>> t = Topic();
            //List<TeamObject> lt = t.Result;

          //  List<Team> teams = new List<Team>();
           
            //List<TeamObject> to=new List<TeamObject>();
            //to.AddTopic(hiveprefix));

            //foreach (Note n in db.Notes.Where(n => n.GameID == id))
            //{
            //    int iSport = db.Teams.Where(t => t.ID == n.TeamID).FirstOrDefault().SportID;
            //    if (teams.Where(t => t.SportID == iSport).Count() == 0)
            //        teams.AddRange(db.Teams.Where(tw => tw.SportID == iSport).ToList());
            //}
          //  teams.AddRange(db.Teams.ToList());
          //  teams.AddRange(Topic(hiveprefix));

            TeamObject Team = new TeamObject();
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["SDMUrl"]);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    //HttpResponseMessage response = await client.GetAsync("api/TeamsAPI/SelectTeams?Abbr=" + Abbr + "&Code="+Code);
            //    HttpResponseMessage response = client.GetAsync("/api/team").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        List<TeamObject> listTeams = response.Content.ReadAsAsync<List<TeamObject>>().Result;

            //        TeamObject newTobj = new TeamObject();
            //        newTobj.ID = -1;
            //        newTobj.DisplayName = "NONE";

            //        listTeams.Add(newTobj);

            //        ViewData["Teams"] = listTeams;
            //    }
            //}

            // ViewData["Teams"] = Team;
            //if (Game.TeamID != null)
            //    if (Game.TeamID != -1 && Game.TeamID != 0)
            //        ViewData["SportID"] = db.Teams.Single(s => s.ID == Game.TeamID).SportID;
            List<TeamObject> listTeams = new List<TeamObject>();
            TeamObject newTobj = new TeamObject();
            newTobj.ID = -1;
            newTobj.DisplayName = "NONE";

            listTeams.Add(newTobj);

            ViewData["Teams"] = listTeams;
            return View();
        }

        //edit many
        //public ActionResult Edit(int EntryTypeID, string hiveprefix)
        //{
        //    FoxTickerEntities db = new FoxTickerEntities();
        //    spTICK_Games_GetByEntryID_Result Game;
        //    //if (id != 0)
        //    //{
        //    if (EntryTypeID == null)
        //    {
        //        return View(new Game());
        //    }

        //    ViewData["HivePrefix"] = hiveprefix;

        //    //null team
        //    Team newTeam = new Team();
        //    newTeam.ID = -1;
        //    newTeam.NickName = "NONE";


        //    List<Team> teams = new List<Team>();
        //    teams.Add(newTeam);

        //    //foreach (Note n in db.Notes.Where(n => n.GameID == id))
        //    //{
        //    //    int iSport = db.Teams.Where(t => t.ID == n.TeamID).FirstOrDefault().SportID;
        //    //    if (teams.Where(t => t.SportID == iSport).Count() == 0)
        //    //        teams.AddRange(db.Teams.Where(tw => tw.SportID == iSport).ToList());
        //    //}
        //    teams.AddRange(db.Teams.ToList());

        //    ViewData["Teams"] = teams;
        //    //if (Game.TeamID != null)
        //    //    if (Game.TeamID != -1 && Game.TeamID != 0)
        //    //        ViewData["SportID"] = db.Teams.Single(s => s.ID == Game.TeamID).SportID;
        //    return View();
        //}
        //
        // POST: /Game/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Game Game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Attach(Game);
                Game.LastUpdated = DateTime.Now;
                db.ObjectStateManager.ChangeObjectState(Game, EntityState.Modified);
                db.SaveChanges();
                return Json(new { success = true }, "text/html");
                //JavaScriptResult result = new JavaScriptResult();
                //result.Script = "ClosePopupandRefresh('#winGameEditor');";
                //return Json("ClosePopupandRefresh('#winGameEditor');");
                //return View();
                //return RedirectToAction("Index");
            }
            return Json(new { error = "Can't Save Game." }, "text/html");
            //return View(Game);
        }

        //
        // GET: /Game/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Game Game = db.Games.Single(g => g.ID == id);
            if (Game == null)
            {
                return HttpNotFound();
            }
            return View(Game);
        }

        //
        // POST: /Game/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game Game = db.Games.Single(g => g.ID == id);
            db.Games.DeleteObject(Game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
