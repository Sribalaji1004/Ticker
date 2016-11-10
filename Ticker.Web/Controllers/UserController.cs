using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace Ticker.Controllers
{
    public class UserController : Controller
    {

        private static OpenIdRelyingParty openid = new OpenIdRelyingParty();

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return Redirect("~/User/Login?ReturnUrl=" + Request.Url.PathAndQuery);
            //else if (User.Identity.IsAuthenticated && Session.Count == 0)
            //{
            //    System.Web.Security.FormsAuthentication.SignOut();
            //    return Redirect("~/User/Login?ReturnUrl=" + Request.Url.PathAndQuery);
            //}

            return View("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Home");
        }

        public ActionResult Login()
        {
            // Stage 1: display login form to user
            //return View("Login");
            //bool oAuthByPass = false;
            bool oAuthByPass = true;
            if (System.Configuration.ConfigurationManager.AppSettings["oAuthByPass"] != null)
                oAuthByPass = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["oAuthByPass"].ToString());

            if (oAuthByPass)
            {
                Session["FriendlyIdentifier"] = "kashifn";
                string username = "kashifn";
                Session["username"] = username; //parsed out from server and path (i.e. //server/user/johnsmi)
                //Ticker.Data.User user = new Ticker.Data.FoxTickerEntities().Users.FirstOrDefault(u => u.Username == username);
                //FormsAuthentication.SetAuthCookie(response.ClaimedIdentifier, false);
                Session["UserID"] = 0;//user.UserID;

                FormsAuthentication.SetAuthCookie("kashifn", false);
                return RedirectToAction("Index", "Home");
            }


            return Redirect("Authenticate?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]));
        }

        [ValidateInput(false)]
        public ActionResult Authenticate(string returnUrl)
        {
            var response = openid.GetResponse();
            if (response == null)
            {
                // Stage 2: user submitting Identifier

                return oAuthRequest();
                //} else {
                //    ViewData["Message"] = "Invalid identifier";
                //    return View("Login");
                //}
            }
            else
            {
                // Stage 3: OpenID Provider sending assertion response
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        Session["FriendlyIdentifier"] = response.FriendlyIdentifierForDisplay;
                        string username = Session["FriendlyIdentifier"].ToString().Split('/')[2];
                        Session["username"] = username; //parsed out from server and path (i.e. //server/user/johnsmi)
                        Ticker.Data.User user = new Ticker.Data.FoxTickerEntities().Users.FirstOrDefault(u => u.Username == username);
                        FormsAuthentication.SetAuthCookie(response.ClaimedIdentifier, false);
                        Session["UserID"] = user.UserID;

                        if ((bool)user.Inactive)
                        {
                            System.Web.Security.FormsAuthentication.SignOut();
                            return RedirectToAction("Index", "Home");
                        }
                        else if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        break;
                    case AuthenticationStatus.Canceled:
                        //ViewData["Message"] = "Canceled at provider";
                        //return View("Login");
                        return oAuthRequest();
                    case AuthenticationStatus.Failed:
                        //ViewData["Message"] = response.Exception.Message;
                        //return View("Login");
                        return oAuthRequest();
                }
            }
            return new EmptyResult();
        }

        private ActionResult oAuthRequest()
        {
            Identifier id;
#if DEBUG
            //id = "http://localhost:999/";
            id = "http://fn101devz01:999/";
#else
            id = "http://oauth.foxneo.com/";
#endif
            //if (Identifier.TryParse(Request.Form["openid_identifier"], out id)) {
            try
            {
                //return openid.CreateRequest(Request.Form["openid_identifier"]).RedirectingResponse.AsActionResult();
                return openid.CreateRequest(id).RedirectingResponse.AsActionResult();
            }
            catch (ProtocolException ex)
            {
                ViewData["Message"] = ex.Message;
                return View("Login");
            }
        }
    }

}

