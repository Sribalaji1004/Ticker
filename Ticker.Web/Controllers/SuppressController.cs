using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Ticker.Data;

namespace Ticker.Controllers
{
       public class suppressgames
    {
        public int id { get; set; }
        public string LeagueCode { get; set; }
        public int ClientID { get; set; }
        public int CorrelationID { get; set; }
    }
    public class SuppressController : ApiController
    {
        // GET: api/Suppress
        public IHttpActionResult Get(string corid,string leaguecode, int clietid)
        {
            FoxTickerEntities db = new FoxTickerEntities();
            bool status = false;
            if (db.suppressgames.Where(a => a.CorrelationID == corid && a.ClientID == clietid && a.LeagueCode == leaguecode).Any())
            {
                status = true;

            }
            return Json(status);

        }


        //public DataSourceResult Get(string id, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        //{
        //    var suppress = db.suppressgames.Where(gw => gw.CorrelationID == id);
        //    if (suppress == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return suppress.AsEnumerable().ToDataSourceResult(request, g => new
        //    {
        //        g.id,
        //        g.LeagueCode,
        //        g.ClientID,
        //        g.CorrelationID
        //    }); ;
        //}

        // GET: api/Suppress/5
        //public IHttpActionResult Get(string correlationid)
        //{
        //    FoxTickerEntities db = new FoxTickerEntities();
        //    bool status = false;
        //    if(db.suppressgames.Where(a=>a.CorrelationID== correlationid).Any())
        //    {
        //        status = true;
                    
        //    }
        //    return Json(status);
        //}

        // POST: api/Suppress
        public HttpResponseMessage Post(string id, string league, int client)
        {
            FoxTickerEntities db = new FoxTickerEntities();

            // suppressgame Suppress = db.suppressgames.Where(a => a.CorrelationID == id && a.ClientID == client && a.LeagueCode == league).FirstOrDefault();

            suppressgame suppress = new suppressgame();
            suppress.ClientID = client;
            suppress.CorrelationID = id;
            suppress.LeagueCode = league;


            db.suppressgames.AddObject(suppress);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, suppress);
        }

        // PUT: api/Suppress/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Suppress/5
        public HttpResponseMessage Delete(string id, string league, int client)
        {
            FoxTickerEntities db = new FoxTickerEntities();
            
            suppressgame Suppress = db.suppressgames.Where(a => a.CorrelationID == id && a.ClientID == client && a.LeagueCode == league).FirstOrDefault();
            if (Suppress == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.suppressgames.DeleteObject(Suppress);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Suppress);
        }
    }
}
