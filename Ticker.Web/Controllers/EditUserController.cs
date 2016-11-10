using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class EditUserController : Controller
    {
        //
        // GET: /EditUser/

        public ActionResult Index(int UserID)
        {
            FoxTickerEntities db = new FoxTickerEntities();

            ViewData["Username"] = db.Users.Where(gw => gw.UserID == UserID).Single().Username;
            ViewData["FirstName"] = db.Users.Where(gw => gw.UserID == UserID).Single().FirstName;
            ViewData["LastName"] = db.Users.Where(gw => gw.UserID == UserID).Single().LastName;

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/User/Login?ReturnUrl=" + Request.Url.PathAndQuery);
            }
            return View("Index");
        }

    }
}
