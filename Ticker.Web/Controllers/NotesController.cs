using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class NotesController : Controller
    {
        //
        // GET: /Groups/

        public ActionResult Index()
        {
            ViewData["Groups"] = new FoxTickerEntities().Groups;
            return View();
        }

    }
}
