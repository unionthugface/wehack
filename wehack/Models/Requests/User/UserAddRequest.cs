using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wehack.Models.Requests.User
{
    public class UserAddRequest
    {        
        public string Name { get; set; }

        public string TwitterHandle { get; set; }

        public Guid Oauth { get; set; }
    }
}