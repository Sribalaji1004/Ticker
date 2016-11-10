using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class ViewDataTable
    {
        public int? ID;
        public string Name;
    }
    public class GroupsController : Controller
    {
        //
        // GET: /Groups/



        //List<SelectListItem> teams;
        public ActionResult Index()
        {
            //var groups = new FoxTickerEntities().Groups.Where(gw => gw.ClientID ==1);
            //ViewData["Groups"] = groups;

            ViewData["Groups"] = new FoxTickerEntities().Groups.Where(gw => gw.ClientID == 1);

            //null team
            Team newTeam = new Team();
            newTeam.ID = -1;
            newTeam.NickName="BLANK";

            ////List<SelectListItem> 
            //    teams = new SelectList(ViewBag.Accounts as IEnumerable<Team>, "ID", "NickName").ToList();
            //teams.Insert(0, new SelectListItem { Text = "", Value = "" });
            //new FoxTickerEntities().Teams.Where(tw => tw.SportID == 1).ToList().ForEach(t => teams.Add(new SelectListItem { Text = t.NickName, Value = t.ID.ToString() }));

            //var teams = new FoxTickerEntities().Teams.Where(tw => tw.SportID == 1).Select(ts => new ViewDataTable { ID = ts.ID, Name = ts.NickName }).ToList();
            //teams.Add(new ViewDataTable { Name = string.Empty }); 
            ////teams.Add(newTeam); 
            //ViewData["Teams"] = teams;

            List<Team> teams = new List<Team>(); 
            teams.Add(newTeam);
            teams.AddRange(new FoxTickerEntities().Teams.Where(tw => tw.SportID == 1).ToList());

            ViewData["Teams"] = teams;
            return View();
            //return View(groups.ToList());
        }

    }
}
