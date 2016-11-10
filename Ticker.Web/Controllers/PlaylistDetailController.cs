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
                g.HiveID,
                g.SortOrder,
                g.RipCount,
                g.NotesTypeID
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
                g.HiveID,
                g.SortOrder,
                g.RipCount,
                g.NotesTypeID,
                //g.UserNum1
                g.Specifics1
            });
        }

        // PUT api/PlaylistDetail/5
        public HttpResponseMessage PutPlaylistDetail(int id, PlaylistDetail PlaylistDetail)
        {
            if (ModelState.IsValid && id == PlaylistDetail.ID)
            {
                PlaylistDetail.SDMLeagueCode = db.PlaylistDetails.Where(p => p.ID == id).Select(p => p.SDMLeagueCode).FirstOrDefault();
                //db.Entry(PlaylistDetail).State = EntityState.Modified;
                db.PlaylistDetails.Attach(PlaylistDetail);
                db.ObjectStateManager.ChangeObjectState(PlaylistDetail, EntityState.Modified);

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

        public HttpResponseMessage PutPlaylistDetail(int id, int SortOrder) //new sort order
        {
            PlaylistDetail PlaylistDetail = db.PlaylistDetails.Where(le => le.ID == id).Single();
            Playlist playlist = db.Playlists.Single(pl => pl.ID == PlaylistDetail.PlaylistID);

            int newRank = SortOrder;
            int? oldRank = PlaylistDetail.SortOrder;

            if (newRank > oldRank) newRank++;

            List<PlaylistDetail> lpld = new List<PlaylistDetail>();
            lpld.AddRange(db.PlaylistDetails.Where(le => le.PlaylistID == PlaylistDetail.PlaylistID && le.SortOrder < newRank && le.ID != id).OrderBy(ob => ob.SortOrder).ToList());
            lpld.Add(db.PlaylistDetails.Where(le => le.ID == id).Single());
            foreach (PlaylistDetail l in db.PlaylistDetails.Where(le => le.PlaylistID == PlaylistDetail.PlaylistID).OrderBy(ob => ob.SortOrder))
                if (lpld.Where(le => le.ID == l.ID).Count() == 0)
                    lpld.Add(l);

            for (int i = 0; i < lpld.Count; i++)
                lpld[i].SortOrder = i + 1;

            try
            {
                db.SaveChanges();

                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Playlist), Utilities.Action_Flag.CHANGE, playlist.ID.ToString(), playlist.Name, "Updated Game/Group Order in Playlist \"" + playlist.Name + "\"", true);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        public HttpResponseMessage PutPlaylistDetail(int id, byte? RipCount, byte? NotesTypeID) //new rip info
        {
            PlaylistDetail PlaylistDetail = db.PlaylistDetails.Where(le => le.ID == id).Single();
            Playlist playlist = db.Playlists.Single(pl => pl.ID == PlaylistDetail.PlaylistID);


            PlaylistDetail.RipCount = RipCount;
            PlaylistDetail.NotesTypeID = NotesTypeID;
            
            try
            {
                db.SaveChanges();

                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Playlist), Utilities.Action_Flag.CHANGE, playlist.ID.ToString(), playlist.Name, "Updated Game/Group Rip in Playlist \"" + playlist.Name + "\"", true);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        // POST api/PlaylistDetail
        public HttpResponseMessage PostPlaylistDetail(PlaylistDetail PlaylistDetail)
        {
            Playlist playlist = db.Playlists.Single(pl => pl.ID == PlaylistDetail.PlaylistID);

            if (ModelState.IsValid)
            {

                if (PlaylistDetail.HiveID != null)
                    if (PlaylistDetail.HiveID != "undefined")
                    {
                        //PlaylistDetail.EntryID = db.Sports.Single(s => s.HivePrefix == PlaylistDetail.OnAirName).ID;
                    }
                    //if (PlaylistDetail.HiveID == "undefined")
                    else
                        PlaylistDetail.HiveID = null;


                db.PlaylistDetails.AddObject(PlaylistDetail);
                db.SaveChanges();

                int? newRank = PlaylistDetail.SortOrder;
                //int? oldRank;

                //if (newRank > oldRank) newRank++;

                List<PlaylistDetail> lpld = new List<PlaylistDetail>();
                lpld.AddRange(db.PlaylistDetails.Where(le => le.PlaylistID == PlaylistDetail.PlaylistID && le.SortOrder < newRank && le.ID != PlaylistDetail.ID).OrderBy(ob => ob.SortOrder).ToList());

                //if (lpld.Count != newRank )
                //{
                    lpld.Add(db.PlaylistDetails.Where(le => le.ID == PlaylistDetail.ID).Single());
                    foreach (PlaylistDetail l in db.PlaylistDetails.Where(le => le.PlaylistID == PlaylistDetail.PlaylistID).OrderBy(ob => ob.SortOrder))
                        if (lpld.Where(le => le.ID == l.ID).Count() == 0)
                            lpld.Add(l);

                    for (int i = 0; i < lpld.Count; i++)
                        lpld[i].SortOrder = i + 1;
                    db.SaveChanges();
                //}

                var correctedResponse = new { Data = new[] { PlaylistDetail } };
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, correctedResponse);

                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, PlaylistDetail);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = PlaylistDetail.ID }));

                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Playlist), Utilities.Action_Flag.ADDITION, playlist.ID.ToString(), playlist.Name, "Added Game/Group to Playlist \"" + playlist.Name + "\"", true);
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
            Playlist playlist = db.Playlists.Single(pl => pl.ID == PlaylistDetail.PlaylistID);

            if (PlaylistDetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            List<PlaylistDetail> lpld = new List<PlaylistDetail>();
            lpld.AddRange(db.PlaylistDetails.Where(le => le.PlaylistID == PlaylistDetail.PlaylistID && le.ID != id).OrderBy(ob => ob.SortOrder).ToList());

            for (int i = 0; i < lpld.Count; i++)
                lpld[i].SortOrder = i + 1;
            db.SaveChanges();

            db.PlaylistDetails.DeleteObject(PlaylistDetail);

            try
            {
                db.SaveChanges();

                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Playlist), Utilities.Action_Flag.DELETION, playlist.ID.ToString(), playlist.Name, "Deleted Group/Game from Playlist \"" + playlist.Name + "\"", true);
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