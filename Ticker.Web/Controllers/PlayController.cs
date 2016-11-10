using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class PlayController : Controller
    {
        //
        // GET: /Play/

        public ActionResult Index()
        {
            return View(new FoxTickerEntities().Clients);
        }

    }
}
