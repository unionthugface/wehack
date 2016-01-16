using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wehack.Models.Requests.User
{
    public class UserUpdateRequest : UserAddRequest
    {
        public int UserId { get; set; }
    }
}