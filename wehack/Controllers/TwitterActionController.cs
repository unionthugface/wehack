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
using wehack.Service;
using wehack.Models.Requests.Incident;
using System.Net.Http;
using System.Net;
namespace wehack.Controllers
{
    public class TwitterActionController : Controller
    {
        // GET: TwitterAction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TweetRetweet()
        {
            IncidentAddRequest model = new IncidentAddRequest();
            model.categoryId = Convert.ToInt16(Request.QueryString["CategoryId"]);
            model.UserId = Convert.ToInt16(Request.QueryString["UserId"]);
            model.Lat = Convert.ToDouble(Request.QueryString["Lat"]);
            model.Lng = Convert.ToDouble(Request.QueryString["Lng"]);


            //HttpResponseMessage resp = null;
            try
            {
                //ComplaintStatusType status = ComplaintStatusType.NotSet;

                //Check location and category of tweet to see if complaint already exists
                WehackDataService service = new WehackDataService();
                IncidentResponse incident = service.CreateComplaint(model);

                if (incident == null || incident.TweetId == null)
                {
                    //get auth context
                    //create tweet
                    //assign tweetId back to database
                    //template: @riadosaband Issue #93 Pothole! 33.940109, -118.133159 #lahasissues
                    var categoryString = model.categoryId == 1 ? "Pothole" : "Streetlight";
                    var tweet = "@riadosaband " + "#" + categoryString + incident.IncidentId.ToString() + " " + model.Lat + ", " + model.Lng + " #lahasissues";

                    var auth = new MvcAuthorizer
                    {
                        CredentialStore = new SessionStateCredentialStore(System.Web.HttpContext.Current.Session)
                    };
                    try
                    {
                        Task.Run(() => wehack.Services.TwitterService.SendTweet(auth, tweet));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    
                }
                else
                {

                    var auth = new MvcAuthorizer
                    {
                        CredentialStore = new SessionStateCredentialStore(System.Web.HttpContext.Current.Session)
                    };
                    try
                    {
                        Task.Run(() => wehack.Services.TwitterService.ReTweet(auth, Convert.ToInt16(incident.TweetId)));

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                
            }
            catch (Exception ex)
            {
                //resp = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            return RedirectToRoute("IssueFeed", "Home");
        }



        public ActionResult Send(string message)
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore(System.Web.HttpContext.Current.Session)
            };

            try
            {
                Task.Run(() => wehack.Services.TwitterService.SendTweet(auth, message));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToRoute("Home", "IssueFeed");
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