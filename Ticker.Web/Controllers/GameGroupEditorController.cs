using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class GameGroupEditorController : Controller
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        //
        // GET: /Group/

        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }

        //
        // GET: /Group/Details/5

        public ActionResult Details(int id = 0)
        {
            Group group = db.Groups.Single(g => g.ID == id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        //
        // GET: /Group/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Group/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.AddObject(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group);
        }

        //
        // GET: /Group/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FoxTickerEntities db = new FoxTickerEntities();
            Group group;
            //if (id != 0)
            //{
                group = db.Groups.Single(g => g.ID == id);
                if (group == null)
                {
                    return HttpNotFound();
                }
                ViewData["Groups"] = db.Groups.Where(gw => gw.ClientID == 1);

               // ViewData["Users"] = db.Users.Distinct().Select(a => new {ID = a.UserID, Name = a.FirstName + " " + a.LastName});
            //}
            //else
            //    group = new Group();

            //null team
            Team newTeam = new Team();
            newTeam.ID = -1;
            newTeam.NickName = "NONE";


            List<Team> teams = new List<Team>();
            teams.Add(newTeam);

            //foreach (Note n in db.Notes.Where(n => n.GroupID == id))
            //{
            //    int iSport = db.Teams.Where(t => t.ID == n.TeamID).FirstOrDefault().SportID;
            //    if (teams.Where(t => t.SportID == iSport).Count() == 0)
            //        teams.AddRange(db.Teams.Where(tw => tw.SportID == iSport).ToList());
            //}
            teams.AddRange(db.Teams.ToList());

            ViewData["Teams"] = teams;
            if (group.TeamID != null)
                if (group.TeamID != -1 && group.TeamID != 0)
                    ViewData["SportID"] = db.Teams.Single(s => s.ID == group.TeamID).SportID;
            return View(group);
        }

        //
        // POST: /Group/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Attach(group);
                group.LastUpdated = DateTime.Now;
                db.ObjectStateManager.ChangeObjectState(group, EntityState.Modified);
                db.SaveChanges();
                return Json(new { success = true }, "text/html");
                //JavaScriptResult result = new JavaScriptResult();
                //result.Script = "ClosePopupandRefresh('#winEditor');";
                //return Json("ClosePopupandRefresh('#winEditor');");
                //return View();
                //return RedirectToAction("Index");
            }
            return Json(new { error = "Can't Save Group." }, "text/html");
            //return View(group);
        }

        //
        // GET: /Group/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Group group = db.Groups.Single(g => g.ID == id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        //
        // POST: /Group/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Single(g => g.ID == id);
            db.Groups.DeleteObject(group);
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
