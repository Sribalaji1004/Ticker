using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class GameEditorController : Controller
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        //
        // GET: /Game/

        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }

        //
        // GET: /Game/Details/5

        public ActionResult Details(int id = 0)
        {
            spTICK_Games_GetByEntryID_Result Game = db.spTICK_Games_GetByEntryID(0, id, 2, false, false).First();
            if (Game == null)
            {
                return HttpNotFound();
            }
            return View(Game);
        }

        //
        // GET: /Game/Create

        public ActionResult Create()
        {
            return View();
        }


        //
        // GET: /Game/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FoxTickerEntities db = new FoxTickerEntities();
            spTICK_Games_GetByEntryID_Result Game;
            //if (id != 0)
            //{
            if (id == 0)
            {
                return View(new Game());
            }

            Game = db.spTICK_Games_GetByEntryID(0, id, 2, false, false).First(); ;
            if (Game == null)
            {
                return HttpNotFound();
            }
            ViewData["Games"] = db.spTICK_Games_GetByEntryID(0, id, 2, false, false).First();

            //ViewData["Users"] = db.Users.Distinct().Select(a => new { ID = a.UserID, Name = a.FirstName + " " + a.LastName });
            //}
            //else
            //    Game = new Game();

            //null team
            Team newTeam = new Team();
            newTeam.ID = -1;
            newTeam.NickName = "NONE";


            List<Team> teams = new List<Team>();
            teams.Add(newTeam);

            //foreach (Note n in db.Notes.Where(n => n.GameID == id))
            //{
            //    int iSport = db.Teams.Where(t => t.ID == n.TeamID).FirstOrDefault().SportID;
            //    if (teams.Where(t => t.SportID == iSport).Count() == 0)
            //        teams.AddRange(db.Teams.Where(tw => tw.SportID == iSport).ToList());
            //}
            teams.AddRange(db.Teams.ToList());

            ViewData["Teams"] = teams;
            //if (Game.TeamID != null)
            //    if (Game.TeamID != -1 && Game.TeamID != 0)
            //        ViewData["SportID"] = db.Teams.Single(s => s.ID == Game.TeamID).SportID;
            return View(Game);
        }

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
