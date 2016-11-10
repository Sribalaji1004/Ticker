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
    public class spTICK_Playlist_Details_Get_ResultController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/spTICK_Playlist_Details_Get_Result
        //public IEnumerable<spTICK_Playlist_Details_Get_Result> GetspTICK_Playlist_Details_Get_Results()
        //public DataSourceResult GetspTICK_Playlist_Details_Get_Results([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        //{
        //    //return db.spTICK_Playlist_Details_Get_Results.AsEnumerable();
        //    //return db.spTICK_Playlist_Details_Get_Results.Where(gw => gw.ClientID == 1).AsEnumerable().ToDataSourceResult(request, g => new
        //    return db.spTICK_Playlist_Details_Get(playlistID).OrderBy(pldo => pldo.SortOrder).AsEnumerable().ToDataSourceResult(request, g => new
        //    {
        //        // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
        //        g.ID,
        //        g.OnAirName,
        //        g.EntryTypeID,
        //        g.EntryID,
        //        g.PlaylistID,
        //        g.SortOrder
        //    });

        //}

        // GET api/spTICK_Playlist_Details_Get_Result/5
        //public spTICK_Playlist_Details_Get_Result GetspTICK_Playlist_Details_Get_Result(int id)
        public IEnumerable<dynamic> GetspTICK_Playlist_Details_Get_Result(int id)
        {
            //spTICK_Playlist_Details_Get_Result spTICK_Playlist_Details_Get_Result = db.spTICK_Playlist_Details_Get_Results.Find(id);
            var spTICK_Playlist_Details_Get_Result = db.spTICK_Playlist_Details_Get(id).OrderBy(pldo => pldo.SortOrder);
            if (spTICK_Playlist_Details_Get_Result == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return spTICK_Playlist_Details_Get_Result.Select(g => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                g.EntryID,
                g.OnAirName,
                g.EntryTypeID,
                g.Header,
                g.PlaylistID,
                g.SortOrder,
                g.Name,
                g.SportDescription,
                g.SportID,
                g.SportShortDisplay,
                g.SportType,
                g.TeamCityName,
                g.TeamID,
                g.TeamNickName,
                g.TeamPrimaryColor,
                g.TeamSecondaryColor,
                g.Type
                ,hasChildren=true 
            }); ;
        }

        //// PUT api/spTICK_Playlist_Details_Get_Result/5
        //public HttpResponseMessage PutspTICK_Playlist_Details_Get_Result(int id, spTICK_Playlist_Details_Get_Result spTICK_Playlist_Details_Get_Result)
        //{
        //    if (ModelState.IsValid && id == spTICK_Playlist_Details_Get_Result.ID)
        //    {
        //        //db.Entry(spTICK_Playlist_Details_Get_Result).State = EntityState.Modified;

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

        //// POST api/spTICK_Playlist_Details_Get_Result
        //public HttpResponseMessage PostspTICK_Playlist_Details_Get_Result(spTICK_Playlist_Details_Get_Result spTICK_Playlist_Details_Get_Result)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.spTICK_Playlist_Details_Get_Results.AddObject(spTICK_Playlist_Details_Get_Result);
        //        db.SaveChanges();

        //        var correctedResponse = new { Data = new[] { spTICK_Playlist_Details_Get_Result } };
        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, correctedResponse);

        //        //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, spTICK_Playlist_Details_Get_Result);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = spTICK_Playlist_Details_Get_Result.ID }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}

        //// DELETE api/spTICK_Playlist_Details_Get_Result/5
        //public HttpResponseMessage DeletespTICK_Playlist_Details_Get_Result(int id)
        //{
        //    spTICK_Playlist_Details_Get_Result spTICK_Playlist_Details_Get_Result = db.spTICK_Playlist_Details_Get_Results.Where(gw => gw.ID == id).FirstOrDefault();
        //    if (spTICK_Playlist_Details_Get_Result == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.spTICK_Playlist_Details_Get_Results.DeleteObject(spTICK_Playlist_Details_Get_Result);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, spTICK_Playlist_Details_Get_Result);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}