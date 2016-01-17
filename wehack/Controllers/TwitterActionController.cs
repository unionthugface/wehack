using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using wehack.Services;
using LinqToTwitter;
using System.Configuration;
using wehack.Models.Responses;  
namespace wehack.Controllers
{
    public class TwitterActionController : Controller
    {
        // GET: TwitterAction
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Send(string message)
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore(System.Web.HttpContext.Current.Session)
            };

            try
            {
                Task.Run(() => TwitterService.SendTweet(auth, message));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }



        public async Task<ActionResult> GetTimeLine()
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var ctx = new TwitterContext(auth);

            var tweets =
                await
                (from tweet in ctx.Status
                 where tweet.Type == StatusType.User &&
                       tweet.ScreenName == "riadosaband"
                 select new TweetViewModel
                 {
                     ImageUrl = tweet.User.ProfileImageUrl,
                     ScreenName = tweet.User.ScreenNameResponse,
                     Text = tweet.Text,
                     Id = tweet.ID.ToString()
                 })
                .ToListAsync();

            return Json(tweets, JsonRequestBehavior.AllowGet);
        }
    }
}