using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using LinqToTwitter;
using System.Configuration;

namespace wehack.Controllers
{
    public class OauthController : Controller
    {
        // GET: Oauth
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> BeginAsync()
        {
            //var auth = new MvcSignInAuthorizer
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore
                {
                    ConsumerKey = ConfigurationManager.AppSettings["TwitterConsumerKey"],
                    ConsumerSecret = ConfigurationManager.AppSettings["TwitterConsumerSecret"]
                }
            };

            UrlHelper uHelp = new UrlHelper(Request.RequestContext);
            Uri url = Request.Url;
            string newUrl = new UriBuilder(url.Scheme, url.Host, url.Port, uHelp.Action("CompleteAsync", "Oauth")).ToString();
            Uri callbackUri = new Uri(newUrl);
           
            return await auth.BeginAuthorizationAsync(callbackUri);
        }

        public async Task<ActionResult> CompleteAsync()
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            await auth.CompleteAuthorizeAsync(Request.Url);

            // This is how you access credentials after authorization.
            // The oauthToken and oauthTokenSecret do not expire.
            // You can use the userID to associate the credentials with the user.
            // You can save credentials any way you want - database, 
            //   isolated storage, etc. - it's up to you.
            // You can retrieve and load all 4 credentials on subsequent 
            //   queries to avoid the need to re-authorize.
            // When you've loaded all 4 credentials, LINQ to Twitter will let 
            //   you make queries without re-authorizing.
            //
            var credentials = auth.CredentialStore;
            string oauthToken = credentials.OAuthToken;
            string oauthTokenSecret = credentials.OAuthTokenSecret;
            string screenName = credentials.ScreenName;
            ulong userID = credentials.UserID;
            //

            return RedirectToAction("Form", "Home");
        }

        
    }
}