using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Ticker.Data;
using System.Web;
using System.Net.Http;

namespace Ticker.Controllers
{
    public class ClientController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Client
        //public IEnumerable<Client> GetClients()
        public DataSourceResult GetClients([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            return db.Clients.OrderBy(cob => cob.Description).ToDataSourceResult(request, c => new { c.ID, c.Abbreviation, c.Description, c.LockClient, c.SponsorSync, c.DataHiveEnabled});//, hasChildren = c.ClientsTo.Any() });
        }

        // GET api/Client/5
        public Client GetClient(byte id)
        {
            Client client = db.Clients.Single(c => c.ID == id);
            if (client == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return client;
        }
        // GET api/Client/0?username=foo
        public IEnumerable<Client> GetClient(byte id, string username)
        {
            var userClients = db.spTICK_Users_Get(username).Select(c => c.ClientID).ToArray();
            var clients = db.Clients.Where(p => userClients.Contains(p.ID));

            return clients.OrderBy(d => d.Description);
        }

        // GET api/Client/0?username=foo
        public IEnumerable<Client> GetClient(byte id, string username, bool forAdmin)
        {
            var userClients = db.spTICK_Users_Get(username).Where(u => u.Admin == true).Select(c => c.ClientID).ToArray();
            var clients = db.Clients.Where(p => userClients.Contains(p.ID));

            return clients.OrderBy(d => d.Description);
        }

        // PUT api/Client/5
        public HttpResponseMessage PutClient(byte id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != client.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Clients.Attach(client);
            db.ObjectStateManager.ChangeObjectState(client, EntityState.Modified);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Client
        public HttpResponseMessage PostClient(Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.AddObject(client);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, client);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = client.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Client/5
        public HttpResponseMessage DeleteClient(byte id)
        {
            Client client = db.Clients.Single(c => c.ID == id);
            if (client == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Clients.DeleteObject(client);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, client);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}