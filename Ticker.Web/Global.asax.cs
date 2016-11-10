using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using Ticker.Handlers;

namespace Ticker
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public override void Init()
        {
            this.PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(
                SessionStateBehavior.Required);
        }
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //view
            //routes.MapRoute(
            //    //"PlaylistPlaylist",                                           // Route name
            //    "Playlists",                                           // Route name
            //    //"Playlists/{clientID}/{playlistID}",                            // URL with parameters
            //    "Playlists/{clientID}",                            // URL with parameters
            //    new { controller = "Playlists", action = "Index" }  // Parameter defaults
            //);
            routes.MapRoute(
                //"PlaylistPlaylist",                                           // Route name
               "PlaylistDetails",                                           // Route name
                //"Playlists/{clientID}/{playlistID}",                            // URL with parameters
               "PlaylistDetails/{playlistID}",                            // URL with parameters
               new { controller = "PlaylistDetails", action = "Index" }  // Parameter defaults
           );
            routes.MapRoute(
                //"PlaylistPlaylist",                                           // Route name
               "Groups",                                           // Route name
                //"GroupEditor/{clientID}/{playlistID}",                            // URL with parameters
               "Groups/{groupID}",                            // URL with parameters
               new { controller = "GroupEditor", action = "Index" }  // Parameter defaults
           );
         //   routes.MapRoute(
         //    "PlaylistItems",                                           // Route name
         //       //"Playlists/{clientID}/{playlistID}",                            // URL with parameters
         //    "api/PlaylistItems/{id}",                            // URL with parameters
         //    new { controller = "Playlists", action = "Index" }  // Parameter defaults
         //);

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Logs",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Logs", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapHttpRoute(
               name: "TeambyLeague",
               routeTemplate: "api/{controller}/{teams}/{league}"
           );
            routes.MapHttpRoute(
               name: "SettingsbyLeague",
               routeTemplate: "api/{controller}/{id}/{lcode}",
               defaults: null,
               constraints: new { id = @"\d+" }


           );



        }

        protected void Application_Start()
        {
            RouteTable.Routes.MapHubs();
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Ticker.Controllers.Utilities.BreakingNewsTypesLoad();
            Ticker.Controllers.Utilities.ExpirationModesLoad();

            //HttpConfiguration hc = new HttpConfiguration();
            //hc.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;



            //GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());
        }
    }
}