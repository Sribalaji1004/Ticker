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
    public class PlaylistController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Playlist
        //public IEnumerable<Playlist> GetPlaylists()
        public DataSourceResult GetPlaylists([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //return db.Playlists.AsEnumerable();
            //return db.Playlists.Where(gw => gw.ClientID == 1).AsEnumerable().ToDataSourceResult(request, g => new
            return db.Playlists.Where(gw => gw.ClientID == 1).AsEnumerable().ToDataSourceResult(request, g => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                g.ClientID,
                g.Name,
                g.Locked,
                g.Staged,
                g.ID,
                g.LastUpdated,
            });

        }

        // GET api/Playlist/5
        //public Playlist GetPlaylist(int id)
        public DataSourceResult GetPlaylist(int id, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //Playlist Playlist = db.Playlists.Find(id);
            var Playlist = db.Playlists.Where(gw => gw.ClientID == id);
            if (Playlist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Playlist.AsEnumerable().ToDataSourceResult(request, g => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                g.ClientID,
                g.Name,
                g.Locked,
                g.Staged,
                g.ID,
                g.LastUpdated,
            });
        }

        // PUT api/Playlist/5
        public HttpResponseMessage PutPlaylist(int id, Playlist Playlist)
        {
            if (ModelState.IsValid && id == Playlist.ID)
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
            }
        }

        // POST api/Playlist
        public HttpResponseMessage PostPlaylist(Playlist Playlist)
        {
            if (ModelState.IsValid)
            {
                db.Playlists.AddObject(Playlist);
                db.SaveChanges();

                var correctedResponse = new { Data = new[] { Playlist } };
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, correctedResponse);

                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Playlist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Playlist.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Playlist/5
        public HttpResponseMessage DeletePlaylist(int id)
        {
            Playlist Playlist = db.Playlists.Where(gw => gw.ID == id).FirstOrDefault();
            if (Playlist == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Playlists.DeleteObject(Playlist);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Playlist);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}