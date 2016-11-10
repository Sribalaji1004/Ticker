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
    public class GroupController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Group
        //public IEnumerable<Group> GetGroups()
        public DataSourceResult GetGroups([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //return db.Groups.AsEnumerable();
            //return db.Groups.Where(gw => gw.ClientID == 1).AsEnumerable().ToDataSourceResult(request, g => new
            return db.Groups.Where(gw => gw.ClientID == 1).AsEnumerable().ToDataSourceResult(request, g => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                g.ClientID,
                g.CreatedName,
                g.Editable,
                g.GroupAnimationTypeID,
                g.Header,
                g.ID,
                g.LastUpdated,
                g.Name,
                //g.Notes,
                g.OnAirName,
                g.TeamID,
                g.Type
            });

        }

        // GET api/Group/5
        //public Group GetGroup(int id)
        public DataSourceResult GetGroup(int id, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //Group group = db.Groups.Find(id);
            var group = db.Groups.Where(gw => gw.ID == id);
            if (group == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return group.AsEnumerable().ToDataSourceResult(request, g => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                g.ClientID,
                g.CreatedName,
                g.Editable,
                g.GroupAnimationTypeID,
                g.Header,
                g.ID,
                g.LastUpdated,
                g.Name,
                //g.Notes,
                g.OnAirName,
                g.TeamID,
                g.Type
            }); ;
        }

        // PUT api/Group/5
        public HttpResponseMessage PutGroup(int id, Group group)
        {
            if (ModelState.IsValid && id == group.ID)
            {
                //db.Entry(group).State = EntityState.Modified;

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

        // POST api/Group
        public HttpResponseMessage PostGroup(Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.AddObject(group);
                db.SaveChanges();

                var correctedResponse = new { Data = new[] { group } };
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, correctedResponse);

                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, group);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = group.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Group/5
        public HttpResponseMessage DeleteGroup(int id)
        {
            Group group = db.Groups.Where(gw => gw.ID == id).FirstOrDefault();
            if (group == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Groups.DeleteObject(group);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, group);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}