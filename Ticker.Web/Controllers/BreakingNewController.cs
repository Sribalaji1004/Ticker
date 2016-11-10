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
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticker.Controllers
{
    public class BreakingNewController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/BreakingNews
        public IEnumerable<BreakingNew> GetBreakingNews()
        {
            return db.BreakingNews.AsEnumerable();
        }

        // GET api/BreakingNews/5
        public BreakingNew GetBreakingNew(int id)
        {
            BreakingNew BreakingNew = db.BreakingNews.Single(u => u.ID == id);
            if (BreakingNew == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return BreakingNew;
        }

        public DataSourceResult GetBreakingNew([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request, int id, int clientID)
        {
            //Playlist Playlist = db.Playlists.Find(id);
            var BreakingNew = db.BreakingNews.Where(gw => gw.ClientID == clientID);
            if (BreakingNew == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            // BreakingNew.ToList().ForEach(a => a.PlaylistDetails.Load());

            //return BreakingNew.AsEnumerable().OrderBy(o => o.SortOrder).OrderByDescending(o => o.LastUpdated).ToDataSourceResult(request, p =>
            return BreakingNew.AsEnumerable().OrderByDescending(o => o.SortOrder).ToDataSourceResult(request, p =>
                new
                {
                    p.ID,
                    p.BreakingNewsTypeID,
                    BreakingNewsDescription =db.BreakingNewsTypes.Where(b => b.ID == p.BreakingNewsTypeID && b.Enabled==true).Select(b=>b.Description).FirstOrDefault(), //(p.BreakingNewsType.Description == null || p.BreakingNewsType.Description == "" ? "" : p.BreakingNewsType.Description.ToString().Trim()),
                    p.ClientID,
                   
                    p.Enabled,
                    p.Note,
                    p.ColorHex,
                    p.IntroMovie,
                    p.IntroText,
                    p.TopicMovie,
                    p.TopicText,
                    p.HeaderMovie,
                    p.HeaderText,
                    HeaderImage=(p.HeaderImage == null ? "" : p.HeaderImage.ToString().Trim()),
                    p.Repeat,
                    p.NumberOfGraphicsBetween,
                    p.ExpiresOn,
                    p.ExpiresIn,
                    p.ExpirationMode,// = (p.ExpiresIn == null ? (p.ExpiresOn == null ? 0 : 1) : 2),
                    p.SortOrder,
                    p.LastUpdated
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

        // PUT api/BreakingNews/5
        public HttpResponseMessage PutBreakingNew(int id, BreakingNew BreakingNew)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != BreakingNew.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            updateSortOrder(id, BreakingNew.SortOrder);
            BreakingNew.Note = BreakingNew.Note.Replace((char)0xA0, ' ');
            BreakingNew.LastUpdated = DateTime.Now;

            string BreakingNewsType = db.BreakingNewsTypes.Where(b => b.ID == BreakingNew.BreakingNewsTypeID && b.Enabled == true).Select(b => b.Description).FirstOrDefault();
            

            //**** Breaking News Alert **** -- Start ****// 
            if (BreakingNewsType.ToLower().Trim() == "breaking news")
            {
                BreakingNew.ColorHex = "#c71d1d";
                BreakingNew.IntroMovie = "BreakingNewsIntro.mov";
                BreakingNew.IntroText = "BREAKING NEWS";
                BreakingNew.TopicMovie = "BreakingNewsHeaderBackground.mov";
                BreakingNew.TopicText = "";
                BreakingNew.HeaderMovie = "BreakingNewsSubHeaderBackground.mov";
            }
            //****  Breaking News **** -- End ****// 


            //**** Program Alert **** -- Start ****// 
            if (BreakingNewsType.ToLower().Trim() == "program alert")
            {
                BreakingNew.ColorHex = "#2828c8";
                BreakingNew.IntroMovie = "ProgramAlertIntroMotion.mov";
                BreakingNew.IntroText = "PROGRAM ALERT";
                BreakingNew.TopicMovie = "ProgramAlertHeader.mov";
                BreakingNew.TopicText = "";
                BreakingNew.HeaderMovie = "ProgramAlertSubHeader.mov";
            }
            //****  Program Alert **** -- End ****// 

            
            db.BreakingNews.Attach(BreakingNew);
            
            db.ObjectStateManager.ChangeObjectState(BreakingNew, EntityState.Modified);

            try
            {
                db.SaveChanges();
                
                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Group), Utilities.Action_Flag.CHANGE, BreakingNew.ID.ToString(), BreakingNew.Note, "Updated Alert from \"" + BreakingNew.HeaderText + "\" on \"" + BreakingNew.IntroText + "\"", true);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);

            /*if (ModelState.IsValid && id == BreakingNew.BreakingNewID)
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

        public HttpResponseMessage PutBreakingNew(int id, bool Enabled)
        {
            //BreakingNew BreakingNew = db.BreakingNews.Single(u => u.BreakingNewID == id);
            //if (BreakingNew == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}

            //BreakingNew.Inactive = !BreakingNew.Inactive;
            ////db.BreakingNews.DeleteObject(BreakingNew);
            BreakingNew bn = db.BreakingNews.Single(u => u.ID == id);

            

            if (Enabled)
                db.BreakingNews.Where(usr => usr.ClientID == bn.ClientID).ToList().ForEach(ui => ui.Enabled = !Enabled);
            bn.Enabled = Enabled;
            bn.LastUpdated = DateTime.Now;
            try
            {
                db.SaveChanges();

                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Group), Utilities.Action_Flag.CHANGE, bn.ID.ToString(), bn.Note, "Updated Alert from \"" + bn.HeaderText + "\" on \"" + bn.IntroText + "\"", true);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);//, BreakingNew);
        }


        private void updateSortOrder(int id, Nullable<global::System.Byte> sort,bool forceReorder = false)
        {
            BreakingNew bn = db.BreakingNews.Single(u => u.ID == id);
            if (bn.SortOrder == sort && !forceReorder)
            {
                db.BreakingNews.Detach(bn);
                return;

            }

            int start = 0;// Convert.ToInt32(sort);
           // if(sort == 0) // new or previously un sorted            
            {
                var alerts = db.BreakingNews.Where(a =>  a.ClientID == bn.ClientID && a.ID != bn.ID && a.SortOrder != 0).OrderBy(b => b.SortOrder);
                List<BreakingNew> all = alerts.ToList();
                foreach (BreakingNew b in all)
                {
                    

                        b.SortOrder =  Convert.ToByte (start + 1);
                        if (b.SortOrder == sort)
                        {
                            b.SortOrder++;
                            start++;
                        }
                        start++;
                        db.SaveChanges();
                    
                }

            }
       /*     else if (sort < bn.SortOrder)
            {
               var alerts = db.BreakingNews.Where(a => a.SortOrder >= sort && a.SortOrder <= bn.SortOrder).OrderBy(b => b.SortOrder);
               List<BreakingNew> all = alerts.ToList();
               foreach (BreakingNew b in all)
               {
                   if(b.ID != id)
                   {
                    b.SortOrder++;
                    db.SaveChanges();
                   }
                   

               }

            }
            else
            {
                var alerts = db.BreakingNews.Where(a => a.SortOrder <= sort && a.SortOrder >= bn.SortOrder).OrderBy(b => b.SortOrder);
                List<BreakingNew> all = alerts.ToList();
                foreach (BreakingNew b in all)
                {
                    if (b.ID != id)
                    {
                        b.SortOrder--;
                        db.SaveChanges();
                    }
                }

            }*/
            db.BreakingNews.Detach(bn);


        }


        // POST api/BreakingNews
        public HttpResponseMessage PostBreakingNew(BreakingNew BreakingNew)
        {
            if (ModelState.IsValid)
            {
                BreakingNew.Note = BreakingNew.Note.Replace((char)0xA0, ' ');
                BreakingNew.Enabled = false;
                string BreakingNewsType = db.BreakingNewsTypes.Where(b => b.ID == BreakingNew.BreakingNewsTypeID && b.Enabled==true).Select(b=>b.Description).FirstOrDefault();
                

                //**** Breaking News Alert **** -- Start ****// 
                if (BreakingNewsType.ToLower().Trim() == "breaking news")
                {
                    BreakingNew.ColorHex = "#c71d1d";
                    BreakingNew.IntroMovie = "BreakingNewsIntro.mov";
                    BreakingNew.IntroText = "BREAKING NEWS";
                    BreakingNew.TopicMovie = "BreakingNewsHeaderBackground.mov";
                    BreakingNew.TopicText = "";
                    BreakingNew.HeaderMovie = "BreakingNewsSubHeaderBackground.mov";
                }
               //****  Breaking News **** -- End ****// 


                //**** Program Alert **** -- Start ****// 
                if (BreakingNewsType.ToLower().Trim() == "program alert")
                {
                    BreakingNew.ColorHex = "#2828c8";
                    BreakingNew.IntroMovie = "ProgramAlertIntroMotion.mov";
                    BreakingNew.IntroText = "PROGRAM ALERT";
                    BreakingNew.TopicMovie = "ProgramAlertHeader.mov";
                    BreakingNew.TopicText = "";
                    BreakingNew.HeaderMovie = "ProgramAlertSubHeader.mov";
                }
                //****  Program Alert **** -- End ****// 

                
              
                db.BreakingNews.AddObject(BreakingNew);
                db.SaveChanges();
                updateSortOrder(BreakingNew.ID, BreakingNew.SortOrder,true);
                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Group), Utilities.Action_Flag.ADDITION, BreakingNew.ID.ToString(), BreakingNew.Note, "Added Alert from \"" + BreakingNew.HeaderText + "\" on \"" + BreakingNew.IntroText + "\"", true);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, BreakingNew);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = BreakingNew.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/BreakingNews/5
        public HttpResponseMessage DeleteBreakingNew(int id)
        {
            //BreakingNew BreakingNew = db.BreakingNews.Single(u => u.ID == id);
            //if (BreakingNew == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}

            //BreakingNew.Inactive = !BreakingNew.Inactive;

            //db.BreakingNews.Where(usr => usr.BreakingNewname == db.BreakingNews.FirstOrDefault(u => u.BreakingNewID == id).BreakingNewname).ToList().ForEach(ui => ui.Inactive = !ui.Inactive);
            
            updateSortOrder(id, 0, true);
            BreakingNew bn = db.BreakingNews.Single(u => u.ID == id);
            db.BreakingNews.DeleteObject(bn);

            //bn.Enabled = false;

            try
            {
                db.SaveChanges();
                
                Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Group), Utilities.Action_Flag.ADDITION, bn.ID.ToString(), bn.Note, "Deleted Alert \"" + bn.IntroText + "\"", true);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);//, BreakingNew);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}