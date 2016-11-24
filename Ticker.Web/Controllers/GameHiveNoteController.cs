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
using System.Data.Objects.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Ticker.Controllers
{
    public class GameHiveNoteController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        private GameHiveNoteController()
        {
            db.ContextOptions.LazyLoadingEnabled = false;
        }

        //private static IEnumerable<Note> LazyReload(IEnumerable<Note> query)
        //{
        //    query.ToList().ForEach(a => LazyReload(a));

        //    return query;
        //}
        //private static Note LazyReload(Note note)
        //{
        //    note.GroupReference.Load();
        //    return note;
        //}

        // GET api/Note
        public DataSourceResult GetGameHiveNotes([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //return db.GameHiveNotes.AsEnumerable();
            //return LazyReload(db.GameHiveNotes.AsEnumerable()).ToDataSourceResult(request, n => new
            //return db.GameHiveNotes.Include("Group").AsEnumerable().ToDataSourceResult(request, n => new
            
            return db.GameHiveNotes
                .Select(on => new { on.SportID, on.Header, on.NoteColor, on.TeamID, on.ID, on.Note, on.UserID, on.LastUpdated, on.HiveID, on.SortOrder, on.ClientID }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                .AsEnumerable()
                .OrderBy(s => s.SortOrder)
                .ToDataSourceResult(request, n => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //n.Group,
                //Game = db.Games.Where(g => g.ID == n.GameID).First(),
                n.HiveID,
                n.ClientID,
                n.Header,
                n.ID,
                n.LastUpdated,
                n.SportID,
                //LastUpdatedBy = (n.UserID != null && n.UserID != 0 ? " last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated.ToString() : n.Note),
                n.NoteColor,
                n.SortOrder,
                n.TeamID,
                n.UserID
            });

        }

        //class GameHiveNoteSelectable
        //{
        //    int HiveID;
        //    int ClientID;
        //    string Header;
        //    int ID;
        //    string Note;
        //    DateTime LastUpdated;
        //    int SportID;
        //    string NoteColor;
        //    int SortOrder;
        //    int TeamID;
        //    int UserID;
        //}

        // GET api/Note/5
        //public Note GetNote(int id)
        //public DataSourceResult GetGameHiveNote(string CorrelationId, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        public dynamic GetGameHiveNote(string CorrelationId, int ClientID)
        {
            //Note Note = db.GameHiveNotes.Find(id);
            //var Note = LazyReload(db.GameHiveNotes.Where(gw => gw.ID == id));
            Utilities.LoadClientShares(db, ClientID);

            List<GameHiveNote> lstNote = new List<GameHiveNote>();

            foreach (Client c in db.Clients.Single(s => s.ID == ClientID).Clients)
                lstNote = lstNote.Concat(db.GameHiveNotes.Where(gw => gw.HiveID == CorrelationId && gw.ClientID == c.ID)).ToList();

            var Note = lstNote.Concat(db.GameHiveNotes.Where(gw => gw.HiveID == CorrelationId && gw.ClientID == ClientID));
                        
            if (Note == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Note
                .Select(on => new { on.SportID, on.Header, on.NoteColor, on.TeamID, on.ID, on.Note, on.UserID, on.LastUpdated, on.HiveID, on.SortOrder, on.ClientID }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                .AsEnumerable()
                .OrderBy(s => s.SortOrder)
                .Select(n => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //n.Group,
                //Game = db.Games.Where(g => g.ID == n.GameID).First(),
                n.HiveID,
                n.ClientID,
                n.Header,
                n.ID,
                n.Note,
                n.LastUpdated,
                n.SportID,
                //LastUpdatedBy = (n.UserID != null && n.UserID != 0 ? " last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated.ToString() : n.Note),
                NoteColor = n.NoteColor,//Utilities.ConvertToHTML(n.NoteColor),
                n.SortOrder,
                n.TeamID,
                n.UserID
            });
        }
        public DataSourceResult GetGameHiveNote(bool useGrid, string CorrelationId, int ClientID, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //Note Note = db.GameHiveNotes.Find(id);
            //var Note = LazyReload(db.GameHiveNotes.Where(gw => gw.ID == id));

            Utilities.LoadClientShares(db, ClientID);

            List<GameHiveNote> lstNote = new List<GameHiveNote>();

            foreach (Client c in db.Clients.Single(s => s.ID == ClientID).Clients)
                lstNote = lstNote.Concat(db.GameHiveNotes.Where(gw => gw.HiveID == CorrelationId && gw.ClientID == c.ID)).ToList();

            var Note = lstNote.Concat(db.GameHiveNotes.Where(gw => gw.HiveID == CorrelationId && gw.ClientID == ClientID));

            //var Note = db.GameHiveNotes.Where(gw => gw.HiveID == CorrelationId && gw.ClientID == ClientID);
            if (Note == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Note
                .Select(on => new { on.SportID, on.Header, on.NoteColor, on.TeamID, on.ID, on.Note, on.UserID, on.LastUpdated, on.HiveID, on.SortOrder, on.ClientID }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                .AsEnumerable()
                .OrderBy(s => s.SortOrder)
                .ToDataSourceResult(request, (n => new
                {
                    // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                    //n.Group,
                    //Game = db.Games.Where(g => g.ID == n.GameID).First(),
                    n.HiveID,
                    n.ClientID,
                    n.Header,
                    n.ID,
                    n.Note,
                    n.LastUpdated,
                    n.SportID,
                    //LastUpdatedBy = (n.UserID != null && n.UserID != 0 ? " last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated.ToString() : n.Note),
                    NoteColor = n.NoteColor,//Utilities.ConvertToHTML(n.NoteColor),
                    n.SortOrder,
                    n.TeamID,
                    n.UserID
                }));
        }


        // PUT api/Note/5
        public HttpResponseMessage PutGameHiveNote(GameHiveNote note)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(Note).State = EntityState.Modified;

                //note.GroupReference.Attach(db.Groups.Where(gw => gw.ID == note.GroupID).First());
                //note.GroupReference.Load();
                //db.GameHiveNotes.Attach(note);
                //note.GroupReference.Load();

                //Note existingNote = db.GameHiveNotes.Find(note.ID);

                GameHiveNote existingNote = db.GameHiveNotes.Single(nw => nw.ID == note.ID);

                //updare sort order
                if(existingNote.SortOrder != note.SortOrder)
                    PutGameHiveNote(note.ID, note.HiveID, "GameHiveNote", Convert.ToInt32( note.SortOrder)); //new sort order

                //1st remove html tags for plain note, then convert to vz format
               
                note.NoteColor = HttpUtility.UrlDecode(note.NoteColor);
                note.NoteColor = WebUtility.HtmlDecode(note.NoteColor);

                note.Note = WebUtility.HtmlDecode(note.NoteColor);
                note.NoteColor = Utilities.ConvertFromHTML(note.NoteColor);
                existingNote.Header = note.Header;

                
                existingNote.NoteColor = note.NoteColor;
                existingNote.Note = note.Note;

                if (note.TeamID > 0)
                {
                 //   note.SportID = db.Teams.Where(t => t.ID == note.TeamID).SingleOrDefault().SportID;
                    existingNote.SportID = note.SportID;
                   // existingNote.LeagueCode = db.Sports.Where(t => t.ID == note.SportID).SingleOrDefault().ShortDisplay;
                    existingNote.LeagueCode = note.LeagueCode;
                    existingNote.TeamID = note.TeamID;
                 //   existingNote.TeamCode = db.Teams.Where(t => t.ID == note.TeamID).SingleOrDefault().Abbreviation;
                    existingNote.TeamCode = note.TeamCode;
                }
                else
                {
                    
                    existingNote.SportID = null;
                    existingNote.LeagueCode = null;
                    existingNote.TeamID = note.TeamID;
                    existingNote.TeamCode = null;

                }
                existingNote.LastUpdated = DateTime.Now;
                existingNote.SortOrder = note.SortOrder;


                //db.ApplyCurrentValues("GameHiveNotes",note);

                //db.ObjectStateManager.ChangeObjectState(note, EntityState.Modified);

                //clean
                existingNote.Note = Regex.Replace(existingNote.Note, @"[^\u0000-\u02FF]", string.Empty);
                existingNote.NoteColor = Regex.Replace(existingNote.NoteColor, @"[^\u0000-\u02FF]", string.Empty);

                existingNote.Note = existingNote.Note.Replace((char)0xA0, ' ');
                existingNote.NoteColor = existingNote.NoteColor.Replace((char)0xA0, ' ');

                //existingNote.NoteColor = Regex.Replace(existingNote.NoteColor, @"<.*?>", string.Empty);
                existingNote.Note = Regex.Replace(existingNote.Note, @"<[^>]*>", string.Empty);
                existingNote.NoteColor = Regex.Replace(existingNote.NoteColor, @"<[^>]*>", string.Empty);

             //   existingNote.Note = Regex.Replace(existingNote.Note, @"\&.*?;", string.Empty);
            //    existingNote.NoteColor = Regex.Replace(existingNote.NoteColor, @"\&.*?;", string.Empty);

                

                try
                {
                    db.SaveChanges();
                    
                    ReSortNotes(note);
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
        public HttpResponseMessage PutGameHiveNote(int id, string ParentID, string ObjectType, int SortOrder) //new sort order
        {
            GameHiveNote Note = db.GameHiveNotes.Where(le => le.ID == id).Single();
            int newRank = SortOrder;
            int? oldRank = Note.SortOrder;

            if (newRank > oldRank) newRank++;

            switch (ObjectType)
            {
                case "GameHiveNote":
                    List<GameHiveNote> lgameGameHiveNotes = new List<GameHiveNote>();
                    lgameGameHiveNotes.AddRange(db.GameHiveNotes.Where(le => le.HiveID == ParentID && le.SortOrder < newRank && le.ID != id).OrderBy(ob => ob.SortOrder).ToList());
                    lgameGameHiveNotes.Add(db.GameHiveNotes.Where(le => le.ID == id).Single());
                    foreach (GameHiveNote l in db.GameHiveNotes.Where(le => le.HiveID == ParentID).OrderBy(ob => ob.SortOrder))
                        if (lgameGameHiveNotes.Where(le => le.ID == l.ID).Count() == 0)
                            lgameGameHiveNotes.Add(l);

                    for (int i = 0; i < lgameGameHiveNotes.Count; i++)
                        lgameGameHiveNotes[i].SortOrder = i + 1;

                    lgameGameHiveNotes.ForEach(ln => ln.LastUpdated = DateTime.Now);
                    break;
            }
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
        //public HttpResponseMessage PutNote(int id, Note note)
        //{
        //    if (ModelState.IsValid && id == note.ID)
        //    {
        //        db.Entry(note).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound);
        //        }

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

  // POST api/Note
        public HttpResponseMessage PostGameHiveNote(GameHiveNote note)
        {
            if (ModelState.IsValid)
            {
                //note.Group = db.Groups.Single(gw => gw.ID == note.GroupID);
               // note.NoteColor = HttpUtility.UrlDecode(note.NoteColor);


                note.NoteColor = HttpUtility.UrlDecode(note.NoteColor);
                note.NoteColor = WebUtility.HtmlDecode(note.NoteColor);


                note.Note = WebUtility.HtmlDecode(note.NoteColor);
                note.NoteColor = Utilities.ConvertFromHTML(note.NoteColor);
                note.LastUpdated = DateTime.Now;
                //note.GroupReference.Attach(db.Groups.Where(gw => gw.ID == note.GroupID).First());
                //note.GroupReference.Load();
                //note.Game = db.Games.Where(gw => gw.ID == note.GameID).First();
                note.SortOrder = note.SortOrder;
               // note.SportID = db.Teams.Where(t => t.ID == note.TeamID).SingleOrDefault().SportID;

                if (note.TeamID != null && note.TeamID > 0)
                {
                    //note.SportID = db.Teams.Where(t => t.ID == note.TeamID).SingleOrDefault().SportID;
                   // note.LeagueCode = db.Sports.Where(t => t.ID == note.SportID).SingleOrDefault().ShortDisplay;
                 //   note.TeamCode = db.Teams.Where(t => t.ID == note.TeamID).SingleOrDefault().Abbreviation;

                    //Task<int> TeamID = Topic(note.TeamCode, note.LeagueCode);

                    //int SDMteamid = Convert.ToInt32(TeamID.Result);
                    //note.TeamID = SDMteamid;
                }
                else
                {
                    note.TeamCode = null;
                    note.LeagueCode = null;

                }
                db.GameHiveNotes.AddObject(note);
                ReSortNotes(note);

                //note.Note1 = WebUtility.HtmlDecode(note.NoteColor);

                //db.Refresh(System.Data.Objects.RefreshMode.StoreWins, db.GameHiveNotes);

                //clean
                note.Note = Regex.Replace(note.Note, @"[^\u0000-\u02FF]", string.Empty);
                note.NoteColor = Regex.Replace(note.NoteColor, @"[^\u0000-\u02FF]", string.Empty);

                note.Note = note.Note.Replace((char)0xA0, ' ');
                note.NoteColor = note.NoteColor.Replace((char)0xA0, ' ');

                note.Note = Regex.Replace(note.Note, @"<[^>]*>", string.Empty);
                note.NoteColor = Regex.Replace(note.NoteColor, @"<[^>]*>", string.Empty);

           //     note.Note = Regex.Replace(note.Note, @"\&.*?;", string.Empty);
             //   note.NoteColor = Regex.Replace(note.NoteColor, @"\&.*?;", string.Empty);



                note.NoteColor = note.NoteColor;//.ConvertToHTML(note.NoteColor);

                

                

                dynamic resp = new
                {
                    note.HiveID,
                    note.ClientID,
                    note.Header,
                    note.ID,
                    note.LastUpdated,
                    note.SportID,
                    Note1 = note.Note + (note.UserID != null && note.UserID != 0 ? " last updated by " + db.Users.Where(u => u.UserID == note.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == note.UserID).FirstOrDefault().LastName + ", " + note.LastUpdated.ToString() : note.Note),
                    NoteColor = note.NoteColor,//Utilities.ConvertToHTML(note.NoteColor),
                    note.SortOrder,
                    note.TeamID,
                    note.UserID
                };
                var correctedResponse = new { Data = new[] { resp } };
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, correctedResponse);
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, note);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = note.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        private void ReSortNotes(GameHiveNote note)
        {

            List<GameHiveNote> lnotes = db.GameHiveNotes.Where(n => n.HiveID == note.HiveID).OrderBy(o => o.SortOrder).ToList();
            for (int i = 0; i < lnotes.Count; i++)
                lnotes[i].SortOrder = i + 1;

            lnotes.ForEach(ln => ln.LastUpdated = DateTime.Now);

            db.SaveChanges();
        }

        // DELETE api/Note/5
        public HttpResponseMessage DeleteGameHiveNote(int id)
        {
            GameHiveNote note = db.GameHiveNotes.Where(nw => nw.ID == id).FirstOrDefault();
            if (note == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GameHiveNotes.DeleteObject(note);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, note);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}