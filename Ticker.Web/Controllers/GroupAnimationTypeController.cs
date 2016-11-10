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
    public class GroupAnimationTypeController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/GroupAnimationType
        public IEnumerable<GroupAnimationType> GetGroupAnimationTypes()
        {
            return db.GroupAnimationTypes.AsEnumerable();
        }

        // GET api/GroupAnimationType/5
        public GroupAnimationType GetGroupAnimationType(int id)
        {
            GroupAnimationType groupanimationtype = db.GroupAnimationTypes.Single(g => g.ID == id);
            if (groupanimationtype == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return groupanimationtype;
        }

        // PUT api/GroupAnimationType/5
        public HttpResponseMessage PutGroupAnimationType(int id, GroupAnimationType groupanimationtype)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != groupanimationtype.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.GroupAnimationTypes.Attach(groupanimationtype);
            db.ObjectStateManager.ChangeObjectState(groupanimationtype, EntityState.Modified);

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

        // POST api/GroupAnimationType
        public HttpResponseMessage PostGroupAnimationType(GroupAnimationType groupanimationtype)
        {
            if (ModelState.IsValid)
            {
                db.GroupAnimationTypes.AddObject(groupanimationtype);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, groupanimationtype);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = groupanimationtype.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/GroupAnimationType/5
        public HttpResponseMessage DeleteGroupAnimationType(int id)
        {
            GroupAnimationType groupanimationtype = db.GroupAnimationTypes.Single(g => g.ID == id);
            if (groupanimationtype == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GroupAnimationTypes.DeleteObject(groupanimationtype);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, groupanimationtype);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}