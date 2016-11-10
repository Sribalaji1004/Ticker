using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class GroupEditorController : Controller
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
            if (group.OnAirName == null || group.OnAirName == "")
            {
                ModelState.AddModelError("OnAirName", "OnAirName is required.");
                return Json(new { error = "OnAirName is required." }, "text/html");
            }

            if (ModelState.IsValid)
            {
                //db.Groups.Attach(group);
                Group existingGroup = db.Groups.Single(g => g.ID == group.ID);

                string existingTeam = existingGroup.TeamID == null ? "" : existingGroup.TeamID != -1 && existingGroup.TeamID != 0 ? db.Teams.Single(t => t.ID == existingGroup.TeamID).NickName : "";
                string newTeam = group.TeamID == null ? "" : group.TeamID != -1 ? db.Teams.Single(t => t.ID == group.TeamID).NickName : "";
                string msg = String.Format("Updated Group<br />(Existing) Name: \"{0}\" - Team: \"{1}\" - OnAirName: \"{2}\" - Header: \"{3}\"" +
                    "<br />(Updated) Name: \"{4}\" - Team: \"{5}\" - OnAirName: \"{6}\" - Header: \"{7}\"", existingGroup.Name, existingTeam,
                    existingGroup.OnAirName, existingGroup.Header, group.Name, newTeam, group.OnAirName, group.Header);
                existingGroup.Name = group.Name;
                existingGroup.TeamID = group.TeamID;
                existingGroup.OnAirName = group.OnAirName;
                existingGroup.Header = group.Header;
                existingGroup.LastUpdated = DateTime.Now;

                //db.ObjectStateManager.ChangeObjectState(group, EntityState.Modified);
                db.SaveChanges();

                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Group), Utilities.Action_Flag.CHANGE, group.ID.ToString(), group.Name, msg, true);

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
