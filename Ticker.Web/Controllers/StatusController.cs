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
using Ticker.Data;

namespace Ticker.Controllers
{
    public class StatusController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Status
        public IEnumerable<Status> GetStatus()
        {
            var statuses = db.Statuses.Include("Sport");
            return statuses.AsEnumerable();
        }

        // GET api/Status/5
        public Status GetStatus(int id)
        {
            Status status = db.Statuses.Single(s => s.ID == id);
            if (status == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return status;
        }
        public IEnumerable<Status> GetStatus(int id, int sportID)
        {
            IEnumerable<Status> status = db.Statuses.Where(s => s.SportID == sportID).OrderBy(sob => sob.Description).AsEnumerable();
            if (status == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return status;
        }

        // PUT api/Status/5
        public HttpResponseMessage PutStatus(int id, Status status)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != status.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Statuses.Attach(status);
            db.ObjectStateManager.ChangeObjectState(status, EntityState.Modified);

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

        // POST api/Status
        public HttpResponseMessage PostStatus(Status status)
        {
            if (ModelState.IsValid)
            {
                db.Statuses.AddObject(status);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, status);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = status.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Status/5
        public HttpResponseMessage DeleteStatus(int id)
        {
            Status status = db.Statuses.Single(s => s.ID == id);
            if (status == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Statuses.DeleteObject(status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, status);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}