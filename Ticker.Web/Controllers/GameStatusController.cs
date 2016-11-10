using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Ticker.Data;

namespace Ticker.Controllers
{
    public class GameStatusController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/GameStatus
        public IEnumerable<dynamic> GetGameStatus()
        {
            var ret = new List<dynamic>();
            dynamic expando = new ExpandoObject();
            expando = new { ID = 1, Description = "All" };
            ret.Add(expando);
            expando = new { ID = 2, Description = "Quick Rips" };
            ret.Add(expando);

            //return ret.Concat(db.GameStatuses.OrderBy(sob => sob.Description).Select(s => new { s.ID, s.Description }));
            return ret;//.Concat(db.GameStatuses.Select(s => new { s.ID, s.Description }));
        }

        // GET api/GameStatus/5
        public GameStatus GetGameStatus(byte id)
        {
            GameStatus gamestatus = db.GameStatuses.Single(g => g.ID == id);
            if (gamestatus == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return gamestatus;
        }

        // PUT api/GameStatus/5
        public HttpResponseMessage PutGameStatus(byte id, GameStatus gamestatus)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != gamestatus.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.GameStatuses.Attach(gamestatus);
            db.ObjectStateManager.ChangeObjectState(gamestatus, EntityState.Modified);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/GameStatus
        public HttpResponseMessage PostGameStatus(GameStatus gamestatus)
        {
            if (ModelState.IsValid)
            {
                db.GameStatuses.AddObject(gamestatus);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, gamestatus);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = gamestatus.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/GameStatus/5
        public HttpResponseMessage DeleteGameStatus(byte id)
        {
            GameStatus gamestatus = db.GameStatuses.Single(g => g.ID == id);
            if (gamestatus == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GameStatuses.DeleteObject(gamestatus);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, gamestatus);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}