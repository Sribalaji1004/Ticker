using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticker.Views.Logs
{
    public class LogsController : Controller
    {
        //
        // GET: /Logs/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Logs/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Logs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Logs/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Logs/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Logs/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Logs/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Logs/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
