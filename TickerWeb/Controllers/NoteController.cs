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
            return db.Notes.AsEnumerable().ToDataSourceResult(request, n => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //n.Group,
                n.GroupID,
                n.Header,
                n.ID,
                n.Imported,
                n.LastUpdated,
                n.Note1,
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

            return Note.AsEnumerable().ToDataSourceResult(request, n => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //n.Group,
                n.GroupID,
                n.Header,
                n.ID,
                n.Imported,
                n.LastUpdated,
                n.Note1,
                n.NoteColor,
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
                //db.Entry(existingNote).CurrentValues.SetValues(note);
                Note existingNote = db.Notes.Single(nw => nw.ID == note.ID);
                db.ApplyCurrentValues("Notes",note);
                
                //db.ObjectStateManager.ChangeObjectState(note, EntityState.Modified);

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
                note.Group = db.Groups.Single(gw => gw.ID == note.GroupID);
                db.Notes.AddObject(note);
                db.SaveChanges();

                var correctedResponse = new { Data = new[] { note } };
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

            return Request.CreateResponse(HttpStatusCode.OK, note);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}