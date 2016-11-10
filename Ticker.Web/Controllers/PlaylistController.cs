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
        ////public IEnumerable<Playlist> GetPlaylists()
        //public DataSourceResult GetPlaylists([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        //{
        //    //return db.Playlists.AsEnumerable();
        //    //return db.Playlists.Where(gw => gw.ClientID == 1).AsEnumerable().ToDataSourceResult(request, g => new
        //    return db.Playlists.Where(gw => gw.ClientID == 1).AsEnumerable().ToDataSourceResult(request, g => new
        //    {
        //        // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
        //        g.ClientID,
        //        g.Name,
        //        g.Locked,
        //        g.Staged,
        //        g.ID,
        //        g.LastUpdated,
        //    });

        //}

        // GET api/Playlist/5

        //public Playlist GetPlaylistsByClientID(int id, int ClientID)
        //{
        //    //Playlist Playlist = db.Playlists.Find(id);
        //    var Playlist = db.Playlists.Single(gw => gw.ClientID == ClientID);
        //    if (Playlist == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return Playlist;
        //}
        public Playlist GetPlaylist(int id)
        {
            //Playlist Playlist = db.Playlists.Find(id);
            var Playlist = db.Playlists.Single(gw => gw.ID == id);
            if (Playlist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Playlist;

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
         public List<Playlist> GetPlaylist(int id, bool Scoreboards)
        {
            List<Playlist>boards = new List<Playlist>();
            Playlist newBoard = new Playlist();
            newBoard.Name = "BLANK";
            newBoard.ClientID = 0;

            boards.Add(newBoard);

            if (id != null)
                boards.AddRange( new FoxTickerEntities().Playlists.Where(gw => gw.ClientID == id && gw.PlaylistTypeID == 2));
            else
                boards.AddRange(new FoxTickerEntities().Playlists.Where(gw => gw.PlaylistTypeID == 2));

            return boards;
         }

        public DataSourceResult GetPlaylist([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request, int id, int clientID)
        {
            //Playlist Playlist = db.Playlists.Find(id);
            var Playlist = db.Playlists.Where(gw => gw.ClientID == clientID);
            if (Playlist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            Playlist.ToList().ForEach(a => a.PlaylistDetails.Load());

            return Playlist.AsEnumerable().OrderBy(o => o.Name).ToDataSourceResult(request, p =>
                new
                {
                    p.ID,
                    p.Name,
                    p.ClientID,
                    p.Staged,
                    hasChildren = p.PlaylistDetails.Any()// .Select(pd => new { ID = pd.ID, Name = pd.OnAirName }).Any()
                    ,p.PlaylistTypeID
                    ,p.ScoreboardID

                    //p.PlaylistDetails.Select(pd => new Dictionary<string, object>{{"ID", pd.ID}, {"Name",pd.OnAirName} })
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
        // PUT api/Playlist/5
        public HttpResponseMessage PutPlaylist(int id, Playlist Playlist)
        {
            if (ModelState.IsValid && id == Playlist.ID)
            {
                //db.Entry(Playlist).State = EntityState.Modified;

                Playlist play = db.Playlists.Single(p => p.ID == id);
                string existingName = play.Name;
                play.Name = Playlist.Name; //they can only change the name
                play.PlaylistTypeID = Playlist.PlaylistTypeID;
                if (Playlist.ScoreboardID == 0)
                    Playlist.ScoreboardID = null;
                play.ScoreboardID = Playlist.ScoreboardID;
                try
                {
                    db.SaveChanges();

                    string clientName = db.Clients.Single(c => c.ID == Playlist.ClientID).Abbreviation;
                    string msg = String.Format("Updated Playlist in \"{0}\"<br />(Existing) Name: \"{1}\"<br />(Updated) Name: \"{2}\"", clientName, existingName, play.Name);

                    Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Playlist), Utilities.Action_Flag.CHANGE, id.ToString(), play.Name, msg, true);
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

        public HttpResponseMessage PutPlaylist(int id, bool Stage)
        {
                db.spTICK_Playlist_Stage(null, id, true);

                return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Playlist
        public HttpResponseMessage PostPlaylist(Playlist Playlist)
        {
            if (ModelState.IsValid)
            {
                if (Playlist.ScoreboardID == 0)
                    Playlist.ScoreboardID = null;

                db.Playlists.AddObject(Playlist);
                db.SaveChanges();

                string clientName = db.Clients.Single(c => c.ID == Playlist.ClientID).Abbreviation;
                string msg = String.Format("Added Playlist to \"{0}\"<br />Name: \"{1}\"", clientName, Playlist.Name);

                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Playlist), Utilities.Action_Flag.ADDITION, Playlist.ID.ToString(), Playlist.Name, msg, true);

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

            string name = Playlist.Name;
            db.Playlists.DeleteObject(Playlist);

            try
            {
                db.SaveChanges();

                string clientName = db.Clients.Single(c => c.ID == Playlist.ClientID).Abbreviation;
                string msg = String.Format("Deleted Playlist from \"{0}\"<br />Name: \"{1}\"", clientName, name);

                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Playlist), Utilities.Action_Flag.DELETION, Playlist.ID.ToString(), name, msg, true);
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