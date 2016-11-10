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
    public class LogController : ApiController
    {
        private FoxTickerEntities db = new FoxTickerEntities();

        // GET api/log
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/log/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        public DataSourceResult GetLogs([ModelBinder(typeof(Ticker.ModelBinders.DataSourceRequestModelBinder))] DataSourceRequest request, int id, int flag)
        {
            DateTime logStartdate = DateTime.Today.Subtract(TimeSpan.FromDays(10));

            var logs = flag != 0 ? db.auth_admin_log.Where(a => a.action_flag == flag && logStartdate <= a.action_time) :
                db.auth_admin_log.Where(a =>  logStartdate <= a.action_time);

            logs.ToList().ForEach(l => l.UserReference.Load());
            //logs = logs.Where(x => x.action_time >= logStartdate);
          //  logs.ToList().ForEach(l => l.User = db.Users.Where(u => u.UserID == l.user_id).FirstOrDefault());

            if (logs == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return logs.AsEnumerable().OrderByDescending(o => o.action_time).ToDataSourceResult(request, p =>
                new
                {
                    p.action_time,
                    p.object_id,
                    p.User, //Username = db.Users.Single(u => u.UserID == p.user_id).Username,
                    p.change_message,
                })
                ;
        }
        //public class LogAction
        //{
        //    public Utilities.Action_Flag action;
        //    public string object_id;
        //    public string object_repr;
        //    public string change_message;
        //}

        //// POST api/log
        //public void Post(LogAction l)
        //{
        //    Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Game), l.action, l.object_id, l.object_repr, l.change_message, true);
        //}

        // POST api/log
        public void Post(Utilities.Action_Flag action, string object_id, string object_repr, string change_message)
        {
            Utilities.Write_Admin_Log(db, Utilities.App_Label.FoxTick, typeof(Playlist), action, object_id, object_repr, change_message, true);
        }

        // PUT api/log/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/log/5
        public void Delete(int id)
        {
        }
    }
}
