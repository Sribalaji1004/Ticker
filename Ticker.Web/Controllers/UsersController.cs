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
    public class UsersController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Users
        public IEnumerable<User> GetUsers()
        {
            return db.Users.AsEnumerable();
        }

        // GET api/Users/5
        public User GetUser(int id)
        {
            User user = db.Users.Single(u => u.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return user;
        }
        public User GetUser(string username, int clientID)
        {
            User user = db.Users.Single(u => u.Username == username && u.ClientID == clientID);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return user;
        }

        public DataSourceResult GetUser([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request, int id, int clientID)
        {
            //Playlist Playlist = db.Playlists.Find(id);
            var User = db.Users.Where(gw => gw.ClientID == clientID);
            if (User == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            // User.ToList().ForEach(a => a.PlaylistDetails.Load());

            return User.AsEnumerable().OrderBy(o => o.Username).ToDataSourceResult(request, p =>
                new
                {
                    p.UserID,
                    p.Username,
                    p.FirstName,
                    p.LastName,
                    p.ClientID,
                    p.Admin,
                    p.Inactive,
                    // hasChildren = p.PlaylistDetails.Any()// .Select(pd => new { ID = pd.ID, Name = pd.OnAirName }).Any()
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

        // PUT api/Users/5
        public HttpResponseMessage PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != user.UserID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            User existingUser = db.Users.Single(u => u.UserID == id);

            string admin = existingUser.Admin == true ? "true" : "false";
            string newAdmin = user.Admin == true ? "true" : "false";
            string clientName = db.Clients.Single(c => c.ID == user.ClientID).Abbreviation;
            string msg = "Updated user in \"" + clientName + "\"<br />(Existing) Username: \"" + existingUser.Username + "\" - First Name: \"" + existingUser.FirstName + "\" - Last Name: \"" +
                existingUser.LastName + "\" - Admin: " + admin + "<br />(Updated) Username: \"" + user.Username + "\" - First Name: \"" + user.FirstName + "\" - Last Name: \"" +
                user.LastName + "\" - Admin: \"" + newAdmin + "\"";

            existingUser.Username = user.Username;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Admin = user.Admin;
            /**
            db.Users.Attach(user);
            db.ObjectStateManager.ChangeObjectState(user, EntityState.Modified);
            **/

            try
            {
                db.SaveChanges();

                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(User), Utilities.Action_Flag.CHANGE, user.UserID.ToString(), user.Username, msg, true);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

            /*if (ModelState.IsValid && id == user.UserID)
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
            }*/
        }

        public HttpResponseMessage PutUser(int id, bool Inactive)
        {
            //User user = db.Users.Single(u => u.UserID == id);
            //if (user == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}

            //user.Inactive = !user.Inactive;
            ////db.Users.DeleteObject(user);

            //db.Users.Where(usr => usr.Username == db.Users.FirstOrDefault(u => u.UserID == id).Username).ToList().ForEach(ui => ui.Inactive = !ui.Inactive);
            db.Users.Single(u => u.UserID == id).Inactive = Inactive;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);//, user);
        }
        public HttpResponseMessage PutUser(int id, string ToggleField, bool State)
        {
            //User user = db.Users.Single(u => u.UserID == id);
            //if (user == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}

            //user.Inactive = !user.Inactive;
            ////db.Users.DeleteObject(user);

            //db.Users.Where(usr => usr.Username == db.Users.FirstOrDefault(u => u.UserID == id).Username).ToList().ForEach(ui => ui.Inactive = !ui.Inactive);
            switch (ToggleField)
            {
                case "Admin":
                    db.Users.Single(u => u.UserID == id).Admin = State;
                    break;
                case "Inactive":
                    db.Users.Single(u => u.UserID == id).Inactive = State;
                    break;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);//, user);
        }


        // POST api/Users
        public HttpResponseMessage PostUser(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.AddObject(user);
                db.SaveChanges();

                string clientName = db.Clients.Single(c => c.ID == user.ClientID).Abbreviation;
                string admin = user.Admin == true ? "true" : "false";
                string msg = "Added user to \"" + clientName + "\"<br />Username: \"" + user.Username + "\" - First Name: \"" + user.FirstName +
                    "\" - Last Name: \"" + user.LastName + "\" - Admin: \"" + admin + "\"";
                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(User), Utilities.Action_Flag.ADDITION, user.UserID.ToString(), user.Username, msg, true);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.UserID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Users/5
        public HttpResponseMessage DeleteUser(int id)
        {
            //User user = db.Users.Single(u => u.UserID == id);
            //if (user == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}

            //user.Inactive = !user.Inactive;
            ////db.Users.DeleteObject(user);

            //db.Users.Where(usr => usr.Username == db.Users.FirstOrDefault(u => u.UserID == id).Username).ToList().ForEach(ui => ui.Inactive = !ui.Inactive);
            User user = db.Users.Single(u => u.UserID == id);
            user.Inactive = true;

            try
            {
                db.SaveChanges();

                string clientName = db.Clients.Single(c => c.ID == user.ClientID).Abbreviation;
                string msg = "Deleted user from \"" + clientName + "\"<br />Username: \"" + user.Username + "\" - First Name: \"" + user.FirstName +
                    "\" - Last Name: \"" + user.LastName + "\" - Admin: \"" + user.Admin + "\"";
                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(User), Utilities.Action_Flag.DELETION, id.ToString(), user.Username, msg, true);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);//, user);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}