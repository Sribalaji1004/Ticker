using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class SportsDataController : Controller
    {

        private FoxTickerEntities db = new FoxTickerEntities();
        //

        // GET: /SportsData/

        public ActionResult Index()
        {

            if (!User.Identity.IsAuthenticated || Session.Count < 1)
                return Redirect("~/User/Login?ReturnUrl=" + Request.Url.PathAndQuery);
            else
            {

                int sdmClientID = db.Clients.Single(c => c.Abbreviation == "SDM_ADMIN").ID;
               // int userid = (int)Session["UserID"];
                string username = Session["FriendlyIdentifier"].ToString().Split('/')[2];
                Ticker.Data.User user = db.Users.Single(u => u.Username == username && u.ClientID == sdmClientID);
                if (user == null)
                    return View();
                else
                    return Redirect(System.Configuration.ConfigurationManager.AppSettings["SDMUrl"] + "?tkunm=" + username);
            }
           // return View();
        }





    }
}
