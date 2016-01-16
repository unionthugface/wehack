using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wehack.Models.Requests.Incident
{
    public class IncidentAddRequest
    {
        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public Guid Status { get; set; }
    }
}