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
    public class BreakingNewsTypeController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/BreakingNewsTypes
        public DataSourceResult GetBreakingNewsType([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            return db.BreakingNewsTypes.AsEnumerable().OrderBy(o => o.Description).ToDataSourceResult(request, p =>
                new
                {
                    p.ID,
                    p.Description,
                    p.Enabled
                });
        }

        // GET api/BreakingNewsTypes/5
        public BreakingNewsType GetBreakingNewsType(int id)
        {
            BreakingNewsType BreakingNewsType = db.BreakingNewsTypes.Single(u => u.ID == id);
            if (BreakingNewsType == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return BreakingNewsType;
        }

        public DataSourceResult GetBreakingNewsType([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request, int id)
        {
            //Playlist Playlist = db.Playlists.Find(id);
            var BreakingNewsType = db.BreakingNewsTypes.Where(gw => gw.ID == id);
            if (BreakingNewsType == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            // BreakingNewsType.ToList().ForEach(a => a.PlaylistDetails.Load());

            return BreakingNewsType.AsEnumerable().OrderBy(o => o.Description).ToDataSourceResult(request, p =>
                new
                {
                    p.ID,
                    p.Description,
                    p.Enabled
                })
                ;

            //return Playlist.AsEnumerable().ToDataSourceResult(request, g => new
            //{
            //    // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
            //    g.ClientID,
            //    g.Name,
            //    g.Locked,
            //    g.Staged,
            //    g.ID,
            //    g.LastUpdated,
            //});
        }

        // PUT api/BreakingNewsTypes/5
        public HttpResponseMessage PutBreakingNewsType(int id, BreakingNewsType BreakingNewsType)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != BreakingNewsType.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.BreakingNewsTypes.Attach(BreakingNewsType);
            db.ObjectStateManager.ChangeObjectState(BreakingNewsType, EntityState.Modified);

            try
            {
                db.SaveChanges();
                Utilities.BreakingNewsTypesLoad();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

            /*if (ModelState.IsValid && id == BreakingNewsType.BreakingNewsTypeID)
            {
                //db.Entry(Playlist).State = EntityState.Modified;

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
            }*/
        }

        public HttpResponseMessage PutBreakingNewsType(int id, bool Enabled)
        {
            //BreakingNewsType BreakingNewsType = db.BreakingNewsTypes.Single(u => u.BreakingNewsTypeID == id);
            //if (BreakingNewsType == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}

            //BreakingNewsType.Inactive = !BreakingNewsType.Inactive;
            ////db.BreakingNewsTypes.DeleteObject(BreakingNewsType);

            //db.BreakingNewsTypes.Where(usr => usr.BreakingNewsTypename == db.BreakingNewsTypes.FirstOrDefault(u => u.BreakingNewsTypeID == id).BreakingNewsTypename).ToList().ForEach(ui => ui.Inactive = !ui.Inactive);
            db.BreakingNewsTypes.Single(u => u.ID == id).Enabled = Enabled;

            try
            {
                db.SaveChanges();
                Utilities.BreakingNewsTypesLoad();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            
            return Request.CreateResponse(HttpStatusCode.OK);//, BreakingNewsType);
        }


        // POST api/BreakingNewsTypes
        public HttpResponseMessage PostBreakingNewsType(BreakingNewsType BreakingNewsType)
        {
            if (ModelState.IsValid)
            {
                db.BreakingNewsTypes.AddObject(BreakingNewsType);
                db.SaveChanges();

                Utilities.BreakingNewsTypesLoad();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, BreakingNewsType);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = BreakingNewsType.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/BreakingNewsTypes/5
        public HttpResponseMessage DeleteBreakingNewsType(int id)
        {
            //BreakingNewsType BreakingNewsType = db.BreakingNewsTypes.Single(u => u.BreakingNewsTypeID == id);
            //if (BreakingNewsType == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}

            //BreakingNewsType.Inactive = !BreakingNewsType.Inactive;
            ////db.BreakingNewsTypes.DeleteObject(BreakingNewsType);

            //db.BreakingNewsTypes.Where(usr => usr.BreakingNewsTypename == db.BreakingNewsTypes.FirstOrDefault(u => u.BreakingNewsTypeID == id).BreakingNewsTypename).ToList().ForEach(ui => ui.Inactive = !ui.Inactive);
            db.BreakingNewsTypes.Single(u => u.ID == id).Enabled = false;

            try
            {
                db.SaveChanges();
                Utilities.BreakingNewsTypesLoad();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);//, BreakingNewsType);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}