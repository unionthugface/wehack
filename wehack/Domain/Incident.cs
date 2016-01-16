﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wehack.Domain
{
    public class Incident
    {
        public int IncidentId { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public StatusType Status { get; set; }
    }
}