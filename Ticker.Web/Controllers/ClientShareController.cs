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
    public class ClientShareController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Client
        //public IEnumerable<Client> GetClients()
        public DataSourceResult GetClientShare([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            return db.Clients.OrderBy(cob => cob.Description).ToDataSourceResult(request, c => new { c.ID, c.Abbreviation, c.Description, c.LockClient, c.SponsorSync, c.DataHiveEnabled });//, hasChildren = c.ClientsTo.Any() });
        }

        // GET api/Client/5
        public DataSourceResult GetClientShare(byte id, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            db.Clients.Single(s => s.ID == id).ClientsTo.Load();
            List<Client> client = db.Clients.Single(c => c.ID == id).ClientsTo.ToList();
            if (client == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return client.ToDataSourceResult(request, c => new { c.ID, c.Description });
        }

        // POST api/Client
        public HttpResponseMessage PostClientShare(int id, Client client)
        {
            if (ModelState.IsValid)
            {
                Client clientShareTo = db.Clients.Single(c => c.ID == id);
                clientShareTo.ClientsTo.Add(db.Clients.Single(c => c.ID == client.ID));
                db.Clients.Attach(clientShareTo);
                db.ObjectStateManager.ChangeObjectState(clientShareTo, EntityState.Modified);
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
        public HttpResponseMessage DeleteClientShare(int id, int shareID)
        {
            Client clientShareTo = db.Clients.Single(c => c.ID == id);
            Client client = db.Clients.Single(c => c.ID == shareID);
                
            clientShareTo.ClientsTo.Load();
            clientShareTo.ClientsTo.Remove(client);
            db.ObjectStateManager.ChangeObjectState(clientShareTo, EntityState.Modified);

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