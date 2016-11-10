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

namespace Ticker.Controllers
{
    public class GameNoteController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        private GameNoteController()
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
        public DataSourceResult GetGameNotes([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //return db.GameNotes.AsEnumerable();
            //return LazyReload(db.GameNotes.AsEnumerable()).ToDataSourceResult(request, n => new
            //return db.GameNotes.Include("Group").AsEnumerable().ToDataSourceResult(request, n => new
            return db.GameNotes
                .Select(on => new { on.Header, on.Imported, on.NoteColor, on.TeamID, on.ID, on.Note, on.UserID, on.LastUpdated, on.GameID, on.SortOrder, on.ClientID }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                .AsEnumerable()
                .OrderBy(s => s.SortOrder)
                .ToDataSourceResult(request, n => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //n.Group,
                //Game = db.Games.Where(g => g.ID == n.GameID).First(),
                n.GameID,
                n.ClientID,
                n.Header,
                n.ID,
                n.Imported,
                n.LastUpdated,
                //LastUpdatedBy = (n.UserID != null && n.UserID != 0 ? " last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated.ToString() : n.Note),
                n.NoteColor,
                n.SortOrder,
                n.TeamID,
                n.UserID
            });

        }

        // GET api/Note/5
        //public Note GetNote(int id)
        public DataSourceResult GetGameNote(int id, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //Note Note = db.GameNotes.Find(id);
            //var Note = LazyReload(db.GameNotes.Where(gw => gw.ID == id));
            var Note = db.GameNotes.Where(gw => gw.GameID == id);
            if (Note == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Note
                .Select(on => new { on.Header, on.Imported, on.NoteColor, on.TeamID, on.ID, on.Note, on.UserID, on.LastUpdated, on.GameID, on.SortOrder, on.ClientID }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                .AsEnumerable()
                .OrderBy(s => s.SortOrder)
                .ToDataSourceResult(request, n => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //n.Group,
                //Game = db.Games.Where(g => g.ID == n.GameID).First(),
                n.GameID,
                n.ClientID,
                n.Header,
                n.ID,
                n.Imported,
                n.LastUpdated,
                //LastUpdatedBy = (n.UserID != null && n.UserID != 0 ? " last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated.ToString() : n.Note),
                NoteColor = Utilities.ConvertToHTML(n.NoteColor),
                n.SortOrder,
                n.TeamID,
                n.UserID
            });
        }

        // PUT api/Note/5
        public HttpResponseMessage PutGameNote(GameNote note)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(Note).State = EntityState.Modified;

                //note.GroupReference.Attach(db.Groups.Where(gw => gw.ID == note.GroupID).First());
                //note.GroupReference.Load();
                //db.GameNotes.Attach(note);
                //note.GroupReference.Load();

                //Note existingNote = db.GameNotes.Find(note.ID);
                GameNote existingNote = db.GameNotes.Single(nw => nw.ID == note.ID);
                string oldNote = existingNote.Note;
                
                bool reOrder=false;
                //1st remove html tags for plain note, then convert to vz format
                note.Note = Utilities.RemoveHTML(note.NoteColor);
                note.NoteColor = Utilities.ConvertFromHTML(note.NoteColor);
                existingNote.Header = note.Header;
                existingNote.NoteColor = note.NoteColor;
                existingNote.Note = note.Note;
                existingNote.TeamID = note.TeamID;

                bool first = false;

                if (existingNote.SortOrder != note.SortOrder)
                {
                    if (note.SortOrder == 0 || note.SortOrder == 1)
                        first = true;
                    reOrder = true;
                }

                existingNote.SortOrder = note.SortOrder;
                existingNote.LastUpdated = DateTime.Now;
                //db.ApplyCurrentValues("GameNotes",note);

                //db.ObjectStateManager.ChangeObjectState(note, EntityState.Modified);

                try
                {
                    db.SaveChanges();
                    Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(GameNote), Utilities.Action_Flag.CHANGE, note.ID.ToString(), note.Note, oldNote, true);

                    if (reOrder)
                    {

                        List<GameNote> lgameGameNotes = new List<GameNote>();
                        if (first)
                        {
                            lgameGameNotes.Add(existingNote);
                            lgameGameNotes.AddRange(db.GameNotes.Where(le => le.GameID == existingNote.GameID && le.ID !=existingNote.ID).OrderBy(ob => ob.SortOrder).ToList());
                        }
                        else
                            lgameGameNotes.AddRange(db.GameNotes.Where(le => le.GameID == existingNote.GameID).OrderBy(ob => ob.SortOrder).ToList());

                        for (int i = 0; i < lgameGameNotes.Count; i++)
                            lgameGameNotes[i].SortOrder = i + 1;

                        lgameGameNotes.ForEach(ln => ln.LastUpdated = DateTime.Now);
                        db.SaveChanges();
                    }
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
        public HttpResponseMessage PutGameNote(int id, int ParentID, string ObjectType, int SortOrder) //new sort order
        {
            GameNote Note = db.GameNotes.Where(le => le.ID == id).Single();
            int newRank = SortOrder;
            int? oldRank = Note.SortOrder;

            if (newRank > oldRank) newRank++;

            switch (ObjectType)
            {
                case "GameNote":
                    List<GameNote> lgameGameNotes = new List<GameNote>();
                    lgameGameNotes.AddRange(db.GameNotes.Where(le => le.GameID == ParentID && le.SortOrder < newRank && le.ID != id).OrderBy(ob => ob.SortOrder).ToList());
                    lgameGameNotes.Add(db.GameNotes.Where(le => le.ID == id).Single());
                    foreach (GameNote l in db.GameNotes.Where(le => le.GameID == ParentID).OrderBy(ob => ob.SortOrder))
                        if (lgameGameNotes.Where(le => le.ID == l.ID).Count() == 0)
                            lgameGameNotes.Add(l);

                    for (int i = 0; i < lgameGameNotes.Count; i++)
                        lgameGameNotes[i].SortOrder = i + 1;

                    lgameGameNotes.ForEach(ln => ln.LastUpdated = DateTime.Now);
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
        public HttpResponseMessage PostGameNote(GameNote note)
        {
            if (ModelState.IsValid)
            {
                //note.Group = db.Groups.Single(gw => gw.ID == note.GroupID);
                note.Note = Utilities.RemoveHTML(note.NoteColor);
                note.NoteColor = Utilities.ConvertFromHTML(note.NoteColor);
                note.LastUpdated = DateTime.Now;
                //note.GroupReference.Attach(db.Groups.Where(gw => gw.ID == note.GroupID).First());
                //note.GroupReference.Load();
                note.Game = db.Games.Where(gw => gw.ID == note.GameID).First();
                if (note.SortOrder != null)
                    note.SortOrder = note.SortOrder;
                else
                    note.SortOrder = 0;
                db.GameNotes.AddObject(note);

                List<GameNote> lnotes = db.GameNotes.Where(n => n.GameID == note.GameID).OrderBy(o => o.SortOrder).ToList();
                for (int i = 0; i < lnotes.Count; i++)
                    lnotes[i].SortOrder = i + 1;

                lnotes.ForEach(ln => ln.LastUpdated = DateTime.Now);

                db.SaveChanges();

                note.NoteColor = Utilities.ConvertToHTML(note.NoteColor);
                //note.Note1 = Utilities.RemoveHTML(note.NoteColor);

                //db.Refresh(System.Data.Objects.RefreshMode.StoreWins, db.GameNotes);



                dynamic resp = new
                {
                    note.GameID,
                    note.ClientID,
                    note.Header,
                    note.ID,
                    note.Imported,
                    note.LastUpdated,
                    Note1 = note.Note + (note.UserID != null && note.UserID != 0 ? " last updated by " + db.Users.Where(u => u.UserID == note.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == note.UserID).FirstOrDefault().LastName + ", " + note.LastUpdated.ToString() : note.Note),
                    NoteColor = Utilities.ConvertToHTML(note.NoteColor),
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

        // DELETE api/Note/5
        public HttpResponseMessage DeleteGameNote(int id)
        {
            GameNote note = db.GameNotes.Where(nw => nw.ID == id).FirstOrDefault();
            if (note == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.GameNotes.DeleteObject(note);

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