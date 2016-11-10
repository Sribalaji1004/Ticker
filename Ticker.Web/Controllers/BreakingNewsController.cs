using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class BreakingNewsController : Controller
    {
        public ActionResult Index()
        {
            //ViewData["BreakingNewsTypes"] = new FoxTickerEntities().BreakingNewsTypes.Where(gw => gw.ClientID == 1);
            return View();
        }
    }
}
