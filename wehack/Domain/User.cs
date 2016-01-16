using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wehack.Domain
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string TwitterHandle { get; set; }

        public Guid Oauth { get; set; }
    }
}