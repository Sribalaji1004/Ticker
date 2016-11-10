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
using Ticker.Data;

namespace Ticker.Controllers
{
    public class Default1Controller : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Default1
        public IEnumerable<Note> GetNotes()
        {
            var notes = db.Notes.Include("Group");
            return notes.AsEnumerable();
        }

        // GET api/Default1/5
        public Note GetNote(int id)
        {
            Note note = db.Notes.Single(n => n.ID == id);
            if (note == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return note;
        }

        // PUT api/Default1/5
        public HttpResponseMessage PutNote(int id, Note note)
        {
            if (ModelState.IsValid && id == note.ID)
            {
                db.Notes.Attach(note);
                db.ObjectStateManager.ChangeObjectState(note, EntityState.Modified);

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

        // POST api/Default1
        public HttpResponseMessage PostNote(Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.AddObject(note);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, note);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = note.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Default1/5
        public HttpResponseMessage DeleteNote(int id)
        {
            Note note = db.Notes.Single(n => n.ID == id);
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