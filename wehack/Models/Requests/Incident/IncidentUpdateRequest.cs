using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wehack.Models.Requests.Incident
{
    public class IncidentUpdateRequest : IncidentAddRequest
    {
        public int IncidentId { get; set; }

        public long TweetId { get; set; }
    }
}