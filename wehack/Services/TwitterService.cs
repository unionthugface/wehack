using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToTwitter;
using System.Configuration;
using System.Threading.Tasks;

namespace wehack.Services
{
    public class TwitterService
    {

        public static async void SendTweet(MvcAuthorizer auth, string message)
        {
            
            var ctx = new TwitterContext(auth);
            var context = new TwitterContext(auth);

            await context.TweetAsync(
                message
            );
        }

        public static async void ReTweet(MvcAuthorizer auth, string ID)
        {

            var ctx = new TwitterContext(auth);
            var context = new TwitterContext(auth);

            await context.TweetAsync(
                ID
            );
        }

    }
}