using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ticker.Controllers
{
    public class UserAdminController : Controller
    {
        //
        // GET: /Admins/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("~/User/Login?ReturnUrl=" + Request.Url.PathAndQuery);
            //else if (User.Identity.IsAuthenticated && Session.Count == 0)
            //{
            //    System.Web.Security.FormsAuthentication.SignOut();
            //    return Redirect("~/User/Login?ReturnUrl=" + Request.Url.PathAndQuery);
            //}
            return View();
        }

        //
        // GET: /Admins/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admins/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admins/Create

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
        // GET: /Admins/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admins/Edit/5

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
        // GET: /Admins/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admins/Delete/5

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
