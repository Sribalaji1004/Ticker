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
    public class GroupController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Group
        public IEnumerable<Group> GetGroups()
        {
            return db.Groups.AsEnumerable();
        }

        // GET api/Group/5
        public Group GetGroup(int id)
        {
            Group group = db.Groups.Single(g => g.ID == id);
            if (group == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return group;
        }

        // GET api/Group/5?GetType=-1
        public IEnumerable<dynamic> GetGroup(int id, bool GetType)
        {
            //return db.spTICK_GroupTypes_Get(id).Select(t => new { Type = (t == null ? "NULL" : t) }).AsEnumerable(); //reshape output from sproc as comes out generic w/out col names
            return db.spTICK_GroupTypes_Get(id).Where(w => w != null).Select(t => new { Type = t }).AsEnumerable(); //reshape output from sproc as comes out generic w/out col names
        }

        // GET api/Group/5?Type=News%20Feed
        public IEnumerable<spTICK_Group_GetByType_Result> GetGroup(int id, string Type)
        {
            return db.spTICK_Group_GetByType(id, Type);//.Select(t => new { Type = t }).AsEnumerable(); //reshape output from sproc as comes out generic w/out col names
        }

        // PUT api/Group/5
        public HttpResponseMessage PutGroup(int id, Group group)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != group.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (group.TeamID == 0)
                group.TeamID = null;

            string name = group.Name;
            db.Groups.Attach(group);
            db.ObjectStateManager.ChangeObjectState(group, EntityState.Modified);

            try
            {
                db.SaveChanges();
                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Group), Utilities.Action_Flag.CHANGE, group.ID.ToString(), group.Name, "Updated Group Name from \"" + name + "\"", true);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Group
        public HttpResponseMessage PostGroup(Group group)
        {
            if (ModelState.IsValid)
            {
                if (group.CreatedName == null)
                    group.CreatedName = group.Name;
                //if (group.TeamID == 0)
                //    group.TeamID = -1;

                db.Groups.AddObject(group);
                db.SaveChanges();

                string msg = "Created Group \"" + group.Name + "\"";
                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Group), Utilities.Action_Flag.ADDITION, group.ID.ToString(), group.Name, msg, true);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, group);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = group.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Group/5
        public HttpResponseMessage DeleteGroup(int id)
        {
            Group group = db.Groups.Single(g => g.ID == id);
            group.Notes.Load();
            group.Notes.ToList().ForEach(n => db.Notes.DeleteObject(n));
            group.GroupGames.Load();
            group.GroupGames.ToList().ForEach(n => db.GroupGames.DeleteObject(n));
            db.PlaylistDetails.Where(pld => pld.EntryID == id && pld.EntryTypeID == (int)Ticker.Data.Enums.EntryType.Group).ToList().ForEach(p => db.PlaylistDetails.DeleteObject(p));
            
            if (group == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            string name = group.Name;
            db.Groups.DeleteObject(group);

            try
            {
                db.SaveChanges();
                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Group), Utilities.Action_Flag.DELETION, id.ToString(), name, "Deleted Group \"" + name + "\"", true);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, group);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}