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
    public class PlaylistDetailController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/PlaylistDetail
        //public IEnumerable<PlaylistDetail> GetPlaylistDetails()
        public DataSourceResult GetPlaylistDetails([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //return db.PlaylistDetails.AsEnumerable();
            //return db.PlaylistDetails.Where(gw => gw.ClientID == 1).AsEnumerable().ToDataSourceResult(request, g => new
            return db.PlaylistDetails.AsEnumerable().ToDataSourceResult(request, g => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                g.ID,
                g.OnAirName,
                g.EntryTypeID,
                g.EntryID,
                g.PlaylistID,
                g.SortOrder
            });

        }

        // GET api/PlaylistDetail/5
        //public PlaylistDetail GetPlaylistDetail(int id)
        public DataSourceResult GetPlaylistDetail(int id, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //PlaylistDetail PlaylistDetail = db.PlaylistDetails.Find(id);
            var PlaylistDetail = db.PlaylistDetails.Where(gw => gw.ID == id);
            if (PlaylistDetail == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return PlaylistDetail.AsEnumerable().ToDataSourceResult(request, g => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                g.ID,
                g.OnAirName,
                g.EntryTypeID,
                g.EntryID,
                g.PlaylistID,
                g.SortOrder
            }); ;
        }

        // PUT api/PlaylistDetail/5
        public HttpResponseMessage PutPlaylistDetail(int id, PlaylistDetail PlaylistDetail)
        {
            if (ModelState.IsValid && id == PlaylistDetail.ID)
            {
                //db.Entry(PlaylistDetail).State = EntityState.Modified;

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

        // POST api/PlaylistDetail
        public HttpResponseMessage PostPlaylistDetail(PlaylistDetail PlaylistDetail)
        {
            if (ModelState.IsValid)
            {
                db.PlaylistDetails.AddObject(PlaylistDetail);
                db.SaveChanges();

                var correctedResponse = new { Data = new[] { PlaylistDetail } };
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, correctedResponse);

                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, PlaylistDetail);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = PlaylistDetail.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/PlaylistDetail/5
        public HttpResponseMessage DeletePlaylistDetail(int id)
        {
            PlaylistDetail PlaylistDetail = db.PlaylistDetails.Where(gw => gw.ID == id).FirstOrDefault();
            if (PlaylistDetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.PlaylistDetails.DeleteObject(PlaylistDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, PlaylistDetail);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}