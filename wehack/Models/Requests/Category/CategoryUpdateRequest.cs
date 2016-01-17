using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wehack.Models.Requests.Category
{
    public class CategoryUpdateRequest : CategoryAddRequest
    {
        public int Id { get; set; }
    }
}