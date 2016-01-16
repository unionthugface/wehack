using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace wehack.Controllers
{
    [RoutePrefix("api/complaint")]
    public class ComplaintApiController : ApiController
    {
        [Route("send")]
        [HttpPost]
        public HttpResponseMessage SendComplaint(/*ComplaintModel model*/)
        {
            HttpResponseMessage resp = null;
            try 
            {
            
            }
            catch (Exception ex)
            {
                resp = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

            return resp;
        }
    }
}
