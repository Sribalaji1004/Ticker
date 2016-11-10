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
    public class GameController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        //// GET api/Game
        ////public IEnumerable<Game> GetGames()
        //public DataSourceResult GetGames([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        //{
        //    //return db.Games.AsEnumerable();
        //    //return db.Games.Where(gw => gw.ClientID == 1).AsEnumerable().ToDataSourceResult(request, g => new
        //    return db.Games.Where(gw => gw. == 1).AsEnumerable().ToDataSourceResult(request, g => new
        //    {
        //        // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
        //        g.ClientID,
        //        g.CreatedName,
        //        g.Editable,
        //        g.GameAnimationTypeID,
        //        g.Header,
        //        g.ID,
        //        g.LastUpdated,
        //        g.Name,
        //        //g.Notes,
        //        g.OnAirName,
        //        g.TeamID,
        //        g.Type
        //    });

        //}

        // GET api/Game/5
        //public Game GetGame(int id)
        public DataSourceResult GetGame(int id, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //Game Game = db.Games.Find(id);
            var Game = db.Games.Where(gw => gw.ID == id);
            if (Game == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Game.AsEnumerable().ToDataSourceResult(request, g => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                g.BlockData,
                g.BoxScore,
                g.Clock,
                g.CSSID,
                g.Details,
                g.DetailsPostScore,
                g.DetailsPreScore,
                g.GameDateTime,
                g.GameStatusID,
                g.Header,
                g.HomeID,
                g.HomeScore,
                g.ID,
                g.LastHomeScore,
                g.LastUpdated,
                g.LastVisitorsScore,
                g.ScoreAlertID,
                g.ScoreDescription,
                g.ScoreDescriptionAlt,
                g.ScoreLastUpdated,
                g.SortOrder,
                g.SportID,
                g.StatsIncID,
                g.StatusID,
                g.StatusIDPreScore,
                g.TeamID,
                g.VisitorsID,
                g.VisitorsScore
            }); ;
        }

        // PUT api/Game/5
        public HttpResponseMessage PutGame(int id, Game Game)
        {
            if (ModelState.IsValid && id == Game.ID)
            {
                //db.Entry(Game).State = EntityState.Modified;

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

        // POST api/Game
        public HttpResponseMessage PostGame(Game Game)
        {
            if (ModelState.IsValid)
            {
                db.Games.AddObject(Game);
                db.SaveChanges();

                var correctedResponse = new { Data = new[] { Game } };
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, correctedResponse);

                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Game);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Game.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Game/5
        public HttpResponseMessage DeleteGame(int id)
        {
            Game Game = db.Games.Where(gw => gw.ID == id).FirstOrDefault();
            if (Game == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Games.DeleteObject(Game);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Game);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}