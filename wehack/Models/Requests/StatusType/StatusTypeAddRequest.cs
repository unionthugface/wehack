using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wehack.Models.Requests.StatusType
{
    public class StatusTypeAddRequest
    {
        public int NotSet { get; set; }

        public int Open { get; set; }

        public int Resolved { get; set; }
    }
}