using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class ClientsController : Controller
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        //
        // GET: /Clients/

        public ActionResult Index()
        {
            ViewData["Clients"] = db.Clients.ToList();
            return View();
        }

        ////
        //// GET: /Clients/Details/5

        //public ActionResult Details(byte id = 0)
        //{
        //    Client client = db.Clients.Single(c => c.ID == id);
        //    if (client == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(client);
        //}

        ////
        //// GET: /Clients/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /Clients/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Client client)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Clients.AddObject(client);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(client);
        //}

        ////
        //// GET: /Clients/Edit/5

        //public ActionResult Edit(byte id = 0)
        //{
        //    Client client = db.Clients.Single(c => c.ID == id);
        //    if (client == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(client);
        //}

        ////
        //// POST: /Clients/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Client client)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Clients.Attach(client);
        //        db.ObjectStateManager.ChangeObjectState(client, EntityState.Modified);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(client);
        //}

        ////
        //// GET: /Clients/Delete/5

        //public ActionResult Delete(byte id = 0)
        //{
        //    Client client = db.Clients.Single(c => c.ID == id);
        //    if (client == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(client);
        //}

        ////
        //// POST: /Clients/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(byte id)
        //{
        //    Client client = db.Clients.Single(c => c.ID == id);
        //    db.Clients.DeleteObject(client);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}