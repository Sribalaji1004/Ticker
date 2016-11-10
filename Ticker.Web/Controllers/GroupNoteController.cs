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
    public class GroupNoteController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/Note
        public DataSourceResult GetGroupNotes(int id, [ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //return db.Notes.AsEnumerable();
            return db.Notes.Where(nw => nw.GroupID == id).AsEnumerable().OrderBy(s => s.SortOrder).ToDataSourceResult(request, n => new
            {
                // Skip the EntityState and EntityKey properties inherited from EF. It would break model binding.
                //n.Group,
                n.GroupID,
                n.Header,
                n.ID,
                n.Imported,
                n.LastUpdated,
                n.Note1,
                //LastUpdatedBy = (n.UserID != null && n.UserID != 0 && db.Users.Where(u => u.UserID == n.UserID).Count() != 0 ? " last updated by " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().FirstName + " " + db.Users.Where(u => u.UserID == n.UserID).FirstOrDefault().LastName + ", " + n.LastUpdated.ToString() : n.Note1),
                NoteColor = n.NoteColor == "" ? n.Note1 : Utilities.ConvertToHTML(n.NoteColor), //send plain note if there is no color version
                n.SortOrder,
                n.TeamID,
                //TeamName = db.Teams.Where(tw => tw.ID == n.TeamID).Single().CityName + " " + db.Teams.Where(tw => tw.ID == n.TeamID).Single().Abbreviation,
                n.UserID
            });

        }
       protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}