using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wehack.Models;

namespace wehack.Service
{
    public class TwitterService : ITwitterService
    {
        private string _retweetUrl = @"https://api.twitter.com/1.1/statuses/retweet/:id.json";

        public void Retweet(long tweetId) 
        {
            
        }
    }
}
