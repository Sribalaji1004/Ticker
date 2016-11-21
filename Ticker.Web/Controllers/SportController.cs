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
    public class SportController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Sport
        public IEnumerable<dynamic> GetSports()
        {
            var ret = new List<dynamic>();
            dynamic expando = new ExpandoObject();
            expando = new { ID = 0, LongDisplay = "NONE" };
            ret.Add(expando);

            return ret.Concat(db.Sports.OrderBy(sob => sob.LongDisplay).Select(s => new { s.ID, s.LongDisplay }));
        }

        // GET api/Sport/5
        public Sport GetSport(int id)
        {
            Sport sport = db.Sports.Single(s => s.ID == id);
            if (sport == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return sport;
        }
        // GET api/Sport/5?
        public Sport GetSport(int id, string HivePrefix)
        {
            Sport sport;
            try
            {
                sport = db.Sports.Single(s => s.HivePrefix == HivePrefix);
            }
            catch
            {
                return null;
            }
            if (sport == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return sport;
        }
        // GET api/Sport/5?teamID=5
        public Sport GetSport(int id, int teamID)
        {
            if (teamID == -1 || teamID == 0)
                return null;
            Sport sport = db.Sports.Where(s => s.Teams.Where(t => t.ID == teamID).Count() > 0).Single();
            if (sport == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return sport;
        }

        // PUT api/Sport/5
        public HttpResponseMessage PutSport(int id, Sport sport)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != sport.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Sports.Attach(sport);
            db.ObjectStateManager.ChangeObjectState(sport, EntityState.Modified);

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

        // POST api/Sport
        public HttpResponseMessage PostSport(Sport sport)
        {
            if (ModelState.IsValid)
            {
                db.Sports.AddObject(sport);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, sport);
                response.Headers.Location = new Uri(Url.Link("Default1Api", new { id = sport.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Sport/5
        public HttpResponseMessage DeleteSport(int id)
        {
            Sport sport = db.Sports.Single(s => s.ID == id);
            if (sport == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Sports.DeleteObject(sport);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, sport);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}