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
using System.Text;

namespace Ticker.Controllers
{
    public class NoteController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        private NoteController()
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
        public DataSourceResult GetNotes([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //return db.Notes.AsEnumerable();
            //return LazyReload(db.Notes.AsEnumerable()).ToDataSourceResult(request, n => new
            //return db.Notes.Include("Group").AsEnumerable().ToDataSourceResult(request, n => new
            return db.Notes
                .Select(on => new { on.Header, on.Imported, on.NoteColor, on.TeamID, on.ID, on.Note1, on.UserID, on.LastUpdated, on.GroupID, on.SortOrder }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                .AsEnumerable()
                .OrderBy(s => s.SortOrder)
                .ToDataSourceResult(request, n => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //n.Group,
                n.GroupID,
                n.Header,
                n.ID,
                n.Imported,
                n.LastUpdated,
                //LastUpdatedBy = (n.UserID != null && n.UserID != 0 && db.Users.Where(u => u.UserID == n.UserID).Count() != 0 ? " last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated.ToString() : n.Note1),
                n.NoteColor,
                n.SortOrder,
                n.TeamID,
                n.UserID
            });

        }

        // GET api/Note/5
        //public Note GetNote(int id)
        public DataSourceResult GetNote(int id, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //Note Note = db.Notes.Find(id);
            //var Note = LazyReload(db.Notes.Where(gw => gw.ID == id));
            var Note = db.Notes.Where(gw => gw.ID == id);
            if (Note == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Note
                .Select(on => new { on.Header, on.Imported, on.NoteColor, on.TeamID, on.ID, on.Note1, on.UserID, on.LastUpdated, on.GroupID, on.SortOrder }) //first trip is pure ef and can't convert dt to string (See also http://stackoverflow.com/questions/5370402/entity-framework-4-linq-how-to-convert-from-datetime-to-string-in-a-query)
                .AsEnumerable()
                .OrderBy(s => s.SortOrder)
                .ToDataSourceResult(request, n => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //n.Group,
                n.GroupID,
                n.Header,
                n.ID,
                n.Imported,
                n.LastUpdated,
                //LastUpdatedBy = (n.UserID != null && n.UserID != 0 && db.Users.Where(u => u.UserID == n.UserID).Count() != 0 ? " last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated.ToString() : n.Note1),
                NoteColor = Utilities.ConvertToHTML(n.NoteColor),
                n.SortOrder,
                n.TeamID,
                n.UserID
            });
        }

        // PUT api/Note/5
        public HttpResponseMessage PutNote(Note note)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(Note).State = EntityState.Modified;

                //note.GroupReference.Attach(db.Groups.Where(gw => gw.ID == note.GroupID).First());
                //note.GroupReference.Load();
                //db.Notes.Attach(note);
                //note.GroupReference.Load();

                //Note existingNote = db.Notes.Find(note.ID);

                Note existingNote = db.Notes.Single(nw => nw.ID == note.ID);

                if (note.TeamID == null)
                    note.TeamID = -1;
                string groupName = db.Groups.Single(g => g.ID == note.GroupID).Name;
                //************ Following lines were commented for SDM Integration  -- Start  *********************//
                //string oldTeam = existingNote.TeamID == null ? "" : existingNote.TeamID != -1 ? db.Teams.Single(t => t.ID == existingNote.TeamID).NickName : "";
                //string newTeam = note.TeamID != -1 ? db.Teams.Single(t => t.ID == note.TeamID).NickName : "";
                //************ Following lines were commented for SDM Integration  -- End  *********************//
                string oldTeam = "";
                string newTeam = "";

                string msg = "Updated Note in \"" + groupName + "\"<br />(Existing) Team: \"" + oldTeam + "\" - Header: \"" + existingNote.Header + "\" - Note: \"" + existingNote.Note1 +
                    "\"<br />(Updated) Team: \"" + newTeam + "\" - Header: \"" + note.Header + "\" - Note: \"" + note.Note1 + "\"";

                //1st remove html tags for plain note, then convert to vz format
                note.NoteColor = HttpUtility.UrlDecode(note.NoteColor);
                note.NoteColor = WebUtility.HtmlDecode(note.NoteColor);

                note.Note1 = WebUtility.HtmlDecode(note.NoteColor);
                note.NoteColor = Utilities.ConvertFromHTML(note.NoteColor);

               // note.Note1 = Utilities.RemoveHTML(System.Web.HttpUtility.HtmlDecode(note.NoteColor));
               // note.NoteColor = Utilities.ConvertFromHTML(System.Web.HttpUtility.HtmlDecode(note.NoteColor));

                //clean
                note.Note1 = Regex.Replace(note.Note1, @"[^\u0000-\u02FF]", string.Empty);
                note.NoteColor = Regex.Replace(note.NoteColor, @"[^\u0000-\u02FF]", string.Empty);

                note.Note1 = note.Note1.Replace((char)0xA0, ' ');
                note.NoteColor = note.NoteColor.Replace((char)0xA0, ' ');

                note.Note1 = Regex.Replace(note.Note1, @"<[^>]*>", string.Empty);
                note.NoteColor = Regex.Replace(note.NoteColor, @"<[^>]*>", string.Empty);

                //note.Note1 = Regex.Replace(note.Note1, @"\&[A-Za-z]*?;", string.Empty);
                //note.NoteColor = Regex.Replace(note.NoteColor, @"\&[A-Za-z]*?;", string.Empty);

                note.NoteColor = note.NoteColor.Replace("@@","<");
                note.NoteColor = note.NoteColor.Replace("##", ">");

                existingNote.Header = note.Header;
                existingNote.NoteColor = note.NoteColor;
                string oldNote = existingNote.Note1;
                existingNote.Note1 = note.Note1;
                existingNote.TeamID = note.TeamID;
                existingNote.LastUpdated = DateTime.Now;

                bool reOrder = false;
                bool first = false;
                if (existingNote.SortOrder != note.SortOrder)
                {
                    if (note.SortOrder == 0 || note.SortOrder == 1)
                        first = true;
                    existingNote.SortOrder = note.SortOrder;
                    reOrder = true;
                }

                //db.ApplyCurrentValues("Notes",note);

                //db.ObjectStateManager.ChangeObjectState(note, EntityState.Modified);

                 try
                {
                    db.SaveChanges();
                    Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Note), Utilities.Action_Flag.CHANGE, note.ID.ToString(), note.Note1, msg, true);

