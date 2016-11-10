using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
    //public class ViewDataTable
    //{
    //    public int? ID;
    //    public string Name;
    //}
    public class PlaylistsController : Controller
    {
        //
        // GET: /Groups/


        //public JsonResult GetClients(string text)
        //{
        //    FoxTickerEntities db = new FoxTickerEntities();
        //    var userClients = db.spTICK_Users_Get(Session["username"].ToString()).Select(c => c.ClientID).ToArray(); 
        //    var clients = db.Clients.Where(p => userClients.Contains(p.ID));

        //    if (!string.IsNullOrEmpty(text))
        //    {
        //        clients = clients.Where(p => p.Description.Contains(text));
        //    }

        //    return Json(clients.OrderBy(d => d.Description), JsonRequestBehavior.AllowGet);
        //}
        //List<SelectListItem> teams;
        //public ActionResult Index()
        //public ActionResult Index(int clientID, int playlistID)

        public ActionResult Index()//int? clientID)
        {
            int ClientID;


            List<Playlist>boards = new List<Playlist>();
            Playlist newBoard = new Playlist();
            newBoard.Name = "BLANK";
            newBoard.ClientID = 0;

            boards.Add(newBoard);

            //if (Request.QueryString["ClientID"] != null)
            //{
              //  ClientID = int.Parse(Request.QueryString["ClientID"]);
                //boards.AddRange( new FoxTickerEntities().Playlists.Where(gw => gw.ClientID == ClientID && gw.PlaylistTypeID == 2));
                boards.AddRange(new FoxTickerEntities().Playlists.Where(gw => gw.PlaylistTypeID == 2));
            //}


            ViewData["Scoreboards"] = boards.Select(b => new { b.ClientID, b.ID, b.Name});

            ViewData["PlaylistTypes"] = new FoxTickerEntities().PlaylistTypes; 

            //ViewData["Playlists"] = new FoxTickerEntities().Playlists.Where(gw => gw.ClientID == 1);
            //ViewData["PlaylistDetails"] = new FoxTickerEntities().PlaylistDetails;
            //ViewData["Groups"] = new FoxTickerEntities().Groups.Where(gw => gw.ClientID == 1);

            //ViewData["ClientID"] = clientID;
            //ViewData["ClientID"] = clientID;

            //ViewData["ClientID"] = new FoxTickerEntities().Playlists.Where(plw => plw.ID == playlistID).Single().ClientID;

            //null team
            //Team newTeam = new Team();
            ////newTeam.ID = -1;
            //newTeam.NickName="BLANK";

            //////List<SelectListItem> 
            ////    teams = new SelectList(ViewBag.Accounts as IEnumerable<Team>, "ID", "NickName").ToList();
            ////teams.Insert(0, new SelectListItem { Text = "", Value = "" });
            ////new FoxTickerEntities().Teams.Where(tw => tw.SportID == 1).ToList().ForEach(t => teams.Add(new SelectListItem { Text = t.NickName, Value = t.ID.ToString() }));

            ////var teams = new FoxTickerEntities().Teams.Where(tw => tw.SportID == 1).Select(ts => new ViewDataTable { ID = ts.ID, Name = ts.NickName }).ToList();
            ////teams.Add(new ViewDataTable { Name = string.Empty }); 
            //////teams.Add(newTeam); 
            ////ViewData["Teams"] = teams;

            //List<Team> teams = new List<Team>(); 
            //teams.Add(newTeam);
            //teams.AddRange(new FoxTickerEntities().Teams.Where(tw => tw.SportID == 1).ToList());

            //ViewData["Teams"] = teams;

            if (!User.Identity.IsAuthenticated)
                return Redirect("~/User/Login?ReturnUrl=" + Request.Url.PathAndQuery);
            else if (Session.Count <= 1)// == 0 && Session.IsNewSession)
            {
                System.Web.Security.FormsAuthentication.SignOut();
                return Redirect("~/User/Login?ReturnUrl=" + Request.Url.PathAndQuery);
            }

            return View();
        }

    }
}
