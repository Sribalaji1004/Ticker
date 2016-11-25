using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ticker.Data;

namespace Ticker.Controllers
{
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
        public IHttpActionResult Post(string correlationid)
        {
            FoxTickerEntities db = new FoxTickerEntities();
            bool status = false;
            if (db.suppressgames.Where(a => a.CorrelationID == correlationid).Any())
            {
                status = true;

            }
            return Json(status);
        }

        // PUT: api/Suppress/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Suppress/5
        public void Delete(int id)
        {
        }
    }
}