                    if (reOrder)
                    {
                        List<Note> lgameNotes = new List<Note>();
                        if (first)
                        {
                            lgameNotes.Add(existingNote);
                            lgameNotes.AddRange(db.Notes.Where(le => le.GroupID == existingNote.GroupID && le.ID!=existingNote.ID).OrderBy(ob => ob.SortOrder).ToList());
                        }
                        else
                        lgameNotes.AddRange(db.Notes.Where(le => le.GroupID == existingNote.GroupID).OrderBy(ob => ob.SortOrder).ToList());
                        for (int i = 0; i < lgameNotes.Count; i++)
                            lgameNotes[i].SortOrder = i + 1;

                        lgameNotes.ForEach(ln => ln.LastUpdated = DateTime.Now);
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

        public HttpResponseMessage PutNote(int id, int ParentID, string ObjectType, int SortOrder) //new sort order
        {
            int newRank = SortOrder;
            int? oldRank;

            switch (ObjectType)
            {
                case "GroupNote":
                    Note Note = db.Notes.Where(le => le.ID == id).Single();
                    oldRank = Note.SortOrder;
                    if (newRank > oldRank) newRank++;

                    List<Note> lnotes = new List<Note>();
                    lnotes.AddRange(db.Notes.Where(le => le.GroupID == ParentID && le.SortOrder < newRank && le.ID != id).OrderBy(ob => ob.SortOrder).ToList());
                    lnotes.Add(db.Notes.Where(le => le.ID == id).Single());
                    foreach (Note l in db.Notes.Where(le => le.GroupID == ParentID).OrderBy(ob => ob.SortOrder))
                        if (lnotes.Where(le => le.ID == l.ID).Count() == 0)
                            lnotes.Add(l);

                    for (int i = 0; i < lnotes.Count; i++)
                        lnotes[i].SortOrder = i + 1;

                    lnotes.ForEach(ln => ln.LastUpdated = DateTime.Now);

                    Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Note), Utilities.Action_Flag.CHANGE, Note.ID.ToString(), Note.Note1, "Updated Note \"" + Note.Note1 + "\"", true);
                    break;
                case "GameNote":
                    GameNote gameNote = db.GameNotes.Where(le => le.ID == id).Single();
                    oldRank = gameNote.SortOrder;
                    if (newRank > oldRank) newRank++;

                    List<GameNote> lgamenotes = new List<GameNote>();
                    lgamenotes.AddRange(db.GameNotes.Where(le => le.GameID == ParentID && le.SortOrder < newRank && le.ID != id).OrderBy(ob => ob.SortOrder).ToList());
                    lgamenotes.Add(db.GameNotes.Where(le => le.ID == id).Single());
                    foreach (GameNote l in db.GameNotes.Where(le => le.GameID == ParentID).OrderBy(ob => ob.SortOrder))
                        if (lgamenotes.Where(le => le.ID == l.ID).Count() == 0)
                            lgamenotes.Add(l);

                    for (int i = 0; i < lgamenotes.Count; i++)
                        lgamenotes[i].SortOrder = i + 1;

                    lgamenotes.ForEach(ln => ln.LastUpdated = DateTime.Now);

                    Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Note), Utilities.Action_Flag.CHANGE, gameNote.ID.ToString(), gameNote.Note, "Added Note \"" + gameNote.Note + "\"", true);
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
        public HttpResponseMessage PostNote(Note note)
        {
            if (ModelState.IsValid)
            {
                //note.Group = db.Groups.Single(gw => gw.ID == note.GroupID);

                note.NoteColor = HttpUtility.UrlDecode(note.NoteColor);
                note.NoteColor = WebUtility.HtmlDecode(note.NoteColor);

                note.Note1 = WebUtility.HtmlDecode(note.NoteColor);
                note.NoteColor = Utilities.ConvertFromHTML(note.NoteColor);

               // note.Note1 = Utilities.RemoveHTML(System.Web.HttpUtility.HtmlDecode(note.NoteColor));
              //  note.NoteColor = Utilities.ConvertFromHTML(System.Web.HttpUtility.HtmlDecode(note.NoteColor));
                note.LastUpdated = DateTime.Now;
                //note.GroupReference.Attach(db.Groups.Where(gw => gw.ID == note.GroupID).First());
                //note.GroupReference.Load();
                note.Group = db.Groups.Where(gw => gw.ID == note.GroupID).First();
                if (note.SortOrder != null)
                    note.SortOrder = note.SortOrder;
                else
                note.SortOrder = 0;
                db.Notes.AddObject(note);

                List<Note> lnotes = db.Notes.Where(n => n.GroupID == note.GroupID).OrderBy(o => o.SortOrder).ToList();
                for (int i = 0; i < lnotes.Count; i++)
                {
                    if (lnotes[i].SortOrder >= note.SortOrder)
                    {
                        lnotes[i].SortOrder = lnotes[i].SortOrder + 1;
                    }
                    db.SaveChanges();

                        //for (int j = 0; j < lnotes.Count;j++)
                        //{
                        //    if (lnotes[j].SortOrder > note.SortOrder)
                        //    {
                        //        lnotes[j].SortOrder = lnotes[j].SortOrder+1;
                        //    }
                        //}
                            
                    }
                    

                lnotes.ForEach(ln => ln.LastUpdated = DateTime.Now);

            
                //clean
                note.Note1 = Regex.Replace(note.Note1, @"[^\u0000-\u02FF]", string.Empty);
                note.NoteColor = Regex.Replace(note.NoteColor, @"[^\u0000-\u02FF]", string.Empty);

                note.Note1 = note.Note1.Replace((char)0xA0, ' ');
                note.NoteColor = note.NoteColor.Replace((char)0xA0, ' ');

                note.Note1 = Regex.Replace(note.Note1, @"<[^>]*>", string.Empty);
                note.NoteColor = Regex.Replace(note.NoteColor, @"<[^>]*>", string.Empty);

                //note.Note1 = Regex.Replace(note.Note1, @"\&[A-Za-z]*?;", string.Empty);
                //note.NoteColor = Regex.Replace(note.NoteColor, @"\&[A-Za-z]*?;", string.Empty);

                note.NoteColor = note.NoteColor.Replace("@@", "<");
                note.NoteColor = note.NoteColor.Replace("##", ">");

                db.SaveChanges();

                //note.NoteColor = Utilities.ConvertToHTML(note.NoteColor);

                //note.Note1 = Utilities.RemoveHTML(note.NoteColor);

                //db.Refresh(System.Data.Objects.RefreshMode.StoreWins, db.Notes);

                dynamic resp = new
                {
                    note.GroupID,
                    note.Header,
                    note.ID,
                    note.Imported,
                    note.LastUpdated,
                    //Note1 = note.Note1 + (note.UserID != null && note.UserID != 0 && db.Users.Where(u => u.UserID == note.UserID).Count() != 0 ? " last updated by " + db.Users.Where(u => u.UserID == note.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == note.UserID).FirstOrDefault().LastName + ", " + note.LastUpdated.ToString() : note.Note1),
                    note.Note1,
                    NoteColor = Utilities.ConvertToHTML(note.NoteColor),
                    note.SortOrder,
                    note.TeamID,
                    note.UserID
                };

                if (note.SortOrder == note.SortOrder) {
                    note.SortOrder = note.SortOrder + 1;
                }
                if (note.TeamID == null)
                    note.TeamID = -1;
                string groupName = db.Groups.Single(g => g.ID == note.GroupID).Name;
                //************ Following line were commented for SDM Integration  -- Start  *********************//
               // string team = note.TeamID != -1 ? db.Teams.Single(t => t.ID == note.TeamID).NickName : "";
                //************ Following line were commented for SDM Integration  -- End  *********************//
                string team = "";
                string msg = "Added Note to \"" + groupName + "\"<br />Team: \"" + team + "\" - Header: \"" + note.Header + "\" - Note: \"" + note.Note1 + "\"";

                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Note), Utilities.Action_Flag.ADDITION, note.ID.ToString(), note.Note1, msg, true);

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
        public HttpResponseMessage DeleteNote(int id)
        {
            Note note = db.Notes.Where(nw => nw.ID == id).FirstOrDefault();
            if (note == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Notes.DeleteObject(note);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            string groupName = db.Groups.Single(g => g.ID == note.GroupID).Name;

            if (note.TeamID == null)
                note.TeamID = -1;
            //************ Following lines were commented for SDM Integration  -- Start  *********************//
            //string team = note.TeamID != -1 ? db.Teams.Single(t => t.ID == note.TeamID).NickName : "";
            //************ Following lines were commented for SDM Integration  -- End  *********************//
            string team = "";
            string msg = "Deleted Note from \"" + groupName + "\"<br />Team: \"" + team + "\" - Header: \"" + note.Header + "\" - Note: \"" + note.Note1 + "\"";

            Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Note), Utilities.Action_Flag.DELETION, note.ID.ToString(), note.Note1, msg, true);

            return Request.CreateResponse(HttpStatusCode.OK, note);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}