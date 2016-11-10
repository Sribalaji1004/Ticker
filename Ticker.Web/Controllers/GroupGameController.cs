using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class GroupGameController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/GroupGame
        //public IEnumerable<GroupGame> GetGroupGames()
        public DataSourceResult GetGroupGames([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            //return db.GroupGames.AsEnumerable();
            //return db.GroupGames.Where(gw => gw.ClientID == 1).AsEnumerable().ToDataSourceResult(request, g => new
            //return db.GroupGames.OrderBy(o => o.SortOrder).AsEnumerable().ToDataSourceResult(request, g => new
            //{
            //    // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
            //    g.ID,
            //    g.HiveID,
            //    g.GroupID,
            //    g.GameID,
            //    g.SportID,
            //    g.SortOrder
            //});

        }

        // GET api/GroupGame/5
        //public GroupGame GetGroupGame(int id)
        public DataSourceResult GetGroupGame(int cid, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //GroupGame GroupGame = db.GroupGames.Find(id);
            var GroupGame = db.GroupGames.Where(gw => gw.ID == cid);
            if (GroupGame == null)
            {
                return null; // throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return GroupGame.OrderBy(o => o.SortOrder).AsEnumerable().ToDataSourceResult(request, g => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                g.ID,
                g.HiveID,
                g.GroupID,
                g.GameID,
                g.SportID,
                g.SortOrder
            });
        }

        // GET api/GroupGame/5
        //public GroupGame GetGroupGame(int id)
        public dynamic GetGroupGame(bool Group, int cid, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            if (Group)
            {
                return db.Groups.Where(gw => gw.ID == cid).Select(p =>
             new
             {
                 p.ID,
                 p.Name,
                 hasChildren = db.GroupGames.Where(gw => gw.GroupID == cid).Any()// .Select(pd => new { ID = pd.ID, Name = pd.OnAirName }).Any()
                 //p.PlaylistDetails.Select(pd => new Dictionary<string, object>{{"ID", pd.ID}, {"Name",pd.OnAirName} })
             })
             ;
            }
            else
            {

                //GroupGame GroupGame = db.GroupGames.Find(id);
                var GroupGame = db.GroupGames.Where(gw => gw.GroupID == cid);
                if (GroupGame == null)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }

                return GroupGame
                    .Select(sg => new { sg.ID, sg.HiveID, sg.GroupID, sg.GameID, sg.SportID, sg.SortOrder,sg.SDMLeagueCode })
                    .AsEnumerable()
                    .OrderBy(o => o.SortOrder)
                    .Select(g => new
                {
                    // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                    Name = "",
                    g.ID,
                    g.HiveID,
                   // HivePrefix = db.Sports.Single(s => s.ID == g.SportID).HivePrefix, // g.SDMLeagueCode
                    HivePrefix = g.SDMLeagueCode, // g.SDMLeagueCode
                    g.GroupID,
                    g.GameID,
                    g.SportID,
                    g.SortOrder
                });
            }
        }

        // GET api/GroupGame/5
        //public GroupGame GetGroupGame(int id)
        public DataSourceResult GetGroupGame(bool Kendo, bool Group, int cid, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //GroupGame GroupGame = db.GroupGames.Find(id);
            var GroupGame = db.GroupGames.Where(gw => gw.GroupID == cid);
            if (GroupGame == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return GroupGame
                .Select(sg => new { sg.ID, sg.HiveID, sg.GroupID, sg.GameID, sg.SportID, sg.SortOrder,sg.SDMLeagueCode })
                .AsEnumerable()
                .OrderBy(o => o.SortOrder)
                .ToDataSourceResult(request, g => new
                {
                    // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                    Name = "",
                    g.ID,
                    g.HiveID,
                    //HivePrefix = db.Sports.Single(s => s.ID==g.SportID).HivePrefix,
                    HivePrefix = g.SDMLeagueCode,
                    g.GroupID,
                    g.GameID,
                    g.SportID,
                    g.SortOrder
                });
        }

        // PUT api/GroupGame/5
        public HttpResponseMessage PutGroupGame(int id, GroupGame GroupGame)
        {
            if (ModelState.IsValid && id == GroupGame.ID)
            {
                //db.Entry(GroupGame).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage PutGroupGame(int id, int SortOrder) //new sort order
        {
            GroupGame GroupGame = db.GroupGames.Where(le => le.ID == id).Single();
            int newRank = SortOrder;
            int? oldRank = GroupGame.SortOrder;

            //if (newRank > oldRank) newRank++;

            List<GroupGame> lpld = new List<GroupGame>();
            lpld.AddRange(db.GroupGames.Where(le => le.GroupID == GroupGame.GroupID && le.SortOrder < newRank && le.ID != id).OrderBy(ob => ob.SortOrder).ToList());
            lpld.Add(db.GroupGames.Where(le => le.ID == id).Single());
            foreach (GroupGame l in db.GroupGames.Where(le => le.GroupID == GroupGame.GroupID).OrderBy(ob => ob.SortOrder))
                if (lpld.Where(le => le.ID == l.ID).Count() == 0)
                    lpld.Add(l);

            for (int i = 0; i < lpld.Count; i++)
                lpld[i].SortOrder = i + 1;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/GroupGame
        public HttpResponseMessage PostGroupGame(GroupGame GroupGame)
        {
            if (ModelState.IsValid)
            {

                //if (GroupGame.HiveID != null)
                //    if (GroupGame.HiveID != "undefined")
                //    {
                //        GroupGame.sp = db.Sports.Single(s => s.HivePrefix == GroupGame.OnAirName).ID;
                //    }
                //    //if (GroupGame.HiveID == "undefined")
                //    else
                //        GroupGame.HiveID = null;


                //if (GroupGame.SortOrder > 0)
                //    GroupGame.SortOrder--;
                db.GroupGames.AddObject(GroupGame);
                db.SaveChanges();
                
                int? newRank = GroupGame.SortOrder;

                if (newRank == db.GroupGames.Where(le => le.GroupID == GroupGame.GroupID).Count())
                    newRank++;

                //int? oldRank;

                //if (newRank > oldRank) newRank++;

                List<GroupGame> lpld = new List<GroupGame>();
                lpld.AddRange(db.GroupGames.Where(le => le.GroupID == GroupGame.GroupID && le.SortOrder < newRank && le.ID != GroupGame.ID).OrderBy(ob => ob.SortOrder).ToList());
                //lpld.Add(GroupGame);
                lpld.Add(db.GroupGames.Where(le => le.ID == GroupGame.ID).Single());
                foreach (GroupGame l in db.GroupGames.Where(le => le.GroupID == GroupGame.GroupID).OrderBy(ob => ob.SortOrder))
                    if (lpld.Where(le => le.ID == l.ID).Count() == 0)
                        lpld.Add(l);

                for (int i = 0; i < lpld.Count; i++)
                    lpld[i].SortOrder = i + 1;

                db.SaveChanges();



                var correctedResponse = new { Data = new[] { GroupGame } };
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, correctedResponse);

                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, GroupGame);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = GroupGame.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/GroupGame/5
        public HttpResponseMessage DeleteGroupGame(int id)
        {
            GroupGame GroupGame = db.GroupGames.Where(gw => gw.ID == id).FirstOrDefault();
            if (GroupGame == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GroupGames.DeleteObject(GroupGame);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, GroupGame);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}